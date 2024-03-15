using eSocial.Application.Features.FeatureUser.Commands;
using eSocial.Shared.ValueObjects;
using MediatR;

namespace eSocial.API.Endpoints;

public class FriendRequestEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/friend-request").WithTags("Friend Request");

        group.MapPost("/create", (CreateFriendRequestCommand command, IMediator mediator) => mediator.Send(command));
    }
}