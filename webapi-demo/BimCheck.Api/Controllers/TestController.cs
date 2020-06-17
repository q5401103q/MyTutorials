using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BimCheck.Api.Controllers
{
    public class TestController : ApiController
    {
        [Authorize]
        [HttpGet]
        public HttpResponseMessage SayHello()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("Hello"),
                StatusCode = HttpStatusCode.OK
            };
        }
    }
}
