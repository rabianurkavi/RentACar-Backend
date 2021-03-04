using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        //IServiceCollection bizim apimizin servis bağımlılıklarını eklediğimiz ya da araya girmesini sitediğimiz servislerin koleksiyonun ta kendisidir.
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }
            return ServiceTool.Create(serviceCollection);//startupta bunu yazdığımızda geçici bir çözümdü şimdi istediğimiz kadar module ekleyebiliriz.
        }
    }
}
