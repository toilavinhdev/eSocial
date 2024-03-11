using Microsoft.AspNetCore.Routing;

namespace eSocial.Shared.ValueObjects;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}