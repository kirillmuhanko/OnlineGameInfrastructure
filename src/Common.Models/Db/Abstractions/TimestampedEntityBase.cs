using MongoDB.Bson.Serialization.Attributes;

namespace Common.Models.Db.Abstractions;

public abstract class TimestampedEntityBase : EntityBase
{
    [BsonElement("createdAt")] public DateTime CreatedAt { get; set; }

    [BsonElement("updatedAt")] public DateTime UpdatedAt { get; set; }
}