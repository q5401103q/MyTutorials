using BimCheck.Api.Core;
using BimCheck.IBll;
using BimCheck.Model.Search;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BimCheck.Api.Controllers
{
    /// <summary>
    /// 示例用的接口
    /// </summary>
    public class HomeController : ApiController
    {
        /// <summary>
        /// 服务注入
        /// </summary>
        private ITestService _testService;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="testService"></param>
        public HomeController(ITestService testService)
        {
            this._testService = testService;
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="model">请求POCO</param>
        /// <returns></returns>
        [HttpPost]
        //[Authorize]
        public HttpResponseMessage GetStudentsPagination([FromBody]StudentPagedModel model)
        {
            /* 请求示例:
             * { "PageSize":10, "PageIndex":0, "Name":"赵%"}
             */
            var result = _testService.GetStudentsPagination(model);

            var data = new JsonResultBuilder()
                                .SetCode(JsonResultCode.OK)
                                .SetMessage("success")
                                .SetResult(result.Data, result.Count).Build();

            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(data.ToString())
            };
        }

        /// <summary>
        /// 根据ID获取单个学生的详细信息
        /// </summary>
        /// <param name="model">请求POCO</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetStudentById([FromBody]StudentSingleModel model)
        {
            /* 请求示例：
             * { "Id": "11" }
             */
            var result = _testService.GetStudentById(model.Id);

            var data = new JsonResultBuilder()
                                .SetCode(JsonResultCode.OK)
                                .SetMessage("success")
                                .SetResult(result).Build();

            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(data))
            };
        }

        /// <summary>
        /// 根据IDs获取多个学生的详细信息
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetStudentsByIds([FromBody] string json)
        {
            var model = JsonConvert.DeserializeObject<List<dynamic>>(json);

            var result = _testService.GetStudentsByIds(model);

            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(result))
            };
        }

        /// <summary>
        /// 条件筛选学生数据
        /// </summary>
        /// <param name="model">查询数据</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetStudentsByCondition([FromBody]StudentSingleModel model)
        {
            var result = _testService.GetStudentsByCondition(model);

            var data = new JsonResultBuilder()
                                .SetCode(JsonResultCode.OK)
                                .SetMessage("success")
                                .SetResult(result).Build();


            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(data))
            };
        }

        /// <summary>
        /// 获取学生分数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetStudentScore([FromBody]StudentSingleModel model)
        {
            var result = _testService.GetStudentScore(model.Id.ToString());

            var data = new JsonResultBuilder()
                                .SetCode(JsonResultCode.OK)
                                .SetMessage("success")
                                .SetResult(result).Build();


            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(data))
            };
        }

        /// <summary>
        /// 添加学生
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage AddStudent([FromBody]StudentSingleModel model)
        {
#pragma warning disable IDE0059 // 从不使用分配给符号的值
            var result = _testService.AddStudent(model);
#pragma warning restore IDE0059 // 从不使用分配给符号的值

            var data = new JsonResultBuilder()
                                .SetCode(JsonResultCode.OK)
                                .SetMessage("success")
                                .SetEmptyResult().Build();


            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(data))
            };
        }

        /// <summary>
        /// 添加学生
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage UpdateStudent([FromBody]StudentSingleModel model)
        {
#pragma warning disable IDE0059 // 从不使用分配给符号的值
            var result = _testService.UpdateStudent(model);
#pragma warning restore IDE0059 // 从不使用分配给符号的值

            var data = new JsonResultBuilder()
                                .SetCode(JsonResultCode.OK)
                                .SetMessage("success")
                                .SetEmptyResult().Build();


            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(data))
            };
        }

        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage DeleteStudent([FromBody]StudentSingleModel model)
        {
            throw new ArgumentException("无效的请求参数");
#pragma warning disable IDE0059 // 从不使用分配给符号的值
            var result = _testService.DeleteStudent(model);
#pragma warning restore IDE0059 // 从不使用分配给符号的值
            var data = new JsonResultBuilder()
                                .SetCode(JsonResultCode.OK)
                                .SetMessage("success")
                                .SetEmptyResult().Build();


            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(data))
            };
        }
    }
}
