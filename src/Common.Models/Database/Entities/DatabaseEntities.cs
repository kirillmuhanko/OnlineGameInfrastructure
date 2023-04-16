using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Common.Models.Database.Entities;

public abstract class EntityBase
{
    [BsonId] public ObjectId Id { get; set; }

    public DateTime ObjectIdCreationTime => Id.CreationTime;
}

public abstract class TimestampedEntityBase : EntityBase
{
    [BsonElement("createdAt")] public DateTime CreatedAt { get; set; }

    [BsonElement("updatedAt")] public DateTime UpdatedAt { get; set; }
}