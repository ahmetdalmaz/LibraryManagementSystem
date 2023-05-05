using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class AuthorValidator:AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(a=>a.AuthorName).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(a => a.AuthorSurname).NotEmpty().WithMessage("Bu alan boş geçilemez");

        }

    }
}
