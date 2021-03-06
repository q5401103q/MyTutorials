﻿using FluentValidation;
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
    /// 时间：2020/6/15 9:51:13
    /// 描述：
    /// </summary>
    [Validator(typeof(StudentSingleModelValidator))]
    public class StudentSingleModel : BaseModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("sex")]
        public string Sex { get; set; }

        [JsonProperty("age")]
        public DateTime? Age { get; set; }
    }

    public class StudentSingleModelValidator : AbstractValidator<StudentSingleModel>
    {
        public StudentSingleModelValidator()
        {
            //校验ID必填
            RuleFor(n => n.Id).NotNull().NotEmpty().WithMessage("1001").WithErrorCode(Errors._1001);
        }
    }
}
