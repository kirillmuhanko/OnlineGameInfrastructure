using MongoDB.Driver;

namespace Common.Repository.Db.Contracts;

public interface IDatabaseContextBase
{
    IMongoCollection<TEntity> GetCollection<TEntity>();
}