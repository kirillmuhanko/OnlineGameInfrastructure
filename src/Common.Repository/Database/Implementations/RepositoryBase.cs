using Common.Models.Database.Entities;
using Common.Repository.Database.Abstractions;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Common.Repository.Database.Implementations;

public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
{
    private readonly IMongoCollection<TEntity> _collection;

    protected RepositoryBase(IDatabaseContextBase databaseContextBase)
    {
        _collection = databaseContextBase.GetCollection<TEntity>();
    }

    public virtual async Task<TEntity> GetByIdAsync(ObjectId id)
    {
        var filter = Builders<TEntity>.Filter.Eq(x => x.Id, id);
        var entity = await _collection.Find(filter).SingleOrDefaultAsync();
        return entity;
    }

    public virtual async Task InsertAsync(TEntity entity)
    {
        if (entity is TimestampedEntityBase timestampedEntity)
            timestampedEntity.CreatedAt = DateTime.UtcNow;

        await _collection.InsertOneAsync(entity);
    }

    public virtual async Task UpdateAsync(TEntity entity)
    {
        if (entity is TimestampedEntityBase timestampedEntity)
            timestampedEntity.UpdatedAt = DateTime.UtcNow;

        var filter = Builders<TEntity>.Filter.Eq(x => x.Id, entity.Id);
        await _collection.ReplaceOneAsync(filter, entity);
    }

    public virtual async Task DeleteAsync(TEntity entity)
    {
        var filter = Builders<TEntity>.Filter.Eq(x => x.Id, entity.Id);
        await _collection.DeleteOneAsync(filter);
    }
}