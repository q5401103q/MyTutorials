using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace BimCheck.Api.Core
{
    public class ValidateModelStateFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                //定义错误列表，一次返回
                var errorMessage = new List<string>();
                foreach (var error in actionContext.ModelState.Values)
                {
                    foreach (var theError in error.Errors)
                    {
                        errorMessage.Add(theError.ErrorMessage);
                    }
                }

                //构造自定义数据格式
                var data = new JsonResultBuilder()
                            .SetCode(JsonResultCode.BadRequest)
                            .SetMessage(string.Join(",", string.Join(",", errorMessage)))
                            .SetEmptyResult().Build();

                //返回消息体
                actionContext.Response = new HttpResponseMessage()
                {
                    Content = new StringContent(JsonConvert.SerializeObject(data)),
                    StatusCode = HttpStatusCode.BadRequest
                };
            }
        }
    }
}