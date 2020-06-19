using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BimCheck.Model.Dto
{
    /// <summary>
    /// 作者：liuzl 
    /// 时间：2020/6/15 9:47:45
    /// 描述：
    /// </summary>
    public class StudentDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        [JsonProperty("age")]
        public DateTime? Age { get; set; }
    }
}
