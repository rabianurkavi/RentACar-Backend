using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.ValidationAspect
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)//attiributeler typle atılır gönderilen validatortype
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))//gönderilen validatortype IValidator değilse o zaman kız
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil.");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//reflection çalışma anında bir şeyleri çalıştırabilmemizi sağlıyor o productvalidatorun instancesını oluştur
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];//productvalidatorun basetypını bul sonra çalışma tipini bul onun generic argumenlerinden ilkini bul
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);//methodun parametrelerini bak validatorların tipine eşit olan parametreleri bul
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);//her birini tek tek gez validationtollu kullanarak
            }
        }
    }
}
