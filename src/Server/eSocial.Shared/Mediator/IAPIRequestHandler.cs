using eSocial.Shared.ValueObjects;
using MediatR;

namespace eSocial.Shared.Mediator;

public interface IAPIRequestHandler<in TRequest> : IRequestHandler<TRequest, APIResponse>
    where TRequest : IRequest<APIResponse>
{
    
}

public interface IAPIRequestHandler<in TRequest, TResponse> : IRequestHandler<TRequest, APIResponse<TResponse>>
    where TRequest : IRequest<APIResponse<TResponse>>
{
    
}