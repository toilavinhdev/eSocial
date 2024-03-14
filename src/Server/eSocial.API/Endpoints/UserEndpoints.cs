using eSocial.Application.Features.FeatureUser.Commands;
using eSocial.Application.Features.FeatureUser.Queries;
using eSocial.Shared.ValueObjects;
using MediatR;

namespace eSocial.API.Endpoints;

public class UserEndpoints : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/user").WithTags("User");

        group.MapPost("/sign-up", (CreateUserCommand command, IMediator mediator) => mediator.Send(command));

        group.MapPost("/sign-in", (SignInCommand command, IMediator mediator) => mediator.Send(command));
        
        group.MapGet("/me", (IMediator mediator) => mediator.Send(new GetMeQuery()));
    }
}