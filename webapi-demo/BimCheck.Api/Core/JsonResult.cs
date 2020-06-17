using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BimCheck.Api.Core
{
    /// <summary>
    /// 标准的JSON
    /// </summary>
    [Serializable]
    public class JsonResult
    {
        /// <summary>
        /// 错误代码
        /// 0 => 请求成功
        /// 其他 => 请求失败
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 业务数据
        /// </summary>
        public object result { get; set; }

        /// <summary>
        /// 重写方法
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, CustomJsonSerializer.GetSerializerSetting());
        }
    }
}