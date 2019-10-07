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
            Get["/"] = r =>
            {
                var os = System.Environment.OSVersion;                
                return "Hello Nancy<br/> System:" + os.VersionString;
            };

            Post["/test"] = lam =>
            {
                string data = Request.Body.AsString();
                var dataItem = JsonConvert.DeserializeObject<DataItem>(data);

                return HttpStatusCode.OK;
            };
        }
    }
}
