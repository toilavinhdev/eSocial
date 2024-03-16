using eSocial.Shared.ValueObjects;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace eSocial.Domain.UserAggregate;

public class User : TrackingDocument
{
    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public string FullName => $"{FirstName} {LastName}";

    public string Email { get; set; } = default!;

    public string PasswordHash { get; set; } = default!;

    public string? AvatarUrl { get; set; }
    
    [BsonRepresentation(BsonType.ObjectId)]
    public List<string>? FriendIds { get; set; }
}