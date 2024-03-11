using eSocial.Shared.ValueObjects;

namespace eSocial.API.Endpoints;

public class UserEndpoints : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/user").WithTags("User");

        group.MapGet("/sign-in", () => "Test");
    }
}