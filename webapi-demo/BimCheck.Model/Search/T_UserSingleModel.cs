using BimCheck.Common;
using FluentValidation;
using FluentValidation.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BimCheck.Model.Search
{
    /// <summary>
    /// 用户查询实体
    /// </summary>
    [Validator(typeof(T_UserSingleModelValidator))]
    public class T_UserSingleModel : BaseModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [JsonProperty("password")]
        public string Password { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        [JsonProperty("mobile")]
        public string Mobile { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }
    }

    public class T_UserSingleModelValidator : AbstractValidator<T_UserSingleModel>
    {
        public T_UserSingleModelValidator()
        {
            RuleFor(n => n.Password).NotNull().NotEmpty().WithMessage(Errors._1004).WithErrorCode("1004");
            RuleFor(n => n.Password).Length(6, 32).WithMessage(Errors._1008).WithErrorCode("1008");
            RuleFor(n => n.Email).Custom((x, y) =>
            {
                if (!string.IsNullOrEmpty(x))
                {
                    if (!RegexHelper.IsEmail(x))
                    {
                        y.AddFailure(Errors._1005);
                    }
                }
            });
            RuleFor(n => n.Mobile).Custom((x, y) =>
            {
                if (!string.IsNullOrEmpty(x))
                {
                    if (!RegexHelper.IsMobile(x))
                    {
                        y.AddFailure(Errors._1006);
                    }
                }
            });
            RuleFor(n=> n.Username).Custom((x, y) =>
            {
                if (!string.IsNullOrEmpty(x))
                {
                    if (!RegexHelper.IsUsernameCorrect(x))
                    {
                        y.AddFailure(Errors._1007);
                    }
                }
            });
        }
    }
}
