using Nancy;
using Nancy.Extensions;
using NancySample.entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancySample
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            #region 关于路由的说明
            //https://github.com/NancyFx/Nancy/wiki/Defining-routes
            //路由的几种写法：
            //1. Literal segments - (10,000) - /some/literal/segments which require an exact match.
            //2. Capture segments - (1,000) - /{name} which captures whatever is passed into the given segment of the requested URL and then passes it into the Action of the route.
            //3. Capture segments (optional) - (1,000) - /{name?} by adding the question mark at the end of the segment name the segment can be made optional.
            //4. Capture Segments (optional/default) - (1,000) - /{name?unnamed}/ by adding a value after the question mark we can turn an optional segment into a segment with a default value, should the pattern be the most suited but the segment missing, the value returned will be what comes after the question mark.
            //5. RegEx Segment - (1,000) - /(?<age>[\d]{1,2}) using Named Capture Grouped Regular Expressions, you can get a little more control out of the segment pattern. If you don't need to capture anything then you can use a non-capturing group like (?:regex-goes-here)
            //6. Greedy Segment - (0) - /{name*} by adding a star/asterisk to the end of the segment name, the pattern will match any value from the current forward slash onward.
            //7. Greedy RegEx Segment - (100) - ^(?<name>[a-z]{3,10}(?:/{1})(?<action>[a-z]{5,10}))$ a segment composed of a RegEx and Greedy segment, this captures the entire path after the forward slash, The segment must start with ^( and end with )$ so we know the start/finish of the greedy regular expression segment.
            //8. Multiple Captures Segment - (100) - /{file}.{extension} or /{file}.ext a segment containing a mix of captures and literals.
            #endregion

            #region 关于参数的说明
            /*
            int -Allows only Int32(int) values.
            long -Allows only Int64(long) values.
            decimal -Allows only decimal values.
            guid - Allows only GUID values.
            bool -Allows only boolean values.
            alpha - Allows only values containing alphabetical character.
            datetime - Allows only date values, optionally containing time.
            datetime(format)(Added in 0.22) - Allows only date and / or time values with the specified format. For format values, see Custom Date and Time Format Strings. eg: yyyy-MM-dd HH:mm:ss
            min(minimum) - Allows only integer values with the specified minimum value.
            max(maximum) - Allows only integer values with the specified maximum value.
            range(minimum, maximum) - Allows only integer values within the specified range. (Between minimum and maximum)
            minlength(length) - Allows only values longer than the specified minimum length.
            maxlength(length) - Allows only values shorter that the maximum length.
            length(minimum, maximum) - Allows only values with length within the specified range. (Between minimum and maximum)
            version(Added in 1.2) - Allows only Version values, e.g. 1.2.0.

            关于版本的示例：
            using System;
            using System.Reflection;

            [assembly:AssemblyVersionAttribute("2.0.1")]
            public class Example1
            {
               public static void Main()
               {
                  Assembly thisAssem = typeof(Example1).Assembly;
                  AssemblyName thisAssemName = thisAssem.GetName();
       
                  Version ver = thisAssemName.Version;
       
                  Console.WriteLine("This is version {0} of {1}.", ver, thisAssemName.Name);    
               }
            }
            // The example displays the following output:
            // This is version 2.0.1.0 of Example1.

            关于自定义类型的示例：
            public class EmailRouteSegmentConstraint : RouteSegmentConstraintBase<string>
            {
                public override string Name
                {
                    get { return "email"; }
                }

                protected override bool TryMatch(string constraint, string segment, out string matchedValue)
                {
                    if (segment.Contains("@"))
                    {
                        matchedValue = segment;
                        return true;
                    }

                    matchedValue = null;
                    return false;
                }
            }
            */
            #endregion

            #region GET示例
            /// =================================================
            /// 根路由演示
            /// =================================================
            Get["/"] = lambda =>
            {
                return "System:" + System.Environment.OSVersion.VersionString;
            };
            /// =================================================
            /// 指定路由生效
            /// =================================================
            Get["/test1"] = lambda =>
            {
                return "Hello Nancy!";
            };
            /// =================================================
            /// 指定参数
            /// =================================================
            Get["/{test2}"] = lambda =>
            {
                return "My parameter is " + lambda.test2;
            };
            /// =================================================
            /// 指定参数，可空，指定默认值
            /// =================================================
            Get["/{test3?test3val}"] = lambda =>
            {
                return "My parameter is " + lambda.test3;
            };
            /// =================================================
            /// 指定路由和参数，指定参数类型
            /// =================================================
            Get["/test4/{value:int}"] = lambda =>
            {
                return "Value " + lambda.value + " is an integer.";
            };
            /// =================================================
            /// 指定路由和参数，指定自定义参数类型
            /// =================================================
            Get["/test5/{value:email}"] = lambda =>
            {
                return "Value " + lambda.value + " is an e-mail address.";
            };
            /// =================================================
            /// 指定路由和参数，正则匹配
            /// =================================================
            Get[@"/test6/(?<id>[\d]{1,7})"] = parameters =>
            {
                return 200; //200代表HTTP STATUS CODE
            };
            /// =================================================
            /// 指定路由和参数，正则匹配
            /// =================================================
            Get["/test7", true] = async (ctx, ct) =>
            {
                await Task.Delay(1000);

                return 200;
            };
            #endregion

            #region POST示例
            Post["/test"] = lambda =>
            {
                string data = Request.Body.AsString();

                var dataItem = JsonConvert.DeserializeObject<DataItem>(data);

                var json = JsonConvert.SerializeObject(dataItem);

                return Response.AsText(json);
            };
            #endregion
        }
    }
}
