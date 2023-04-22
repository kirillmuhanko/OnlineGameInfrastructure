namespace Common.Core.Mapping.Contracts;

public interface IModelMapper
{
    TDestination Map<TSource, TDestination>(TSource source);

    TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
}