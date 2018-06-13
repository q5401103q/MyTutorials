using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRLoginTutorial.Common
{
    public class DataGenerator
    {
        /// <summary>
        /// 生成二维码的内容
        /// </summary>
        /// <returns></returns>
        public static string Generate()
        {
            //定义数据节点
            JObject json = new JObject();

            //添加标识
            json.Add("token", Guid.NewGuid().ToString().Replace("-", string.Empty));

            //添加到期时间
            json.Add("timestamp", DateTime.Now.AddMinutes(1).ToString("yyyy-MM-dd HH:mm:ss"));
            
            //返回二维码内容
            return json.ToString();
        }
    }
}