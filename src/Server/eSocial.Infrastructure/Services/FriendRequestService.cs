using eSocial.Application.Contracts;
using eSocial.Domain.FriendRequestAggregate;
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
        var builder = Builders<FriendRequest>.Filter;
        var filter = builder.Or(
            builder.Eq(x => x.FromUserId, friendRequest.FromUserId), 
            builder.Eq(x => x.ToUserId, friendRequest.ToUserId));

        var checkUsers = await context.Collection<FriendRequest>().Find(filter).CountDocumentsAsync();

        if (checkUsers != 2) throw new InvalidDataException("User friend invalid data");
        
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