using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor//IInterceptor çözülmesi için autofac paketi ekledik
    {
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)//ınvocation method demektir yani add delete update onun yerine geçer
        {

        }
    }
}
