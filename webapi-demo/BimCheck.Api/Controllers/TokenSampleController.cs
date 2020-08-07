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
        /// <param name="requestParam">
        /// 请求参数
        /// </param>
        /// <remarks>
        /// 请求地址示例：http://server-ip:server-port/api/token 
        /// 
        /// 请求示例：
        /// 
        /// <strong><![CDATA[POST /api/token HTTP/1.1]]></strong>
        /// <br/>
        /// <strong><![CDATA[Host: server-ip:server-port]]></strong>
        /// <br/>
        /// <strong><![CDATA[Content-Type: application/x-www-form-urlencoded]]></strong>
        /// <br/>
        /// <strong><![CDATA[grant_type=password&username=yourusername&password=yourpassword]]></strong>
        /// <br/>
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public TokenResponseSample CreateToken(string requestParam)
        {
            return new TokenResponseSample()
            {
                access_token = "sample_token_for_developer_bula_bula",
                token_type = "Bearer",
                expires_in = 86400,
                refresh_token = "refresh_token_bula_bula"
            };
        }

        /// <summary>
        /// 演示用刷新token
        /// </summary>
        /// <param name="requestParam">
        /// 请求参数
        /// </param>
        /// <remarks>
        /// 请求地址示例：http://server-ip:server-port/api/token 
        /// 
        /// 请求示例：
        /// 
        /// <strong><![CDATA[POST /api/token HTTP/1.1]]></strong>
        /// <br/>
        /// <strong><![CDATA[Host: server-ip:server-port]]></strong>
        /// <br/>
        /// <strong><![CDATA[Content-Type: application/x-www-form-urlencoded]]></strong>
        /// <br/>
        /// <strong><![CDATA[grant_type=refresh_token&refresh_token=your-refresh-token]]></strong>
        /// <br/>
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public TokenResponseSample RefreshToken(string requestParam)
        {
            return new TokenResponseSample()
            {
                access_token = "sample_token_for_developer_bula_bula",
                token_type = "Bearer",
                expires_in = 86400,
                refresh_token = "refresh_token_bula_bula"
            };
        }
    }

    /// <summary>
    /// token示例
    /// </summary>
    public class TokenResponseSample
    {
        /// <summary>
        /// 访问token
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

        /// <summary>
        /// 刷新token
        /// </summary>
        public string refresh_token { get; set; }
    }
}