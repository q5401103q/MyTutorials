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
    /// 作者：liuzl 
    /// 时间：2020/6/15 14:19:53
    /// 描述：
    /// </summary>
    [Validator(typeof(StudentPagedModelValidator))]
    public class StudentPagedModel : PagedModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("sex")]
        public string Sex { get; set; }
    }

    public class StudentPagedModelValidator : AbstractValidator<StudentPagedModel>
    {
        public StudentPagedModelValidator()
        {
            //校验ID必填
            RuleFor(n => n.Id).NotNull().NotEmpty().WithMessage(Errors._1001).WithErrorCode("1001");

            //校验页码大于等于0
            RuleFor(n => n.PageIndex).GreaterThanOrEqualTo(0).WithMessage(Errors._1002).WithErrorCode("1002");

            //校验每页记录数大于等于1
            RuleFor(n => n.PageSize).GreaterThanOrEqualTo(1).WithMessage(Errors._1003).WithErrorCode("1003");
        }
    }
}
