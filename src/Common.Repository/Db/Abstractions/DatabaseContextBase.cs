using System.Reflection;
using Common.Models.Db.Abstractions;
using Common.Models.Db.Attributes;
using Common.Repository.Db.Contracts;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Common.Repository.Db.Abstractions;

public abstract class DatabaseContextBase : IDatabaseContextBase
{
    private readonly IMongoDatabase _database;

    protected DatabaseContextBase(IOptions<DatabaseConnectionOptionsBase> options)
    {
        var client = new MongoClient(options.Value.ConnectionString);
        _database = client.GetDatabase(options.Value.DatabaseName);
    }

    public virtual IMongoCollection<TEntity> GetCollection<TEntity>()
    {
        var attribute = typeof(TEntity).GetCustomAttribute<DatabaseCollectionNameAttribute>();

        if (attribute == null)
            throw new InvalidOperationException(
                $"The entity type '{nameof(TEntity)}' does not have a {nameof(DatabaseCollectionNameAttribute)}.");

        var collection = _database.GetCollection<TEntity>(attribute.CollectionName);
        return collection;
    }
}