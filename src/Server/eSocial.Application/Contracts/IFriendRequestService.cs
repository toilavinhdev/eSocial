using eSocial.Domain.FriendRequestAggregate;
using eSocial.Domain.UserAggregate;
using eSocial.Shared.Services;

namespace eSocial.Application.Contracts;

public interface IFriendRequestService : IBaseService
{
    Task<FriendRequest?> GetAsync(string id);
    Task<FriendRequest> CreateAsync(FriendRequest friendRequest);
    Task RemoveAsync(string id);
}