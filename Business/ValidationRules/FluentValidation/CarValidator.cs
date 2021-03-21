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
            RuleFor(c => c.BrandName).NotEmpty();
            RuleFor(c => c.BrandName).MinimumLength(2).WithMessage("Marka Adı en az 2 karakter uzunluğunda olmalıdır.");
            RuleFor(C => C.DailyPrice).NotEmpty().WithMessage("Fiyat Boş Olamaz");
            RuleFor(C => C.DailyPrice).GreaterThan(50).WithMessage("Araç 50 TL den Uzun Olamaz");
        }
    }
}
