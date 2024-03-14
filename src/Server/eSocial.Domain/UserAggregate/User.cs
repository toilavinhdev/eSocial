using eSocial.Shared.ValueObjects;

namespace eSocial.Domain.UserAggregate;

public class User : TrackingDocument
{
    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public string FullName => $"{FirstName} {LastName}";

    public string Email { get; set; } = default!;

    public string PasswordHash { get; set; } = default!;

    public string? AvatarUrl { get; set; }
}