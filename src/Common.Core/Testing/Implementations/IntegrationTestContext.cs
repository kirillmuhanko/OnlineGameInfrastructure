using System.Reflection;
using Common.Core.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Core.Testing.Implementations;

public class IntegrationTestContext : IDisposable
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IServiceScope _serviceScope;

    public IntegrationTestContext(IEnumerable<Assembly> assemblies)
    {
        var builder = WebApplication.CreateBuilder(Array.Empty<string>());
        builder.Services.Scan(assemblies);
        var app = builder.Build();
        _serviceScope = app.Services.CreateScope();
        _serviceProvider = _serviceScope.ServiceProvider;
    }

    public TService ResolveService<TService>() where TService : class
    {
        var service = _serviceProvider.GetRequiredService<TService>();
        return service;
    }

    public void Dispose()
    {
        _serviceScope.Dispose();
    }
}