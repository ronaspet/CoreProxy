using System;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;

namespace ronaspet.CoreProxy
{
    public class ClassProxyFactory<T, TI>
    where T : class, new()
    where TI : IInterceptor
    {
        public static T CreateClassProxy(IServiceProvider ctx)
        {
            var proxyFactory = ctx.GetRequiredService<ClassProxyFactory<T, TI>>();
            return (T)proxyFactory.Proxy;
        }

        public T Proxy { get; set; }
        public ClassProxyFactory(T instance, TI interceptor)
        {
            Proxy = (T)(new ProxyGenerator().CreateClassProxyWithTarget(typeof(T), instance, interceptor));
        }
    }   
}