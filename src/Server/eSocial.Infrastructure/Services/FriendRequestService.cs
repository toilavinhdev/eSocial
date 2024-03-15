using eSocial.Application.Contracts;
using eSocial.Domain.UserAggregate;
using eSocial.Shared.Exceptions;
using eSocial.Shared.Mongo;
using eSocial.Shared.Services;
using Microsoft.AspNetCore.Http;
using MongoDB.Driver;

namespace eSocial.Infrastructure.Services;

public class FriendRequestService(IHttpContextAccessor httpContextAccessor, 
    IMongoContext context) : BaseService(httpContextAccessor), IFriendRequestService
{
    public async Task<FriendRequest?> GetAsync(string id)
    {
        var filter = Builders<FriendRequest>.Filter.Eq(x => x.Id, id);
        var document = await context.Collection<FriendRequest>().Find(filter).FirstOrDefaultAsync();
        return document;
    }
    
    public async Task<FriendRequest> CreateAsync(FriendRequest friendRequest)
    {
        friendRequest.MarkCreated(GetUserClaimValue()?.Id);
        await context.Collection<FriendRequest>().InsertOneAsync(friendRequest);
        return friendRequest;
    }

    public async Task RemoveAsync(string id)
    {
        var filter = Builders<FriendRequest>.Filter.Eq(x => x.Id, id);
        var result = await context.Collection<FriendRequest>().DeleteOneAsync(filter);
        if (!result.IsAcknowledged) DocumentNotFoundException<FriendRequest>.ThrowIfNotFound(result);
    }
}