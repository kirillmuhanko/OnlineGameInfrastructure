namespace Common.Core.Mapping.Abstractions;

public interface IModelMapper
{
    TDestination Map<TSource, TDestination>(TSource source);

    TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
}