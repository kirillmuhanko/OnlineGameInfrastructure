using MongoDB.Driver;

namespace Common.Repository.Database.Abstractions;

public interface IDatabaseContextBase
{
    IMongoCollection<TEntity> GetCollection<TEntity>();
}