using System.Reflection;
using AutoMapper;
using Common.Core.Mapping.Contracts;
using Common.Core.Mapping.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Core.Mapping.Extensions;

public static class ModelMapperExtensions
{
    public static void AddModelMapper(this IServiceCollection services, IEnumerable<Assembly> assemblies)
    {
        var mappingConfig = new MapperConfiguration(mc =>
        {
            foreach (var assembly in assemblies)
                mc.AddMaps(assembly);
        });

        var mapper = mappingConfig.CreateMapper();
        services.AddSingleton(mapper);
        services.AddSingleton<IModelMapper, ModelMapper>();
    }
}