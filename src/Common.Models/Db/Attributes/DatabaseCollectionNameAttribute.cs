namespace Common.Models.Db.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class DatabaseCollectionNameAttribute : Attribute
{
    public string CollectionName { get; }

    public DatabaseCollectionNameAttribute(string collectionName)
    {
        CollectionName = collectionName;
    }
}