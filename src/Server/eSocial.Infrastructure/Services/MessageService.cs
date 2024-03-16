using eSocial.Application.Contracts;
using eSocial.Domain.MessageAggregate;
using eSocial.Domain.UserAggregate;
using eSocial.Shared.Exceptions;
using eSocial.Shared.Mongo;
using eSocial.Shared.Services;
using Microsoft.AspNetCore.Http;
using MongoDB.Driver;

namespace eSocial.Infrastructure.Services;

public class MessageService(IHttpContextAccessor httpContextAccessor, IMongoContext context) : BaseService(httpContextAccessor), IMessageService
{
    public async Task<Message> CreateAsync(Message message)
    {
        var builder = Builders<User>.Filter;
        var filterUser = builder.Or(
            builder.Eq(x => x.Id, message.FromId), 
            builder.Eq(x => x.Id, message.ToId));
        var checkUsers = await context.Collection<User>().Find(filterUser).CountDocumentsAsync();
        if (checkUsers != 2) throw new InvalidDataException("User friend invalid data");

        var filterMessage = Builders<Message>.Filter.Eq(x => x.ReplyMessageId, message.ReplyMessageId);
        var checkMessage = await context.Collection<Message>().Find(filterMessage).CountDocumentsAsync();
        if (checkMessage != 1) throw new DocumentNotFoundException<Message>(message.ReplyMessageId);

        message.MarkCreated(GetUserClaimValue()?.Id);
        await context.Collection<Message>().InsertOneAsync(message);

        return message;
    }
}