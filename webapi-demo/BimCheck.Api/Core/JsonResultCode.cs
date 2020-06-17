using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BimCheck.Api.Core
{
    public class JsonResultCode
    {
        public static readonly int OK = 0;
        public static readonly int BadRequest = 400;
        public static readonly int Unauthorized = 401;
        public static readonly int Forbidden = 403;
        public static readonly int NotFound = 404;
        public static readonly int NotAllowed = 405;
        public static readonly int Timeout = 408;
        public static readonly int InteralServerError = 500;
    }
}