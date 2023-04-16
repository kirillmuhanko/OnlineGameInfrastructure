using Common.Models.Database.Entities;
using MongoDB.Bson;

namespace Common.Repository.Database.Abstractions;

public interface IRepositoryBase<TEntity> where TEntity : EntityBase
{
    Task<TEntity> GetByIdAsync(ObjectId id);

    Task InsertAsync(TEntity entity);

    Task UpdateAsync(TEntity entity);

    Task DeleteAsync(TEntity entity);
}