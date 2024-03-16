using eSocial.Shared.ValueObjects;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace eSocial.Domain.MessageAggregate;

public class Message : TrackingDocument
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string FromId { get; set; } = default!;

    [BsonRepresentation(BsonType.ObjectId)]
    public string ToId { get; set; } = default!;

    public string Content { get; set; } = default!;
    
    [BsonRepresentation(BsonType.ObjectId)]
    public string? ReplyMessageId { get; set; }
    
    public MessageType Type { get; set; }
}

public enum MessageType
{
    Text = 1,
    Image
}