using eSocial.Shared.ValueObjects;
using MediatR;

namespace eSocial.Shared.Mediator;

public interface IAPIRequest : IRequest<APIResponse>
{
    
}

public interface IAPIRequest<TResponse> : IRequest<APIResponse<TResponse>>
{
    
}