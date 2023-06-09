using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ronaspet.CoreProxy
{
    public class InterfaceProxyFactory<IT, T, TI> : IProxy<IT>
    where T : class
    where IT : class
    where TI : IInterceptor
    {
        public static IT CreateInterfaceProxy(IServiceProvider ctx)
        {
            var proxyFactory = ctx.GetRequiredService<InterfaceProxyFactory<IT, T, TI>>();
            return proxyFactory.Proxy;
        }

        public IT Proxy { get; set; }
        public InterfaceProxyFactory(T instance, TI interceptor)
        {
            Proxy = (IT)new ProxyGenerator().CreateInterfaceProxyWithTarget(typeof(IT), instance, interceptor);
        }
    }   
}