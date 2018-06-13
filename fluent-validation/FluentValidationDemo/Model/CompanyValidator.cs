using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentValidationDemo.Model
{
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(n => n.ID).NotNull().NotEmpty().WithMessage(ResourceMessage.ERROR01).WithErrorCode("ERROR01");
            RuleFor(n => n.CompanyName).NotNull().NotEmpty().WithMessage(ResourceMessage.ERROR02).WithErrorCode("ERROR02");
            RuleFor(n => n.CompanyName).Length(4, 50).WithMessage(ResourceMessage.ERROR03).WithErrorCode("ERROR03");
            RuleFor(n => n.CompanyCode).Matches(RegexExpression.REGEX_01).WithMessage(ResourceMessage.ERROR04).WithErrorCode("ERROR04");
            RuleFor(n => n.SocialNumber).Matches(RegexExpression.REGEX_02).WithMessage(ResourceMessage.ERROR05).WithErrorCode("ERROR04");
            RuleFor(n => n.TaxNumber).Matches(RegexExpression.REGEX_03).WithMessage(ResourceMessage.ERROR06).WithErrorCode("ERROR06");
            RuleFor(n => n.Mobile).Matches(RegexExpression.REGEX_04).WithMessage(ResourceMessage.ERROR07).WithErrorCode("ERROR07");
            RuleFor(n => n.Email).EmailAddress().WithMessage(ResourceMessage.ERROR08).WithErrorCode("ERROR08");
            RuleFor(n => n.Start).LessThan(n => n.End).WithMessage(ResourceMessage.ERROR09).WithErrorCode("ERROR09");
        }
    }
}
