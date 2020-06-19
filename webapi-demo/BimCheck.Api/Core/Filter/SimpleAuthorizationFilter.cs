using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace BimCheck.Api.Core
{
    public class SimpleAuthorizationFilter : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            base.HandleUnauthorizedRequest(actionContext);

            //构造自定义数据格式
            var data = new JsonResultBuilder()
                        .SetCode(JsonResultCode.Forbidden)
                        .SetMessage("无效的token")
                        .SetEmptyResult().Build();

            //返回消息体
            actionContext.Response = new HttpResponseMessage()
            {
                Content = new StringContent(JsonConvert.SerializeObject(data)),
                StatusCode = HttpStatusCode.Forbidden
            };
        }
    }
}