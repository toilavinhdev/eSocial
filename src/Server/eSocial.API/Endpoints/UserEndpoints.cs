using eSocial.Shared.ValueObjects;

namespace eSocial.API.Endpoints;

public class UserEndpoints : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/user").WithTags("User");

        group.MapGet("/api/v1/sign-in", () => "Test");
    }
}