using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class MemberValidator:AbstractValidator<Member>
    {
        public MemberValidator() 
        {
            RuleFor(m=>m.MemberName).NotEmpty();
            RuleFor(m => m.MemberSurname).NotEmpty();
            RuleFor(m=>m.MemberPhoneNumber).NotEmpty().MaximumLength(10);
            RuleFor(m=>m.MemberEmail).NotEmpty().EmailAddress();
        }

    }
}
