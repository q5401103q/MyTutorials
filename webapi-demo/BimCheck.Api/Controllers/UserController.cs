using BimCheck.Api.Core;
using BimCheck.IBll;
using BimCheck.Model.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BimCheck.Api.Controllers
{
    /// <summary>
    /// 用户服务
    /// </summary>
    public class UserController : ApiController
    {
        /// <summary>
        /// 服务注入
        /// </summary>
        private IUserService _userService;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="userService"></param>
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage LoginByUsername([FromBody]T_UserSingleModel model)
        {
            var result = _userService.LoginByUsername(model);

            var data = new JsonResultBuilder()
                                .SetCode(JsonResultCode.OK)
                                .SetMessage("success")
                                .SetResult(result).Build();

            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(data.ToString())
            };
        }
    }
}
