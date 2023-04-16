using AutoMapper;
using Common.Core.Mapping.Abstractions;
using Common.Models.DependencyInjection.Attributes;

namespace Common.Core.Mapping.Implementations;

[SingletonLifetime]
public class ModelMapperFacade : IModelMapper
{
    private readonly IMapper _mapper;

    public ModelMapperFacade(IMapper mapper)
    {
        _mapper = mapper;
    }

    public TDestination Map<TSource, TDestination>(TSource source)
    {
        var result = _mapper.Map<TSource, TDestination>(source);
        return result;
    }

    public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
    {
        var result = _mapper.Map(source, destination);
        return result;
    }
}