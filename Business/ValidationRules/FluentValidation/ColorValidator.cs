using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(col => col.ColorName).NotEmpty();
            RuleFor(col => col.ColorName).MinimumLength(2).WithMessage("Renk adı en az 2 karakter olmalıdır");
        }
    }
}
