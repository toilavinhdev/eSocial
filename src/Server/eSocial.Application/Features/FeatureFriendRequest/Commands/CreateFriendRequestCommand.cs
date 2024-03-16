using AutoMapper;
using eSocial.Application.Contracts;
using eSocial.Domain.FriendRequestAggregate;
using eSocial.Domain.UserAggregate;
using eSocial.Shared.Mediator;
using eSocial.Shared.ValueObjects;
using FluentValidation;

namespace eSocial.Application.Features.FeatureFriendRequest.Commands;

public class CreateFriendRequestCommand : IAPIRequest
{
    public string FromUserId { get; set; } = default!;

    public string ToUserId { get; set; } = default!;
}

public class CreateFriendRequestCommandValidator : AbstractValidator<CreateFriendRequestCommand>
{
    public CreateFriendRequestCommandValidator()
    {
        RuleFor(x => x.FromUserId).NotEmpty();
        RuleFor(x => x.ToUserId).NotEmpty();
    }
}

public class CreateFriendRequestCommandHandler(IFriendRequestService friendRequestService,
    IMapper mapper) : IAPIRequestHandler<CreateFriendRequestCommand>
{
    public async Task<APIResponse> Handle(CreateFriendRequestCommand request, CancellationToken cancellationToken)
    {
        var document = mapper.Map<FriendRequest>(request);
        document.Accepted = false;
        await friendRequestService.CreateAsync(document);
        return new APIResponse().IsSuccess();
    }
}