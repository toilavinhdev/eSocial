using AutoMapper;
using eSocial.Application.Contracts;
using eSocial.Application.Features.FeatureUser.Responses;
using eSocial.Shared.Mediator;
using eSocial.Shared.ValueObjects;

namespace eSocial.Application.Features.FeatureUser.Queries;

public class GetMeQuery : IAPIRequest<GetMeResponse>
{
    
}

public class GetMeQueryHandler(IUserService userService, IMapper mapper) : IAPIRequestHandler<GetMeQuery, GetMeResponse>
{
    public async Task<APIResponse<GetMeResponse>> Handle(GetMeQuery request, CancellationToken cancellationToken)
    {
        var user = await userService.GetUserAsync(userService.GetUserClaimValue()!.Id);
        var data = mapper.Map<GetMeResponse>(user);
        return new APIResponse<GetMeResponse>().IsSuccess(data);
    }
}