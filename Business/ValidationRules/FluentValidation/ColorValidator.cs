using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator: AbstractValidator<CarColor>
    {
        public ColorValidator()
        {
            RuleFor(p => p.ColorName).MinimumLength(3);
            RuleFor(p => p.ColorName).NotEmpty();
        }
    }
}
