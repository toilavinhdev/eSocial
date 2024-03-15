using eSocial.Shared.ValueObjects;

namespace eSocial.Domain.UserAggregate;

public class FriendRequest : TrackingDocument
{
    public string FromUserId { get; set; } = default!;

    public string ToUserId { get; set; } = default!;

    public bool Accepted { get; set; }
}