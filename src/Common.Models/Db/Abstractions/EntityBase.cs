using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Common.Models.Db.Abstractions;

public abstract class EntityBase
{
    [BsonId] public ObjectId Id { get; set; }

    public DateTime ObjectIdCreationTime => Id.CreationTime;
}