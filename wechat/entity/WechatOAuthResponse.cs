using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDit.Component.Tools.Wechat
{
    public class WechatOAuthResponse
    {
        public string access_token {get;set;}
        public string expires_in { get;set;}
        public string refresh_token { get;set;}
        public string openid { get;set;}
        public string scope { get;set;}
        /// <summary>
        /// 错误码
        /// </summary>
        public string errcode { get; set; }
        /// <summary>
        /// 错误消息
        /// </summary>
        public string errmsg { get; set; }
    }
}
