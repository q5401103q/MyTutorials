using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDit.Component.Tools.Wechat
{
    public class WechatAccessResponse
    {
        public string access_token { get; set; }

        public int expires_in { get; set; }
        public int errcode { get; set; }
        public string errmsg { get; set; }
    }
}
