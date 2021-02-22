using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            /* classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));//otomatik olarak sistemdeki bütün methodları loga dahil et bir proje düşün üç yıl yazdın ve hiç loglama yok sisteme loglama eklemek istiyorsunuz
            //loglama alt yapısını eklemek için tek yapman gereken bu hareket.Loglama alt yapımız şu an hazır değil ondan dolayı kullanmayacağız.
            */

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
