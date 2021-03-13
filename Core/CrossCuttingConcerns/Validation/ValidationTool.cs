using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);//product için bir doğrulama yapacağım çalışacağım tipte producttır(product)           
            var result = validator.Validate(new ValidationContext<object>(entity));//context yerine productta yazabiliriz.ilgili contexti yani productu doğrula demek
            if (!result.IsValid)//eğer sonuç geçerli değilse hata fırlat
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}

