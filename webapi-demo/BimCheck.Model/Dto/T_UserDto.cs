using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BimCheck.Model.Dto
{
    public class T_UserDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        [JsonProperty("mobile")]
        public string Mobile { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }
        /// <summary>
        /// 性别，0=未知，1=男，2=女
        /// </summary>
        [JsonProperty("gender")]
        public sbyte Gender { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        [JsonProperty("birthday")]
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        [JsonProperty("nickname")]
        public string Nickname { get; set; }
        /// <summary>
        /// 头像缩略图
        /// </summary>
        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }
    }
}
