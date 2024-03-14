using eSocial.Shared.Exceptions;
using FluentValidation;
using MediatR;

namespace eSocial.Shared.Mediator;

public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var failures = validators
            .Select(v => v.Validate(request))
            .SelectMany(result => result.Errors)
            .Where(error => error != null)
            .ToList();
        
        if (failures.Count == 0) return await next();

        throw new BadRequestException(string.Join(";", failures.Select(x => x.ErrorMessage)));
    }
}