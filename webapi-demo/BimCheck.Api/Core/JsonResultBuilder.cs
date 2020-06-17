using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BimCheck.Api.Core
{
    /// <summary>
    /// JsonResult建造者
    /// </summary>
    public class JsonResultBuilder
    {
        /// <summary>
        /// 内部持有对象
        /// </summary>
        private JsonResult jsonResult;

        /// <summary>
        /// 构造函数
        /// </summary>
        public JsonResultBuilder()
        {
            this.jsonResult = new JsonResult();
        }

        /// <summary>
        /// 设置错误代码
        /// </summary>
        /// <param name="code">错误代码</param>
        /// <returns></returns>
        public JsonResultBuilder SetCode(int code)
        {
            jsonResult.code = code;
            return this;
        }

        /// <summary>
        /// 设置错误信息
        /// </summary>
        /// <param name="msg">错误信息</param>
        /// <returns></returns>
        public JsonResultBuilder SetMessage(string msg)
        {
            jsonResult.msg = msg;
            return this;
        }

        /// <summary>
        /// 设置业务数据
        /// </summary>
        /// <param name="result">业务数据</param>
        /// <returns></returns>
        public JsonResultBuilder SetResult(object result)
        {
            jsonResult.result = new
            {
                data = result
            };
            return this;
        }

        /// <summary>
        /// 设置带总数的业务数据
        /// </summary>
        /// <param name="result">业务数据</param>
        /// <param name="count">总数</param>
        /// <returns></returns>
        public JsonResultBuilder SetResult(object result, long count)
        {
            jsonResult.result = new
            {
                count,
                data = result
            };
            return this;
        }

        /// <summary>
        /// 设置空的业务数据
        /// </summary>
        /// <returns></returns>
        public JsonResultBuilder SetEmptyResult()
        {
            jsonResult.result = new { };
            return this;
        }

        /// <summary>
        /// 返回实例
        /// </summary>
        /// <returns></returns>
        public JsonResult Build()
        {
            return jsonResult;
        }
    }
}