using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        //burası bütün methotların çatıdı gettall,get,getbycategory,add,delete..bunların hepsi aşağıdaki kurallardan geçecek tek tek yazmaktan kurtuluyoruz.
        //bunların içi boş validationu doldurduktan sonra onbeforea çalaıştırcaz.
        protected virtual void OnBefore(IInvocation invocation) { }//ınvocation method demektir yani add delete update onun yerine geçer
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);//methodun başında çalışır
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);//genelde onbefore onexception kullanırız diğerleride kullanılabilir.
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);//method başarılı olduğunda
                }
            }
            OnAfter(invocation);//methodttan sonra
        }
    }
}
