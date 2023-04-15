using System.Reflection;
using Common.Core.DependencyInjection.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Core.DependencyInjection.Extensions;

public static class DependencyInjectionExtensions
{
    private static readonly List<Type> AbstractionExclusionList = new()
    {
        typeof(IDisposable),
        typeof(IAsyncDisposable)
    };

    public static void Scan(this IServiceCollection services, IEnumerable<Assembly> assemblies)
    {
        foreach (var assembly in assemblies)
            services.AddServicesFromAssembly(assembly);
    }

    private static void AddServicesFromAssembly(this IServiceCollection services, Assembly assembly)
    {
        var implementations = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && t.GetCustomAttribute<LifetimeAttributeBase>() != null)
            .ToList();

        implementations.ForEach(i =>
        {
            var transient = i.GetCustomAttribute<TransientLifetimeAttribute>();
            var scoped = i.GetCustomAttribute<ScopedLifetimeAttribute>();
            var singleton = i.GetCustomAttribute<SingletonLifetimeAttribute>();

            var abstractions = i.GetInterfaces()
                .Where(a => !AbstractionExclusionList.Contains(a))
                .ToList();

            abstractions.ForEach(a =>
            {
                if (transient != null)
                    services.AddTransient(a, i);
                else if (scoped != null)
                    services.AddScoped(a, i);
                else if (singleton != null)
                    services.AddSingleton(a, i);
            });
        });
    }
}