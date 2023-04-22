using AutoMapper;
using Common.Core.Mapping.Contracts;
using Common.Models.DependencyInjection.Attributes;

namespace Common.Core.Mapping.Implementations;

[SingletonLifetime]
public class ModelMapper : IModelMapper
{
    private readonly IMapper _mapper;

    public ModelMapper(IMapper mapper)
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