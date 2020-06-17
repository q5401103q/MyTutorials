using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace BimCheck.Api.Core
{
    /// <summary>
    /// 全局异常过滤器
    /// </summary>
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        //日志
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            logger.Error(actionExecutedContext.Exception);

            //构造自定义数据格式
            var data = new JsonResultBuilder()
                        .SetCode(JsonResultCode.InteralServerError)
                        .SetMessage("服务器内部处理异常")
                        .SetEmptyResult().Build();

            //返回消息体
            actionExecutedContext.Response = new HttpResponseMessage()
            {
                Content = new StringContent(JsonConvert.SerializeObject(data)),
                StatusCode = HttpStatusCode.InternalServerError
            };
        }
    }
}