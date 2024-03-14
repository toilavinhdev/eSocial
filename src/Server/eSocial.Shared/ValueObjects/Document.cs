using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace eSocial.Shared.ValueObjects;

public abstract class Document
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = default!;
}

public abstract class TrackingDocument : Document
{
    public DateTimeOffset CreatedAt { get; set; }

    public string? CreatedBy { get; set; }
    
    public DateTimeOffset? ModifiedAt { get; set; }
    
    public string? ModifiedBy { get; set; }

    public void MarkCreated(string? createdBy = null)
    {
        CreatedAt = DateTimeOffset.Now;
        CreatedBy = createdBy;
    }
    
    public void MarkModified(string? modifiedBy = null)
    {
        ModifiedAt = DateTimeOffset.Now;
        ModifiedBy = modifiedBy;
    }
}