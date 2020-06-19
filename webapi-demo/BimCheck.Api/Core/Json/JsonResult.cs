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
        /// 200 => 请求成功
        /// 其他 => 请求失败
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        [JsonProperty("msg")]
        public string Message { get; set; }
        /// <summary>
        /// 业务数据
        /// </summary>
        [JsonProperty("result")]
        public object Result { get; set; }
        /// <summary>
        /// 重写方法
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None, CustomJsonSerializer.GetSerializerSetting());
        }
    }
}