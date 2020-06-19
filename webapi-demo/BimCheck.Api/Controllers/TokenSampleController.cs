using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace BimCheck.Api.Controllers
{
    /// <summary>
    /// 获取token示例
    /// </summary>
    public class TokenSampleController : ApiController
    {
        /// <summary>
        /// 演示用获取token
        /// </summary>
        /// <param name="reqeustParam">
        /// 请求参数
        /// </param>
        /// <remarks>
        /// 请求地址示例：http://server-ip:server-port/token <br/>
        /// 请求参数示例：<![CDATA[grant_type=password&username=yourusername&password=yourpassword]]>
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public TokenResponseSample CreateToken(string reqeustParam)
        {
            return new TokenResponseSample()
            {
                access_token = "sample_token_for_developer_bula_bula",
                token_type = "Bearer",
                expires_in = 86400
            };
        }
    }

    /// <summary>
    /// token示例
    /// </summary>
    public class TokenResponseSample
    {
        /// <summary>
        /// token
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// 类型(Bearer)
        /// </summary>
        public string token_type { get; set; }

        /// <summary>
        /// 超时(单位秒)
        /// </summary>
        public int expires_in { get; set; }
    }
}