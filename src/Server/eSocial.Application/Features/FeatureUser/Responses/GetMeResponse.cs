namespace eSocial.Application.Features.FeatureUser.Responses;

public class GetMeResponse
{
    public string Id { get; set; } = default!;
    
    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public string FullName => $"{FirstName} {LastName}";

    public string Email { get; set; } = default!;

    public string? AvatarUrl { get; set; }
}