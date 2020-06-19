using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BimCheck.Api.Core
{
    public class JsonResultCode
    {
        /// <summary>
        /// 200 OK
        /// </summary>
        public static readonly int OK = 200;
        /// <summary>
        /// 400 BadRequest
        /// </summary>
        public static readonly int BadRequest = 400;
        /// <summary>
        /// 401 Unauthorized
        /// </summary>
        public static readonly int Unauthorized = 401;
        /// <summary>
        /// 403 Forbidden
        /// </summary>
        public static readonly int Forbidden = 403;
        /// <summary>
        /// 404 NotFound
        /// </summary>
        public static readonly int NotFound = 404;
        /// <summary>
        /// 405 NotAllowed
        /// </summary>
        public static readonly int NotAllowed = 405;
        /// <summary>
        /// 408 Timeout
        /// </summary>
        public static readonly int Timeout = 408;
        /// <summary>
        /// 500 InteralServerError
        /// </summary>
        public static readonly int InteralServerError = 500;
    }
}