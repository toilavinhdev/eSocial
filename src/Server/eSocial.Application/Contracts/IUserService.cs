using eSocial.Domain.UserAggregate;
using eSocial.Shared.Services;

namespace eSocial.Application.Contracts;

public interface IUserService : IBaseService
{
    Task CreateUserAsync(User user);
    Task<User> GetUserAsync(string id);
    Task<string> SignInAsync(string email, string password);
}