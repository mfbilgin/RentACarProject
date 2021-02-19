using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Ad).NotEmpty();
            RuleFor(c => c.Ad).MinimumLength(2).WithMessage("Araba ismi en az 2 karakter uzunluğunda olmalıdır.");
            RuleFor(C => C.DailyPrice).NotEmpty();
            RuleFor(C => C.DailyPrice).GreaterThan(0);
        }
    }
}
