using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common.Library.regex
{
    public class RegexHelper
    {
        #region 定义正则表达式
        /// <summary>
        /// 匹配手机号码
        /// 例如：13781197556
        /// 或者：18605246589
        /// </summary>
        public const string MOBILE_REGEX = "^1(3|4|5|7|8)\\d{9}$";

        /// <summary>
        /// 匹配电话号码 
        /// 例如：89788005 
        /// 或者：037623235550
        /// </summary>
        public const string TELEPHONE_REGEX = "^[0-9\\-()()]{7,18}$";

        /// <summary>
        /// 匹配邮箱
        /// 例如: lsm1990@gmail.com
        /// 或者: qq559@aliyun.com.cn
        /// </summary>
        public const string EMAIL_REGEX = "\\w[-\\w.+]*@([A-Za-z0-9][-A-Za-z0-9]+\\.)+[A-Za-z]{2,14}";

        /// <summary>
        /// 匹配纳税人识别号
        /// 例如十八位: 510723197709052305 
        /// 例如十五位: 441900692463996, 11010879759954X
        /// 例如二十位: 44282819710802461700
        /// </summary>
        public const string NSRSBH_REGEX = "^[\\d\\w]{15}$|^[\\d\\w]{18}$|^[\\d\\w]{20}$";

        /// <summary>
        /// 匹配社会信用代码
        /// 社会信用代码共18位，包括五个部分，分别是
        /// 1位登记管理部门代码、1位机构类别代码、6位登记管理机关行政区划码、9位主体标识码（组织机构代码）和1位校验码
        /// 例如: 91350200M000000510
        /// </summary>
        public const string SHXYDM_REGEX = "^[\\d\\w]{18}$";

        /// <summary>
        /// 匹配海关代码
        /// 在工商注册地址所在地海关注册后就能获得企业的海关编码，也就是熟称的十位数编码，当然就是十位数了，
        /// 前面4位代表所属关区，第五位是所在区域性质，第六位代表企业性质，后面4位是流水号
        /// 国际上的海关编码是8位，因此这里也保留8位的匹配模式
        /// </summary>
        public const string HGDM_REGEX = "^[\\d\\w]{8}$|^[\\d\\w]{10}$";

        /// <summary>
        /// 匹配用户名中的非法字符
        /// </summary>
        public const string USERNAME_REGEX = "^([\u4e00-\u9fa5]|[0-9]|[a-z]|[A-Z]|[_])+$";

        /// <summary>
        /// 匹配PNG、JPEG或JPG格式的图片
        /// </summary>
        public const string IMAGE_SUFFIX_REGEX = "^.*\\.(jpg|jpeg|png)$";
        #endregion

        #region 校验方法
        /// <summary>
        /// 判断某字符串是否为手机号码
        /// </summary>
        /// <param name="value">某字符串</param>
        /// <returns>
        /// TRUE：是手机号
        /// FALSE：不是手机号
        /// </returns>
        public static bool IsMobile(string value)
        {
            Regex regex = new Regex(MOBILE_REGEX);
            Match m = regex.Match(value);
            if (m.Success)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 判断某字符串是否为电话号码
        /// </summary>
        /// <param name="value">某字符串</param>
        /// <returns>
        /// TRUE：是电话号码
        /// FALSE：不是电话号码
        /// </returns>
        public static bool IsTelelphone(string value)
        {
            Regex regex = new Regex(TELEPHONE_REGEX);
            Match m = regex.Match(value);
            if (m.Success)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 判断一个字符串是否是邮箱
        /// </summary>
        /// <param name="value">某字符串</param>
        /// <returns>
        /// TRUE：是邮箱
        /// FALSE：不是邮箱
        /// </returns>
        public static bool IsEmail(string value)
        {
            Regex regex = new Regex(EMAIL_REGEX);
            Match m = regex.Match(value);
            if (m.Success)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 判断一个字符是否是纳税人识别号
        /// </summary>
        /// <param name="value">某字符串</param>
        /// <returns>
        /// TRUE：是纳税人识别号
        /// FALSE：不是纳税人识别号
        /// </returns>
        public static bool IsNsrsbh(string value)
        {
            Regex regex = new Regex(NSRSBH_REGEX);
            Match m = regex.Match(value);
            if (m.Success)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 判断一个字符是否是社会信用代码
        /// </summary>
        /// <param name="value">某字符串</param>
        /// <returns>
        /// TRUE：是社会信用代码
        /// FALSE：不是社会信用代码
        /// </returns>
        public static bool IsShxydm(string value)
        {
            Regex regex = new Regex(SHXYDM_REGEX);
            Match m = regex.Match(value);
            if (m.Success)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 判断一个字符是否是海关代码
        /// </summary>
        /// <param name="value">某字符串</param>
        /// <returns>
        /// TRUE：是海关代码
        /// FALSE：不是海关代码
        /// </returns>
        public static bool IsHgdm(string value)
        {
            Regex regex = new Regex(HGDM_REGEX);
            Match m = regex.Match(value);
            if (m.Success)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 校验用户名是否满足要求
        /// 只允许中文、英文字母、数字、下划线
        /// </summary>
        /// <param name="value">被校验项</param>
        /// <returns>
        /// TRUE：是合法的用户名
        /// FALSE：不是合法的用户名
        /// </returns>
        public static bool IsUsernameCorrect(string value)
        {
            Regex regex = new Regex(USERNAME_REGEX);
            Match m = regex.Match(value);
            if (m.Success)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 校验图片名字是不是PNG、JPEG、JPG格式
        /// </summary>
        /// <param name="value">被匹配的图片名字，注意要先转换为小写再用正则匹配</param>
        /// <returns>
        /// TRUE：正确的格式
        /// FALSE：错误的格式
        /// </returns>
        public static bool IsImage(string value)
        {
            Regex regex = new Regex(IMAGE_SUFFIX_REGEX);
            Match m = regex.Match(value.ToLower());
            if (m.Success)
            {
                return true;
            }
            return false;
        }

        public static bool IsPlatformCorrect(string value)
        {
            Regex regex = new Regex("^(wx|zfb|qq|sina)$");
            Match m = regex.Match(value.ToLower());
            if (m.Success)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 校验身份证是否合格
        /// </summary>
        /// <param name="idNumber"></param>
        /// <returns></returns>
        public static bool IsIdentityCardNumber(string idNumber)
        {
            if (idNumber.Length == 18)
            {
                bool check = CheckIDCard18(idNumber);
                return check;
            }
            else
            {
                return false;
            }
        }

        /// <summary>  
        /// 18位身份证号码验证  
        /// </summary>  
        /// <param name="idNumber"></param>  
        /// <returns></returns>  
        private static bool CheckIDCard18(string idNumber)
        {
            long n = 0;
            if (long.TryParse(idNumber.Remove(17), out n) == false || n < Math.Pow(10, 16) || long.TryParse(idNumber.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false;//数字验证    
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(idNumber.Remove(2)) == -1)
            {
                return false;//省份验证    
            }
            string birth = idNumber.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证    
            }
            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            char[] Ai = idNumber.Remove(17).ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
            }
            int y = -1;
            Math.DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != idNumber.Substring(17, 1).ToLower())
            {
                return false;//校验码验证    
            }
            return true;//符合GB11643-1999标准    
        }
        #endregion

        #region 脱敏方法
        public static string HiddenMobile(string mobile)
        {
            return Regex.Replace(mobile, @"^(\d{3})\d+(\d{4})$", "$1****$2");
        }

        public static string HiddenEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return string.Empty;
            }
            int index = email.IndexOf("@");
            if (index <= 2)
            {
                return email;
            }
            else
            {
                string suffix = email.Substring(index);
                return email.Substring(0, 2) + "****" + suffix;
            }
        }

        /// <summary>
        /// 将用户真实姓名脱敏
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string HiddenName(string name)
        {
            char[] strs = name.ToCharArray();
            for (int i = 0; i < strs.Length - 1; i++)
            {
                strs[i] = '*';
            }
            return new string(strs);
        }

        /// <summary>
        /// 将身份证号码脱敏
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string HiddenIdentityCardNumber(string num)
        {
            char[] strs = num.ToCharArray();
            for (int i = 6; i < strs.Length; i++)
            {
                strs[i] = '*';
            }
            return new string(strs);
        }
        #endregion
    }
}
