using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator: AbstractValidator<CarBrand>
    {
        public BrandValidator()
        {
            RuleFor(p => p.BrandName).MinimumLength(3);
            RuleFor(p => p.BrandName).NotEmpty();
        }
    }
}
