using eSocial.Domain.MessageAggregate;
using eSocial.Shared.Services;

namespace eSocial.Application.Contracts;

public interface IMessageService : IBaseService
{
    Task<Message> CreateAsync(Message message);
}