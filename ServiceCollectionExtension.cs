using Microsoft.Extensions.DependencyInjection;
using Castle.DynamicProxy;
namespace ronaspet.CoreProxy
{
public static class ServiceCollectionExtension
{
    public static IServiceCollection AddSingletonWithProxy<IT, T, TI>(this IServiceCollection services)
    where T : class, new()
    where IT : class
    where TI : class, IInterceptor
    {
        services.AddSingleton<T>();
        services.AddSingleton<TI>();
        services.AddSingleton<InterfaceProxyFactory<IT, T, TI>>();
        services.AddSingleton<IT>((ctx) =>
            InterfaceProxyFactory<IT, T, TI>.CreateInterfaceProxy(ctx));
        return services;
    }

    public static IServiceCollection AddScopedWithProxy<IT, T, TI>(this IServiceCollection services)
    where T : class, new()
    where IT : class
    where TI : class, IInterceptor
    {
        services.AddScoped<T>();
        services.AddScoped<TI>();
        services.AddScoped<InterfaceProxyFactory<IT, T, TI>>();
        services.AddScoped<IT>((ctx) =>
            InterfaceProxyFactory<IT, T, TI>.CreateInterfaceProxy(ctx));
        return services;
    }

    public static IServiceCollection AddTransientWithProxy<IT, T, TI>(this IServiceCollection services)
    where T : class, new()
    where IT : class
    where TI : class, IInterceptor
    {
        services.AddTransient<T>();
        services.AddTransient<TI>();
        services.AddTransient<InterfaceProxyFactory<IT, T, TI>>();
        services.AddTransient<IT>((ctx) =>
            InterfaceProxyFactory<IT, T, TI>.CreateInterfaceProxy(ctx));
        return services;
    }

    public static IServiceCollection AddSingletonWithProxy<T, TI>(this IServiceCollection services)
    where T : class, new()
    where TI : class, IInterceptor
    {
        services.AddSingleton<TI>();
        services.AddSingleton<ClassProxyFactory<T, TI>>();
        services.AddSingleton<T>((ctx) =>
            ClassProxyFactory<T, TI>.CreateClassProxy(ctx));
        return services;
    }

    public static IServiceCollection AddScopedWithProxy<T, TI>(this IServiceCollection services)
    where T : class, new()
    where TI : class, IInterceptor
    {
        services.AddScoped<TI>();
        services.AddScoped<ClassProxyFactory<T, TI>>();
        services.AddScoped<T>((ctx) =>
            ClassProxyFactory<T, TI>.CreateClassProxy(ctx));
        return services;
    }

    public static IServiceCollection AddTransientWithProxy<T, TI>(this IServiceCollection services)
    where T : class, new()
    where TI : class, IInterceptor
    {
        services.AddTransient<TI>();
        services.AddTransient<ClassProxyFactory<T, TI>>();
        services.AddTransient<T>((ctx) =>
            ClassProxyFactory<T, TI>.CreateClassProxy(ctx));
        return services;
    }
}
}