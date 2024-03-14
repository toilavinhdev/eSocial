using eSocial.Application.Contracts;
using eSocial.Application.Features.FeatureUser.Responses;
using eSocial.Shared.Constants;
using eSocial.Shared.Mediator;
using eSocial.Shared.ValueObjects;
using FluentValidation;

namespace eSocial.Application.Features.FeatureUser.Commands;

public class SignInCommand : IAPIRequest<SignInResponse>
{
    public string Email { get; set; } = default!;

    public string Password { get; set; } = default!;
}

public class SignInCommandValidator : AbstractValidator<SignInCommand>
{
    public SignInCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .Matches(RegexConstants.EmailRegex);
        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(6);
    }
}

public class SignInCommandHandler(IUserService userService) : IAPIRequestHandler<SignInCommand, SignInResponse>
{
    public async Task<APIResponse<SignInResponse>> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        var accessToken = await userService.SignInAsync(request.Email, request.Password);
        return new APIResponse<SignInResponse>().IsSuccess(
            new SignInResponse { AccessToken = accessToken }, 
            "Đăng nhập thành công");
    }
}