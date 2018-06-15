using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Library.json
{
    public class CustomJsonSerializer
    {
        public static JsonSerializer serializer = null;
        public static JsonSerializerSettings setting = null;

        /// <summary>
        /// 自定义序列化时间
        /// </summary>
        /// <returns></returns>
        public static JsonSerializer GetSerializer()
        {
            if (serializer == null)
            {
                if (setting == null)
                {
                    setting = new JsonSerializerSettings();
                    setting.Converters.Add(new IsoDateTimeConverter
                    {
                        //这里指定序列化的格式
                        DateTimeFormat = "yyyy-MM-dd HH:mm:ss"
                    });
                }
                serializer = JsonSerializer.Create(setting);
            }
            return serializer;
        }
    }
}
