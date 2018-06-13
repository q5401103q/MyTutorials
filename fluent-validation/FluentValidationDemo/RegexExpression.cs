using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentValidationDemo
{
    public class RegexExpression
    {
        public const string REGEX_01 = "^[\\d\\w]{8}$|^[\\d\\w]{10}$";
        public const string REGEX_02 = "^[\\d\\w]{18}$";
        public const string REGEX_03 = "^[\\d\\w]{15}$|^[\\d\\w]{18}$|^[\\d\\w]{20}$";
        public const string REGEX_04 = "^1(3|4|5|7|8)\\d{9}$";
    }
}
