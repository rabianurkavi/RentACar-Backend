using Business.Constants;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');//rollerimiz virgülle ayrılarak geliyor attribute olduğu için split ile onu ayırıp arraye atıyor
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();//injeksiyon alt yapımızı okuyabilmemizi yarayan araç

        }

        protected override void OnBefore(IInvocation invocation)//bu methodun önünde çalıştır mesela productmanagerdakı ekleme methodunun
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();//claim rollerini bul 
            foreach (var role in _roles)//rollerini gez eğer claimlerinin içinde ilgili rol varsa return et yoksa hata ver
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
