using AutoMapper;
using eSocial.Application.Contracts;
using eSocial.Domain.UserAggregate;
using eSocial.Shared.Constants;
using eSocial.Shared.Extensions;
using eSocial.Shared.Mediator;
using eSocial.Shared.ValueObjects;
using FluentValidation;

namespace eSocial.Application.Features.FeatureUser.Commands;

public class CreateUserCommand : IAPIRequest
{
    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public string Email { get; set; } = default!;

    public string Password { get; set; } = default!;
}

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.Email).NotEmpty().Matches(RegexConstants.EmailRegex);
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
    }
}

public class CreateUserCommandHandler(IUserService userService, IMapper mapper) : IAPIRequestHandler<CreateUserCommand>
{
    public async Task<APIResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = mapper.Map<User>(request);
        user.PasswordHash = request.Password.ToSha256();
        await userService.CreateUserAsync(user);
        return new APIResponse().IsSuccess("Tạo người dùng thành công");
    }
}