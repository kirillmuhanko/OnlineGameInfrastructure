using Common.Models.Db.Abstractions;
using MongoDB.Bson;

namespace Common.Repository.Db.Contracts;

public interface IRepositoryBase<TEntity> where TEntity : EntityBase
{
    Task<TEntity> GetByIdAsync(ObjectId id);

    Task InsertAsync(TEntity entity);

    Task UpdateAsync(TEntity entity);

    Task DeleteAsync(TEntity entity);
}