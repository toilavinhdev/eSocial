using System.Security.Claims;
using eSocial.Application.Contracts;
using eSocial.Domain.UserAggregate;
using eSocial.Infrastructure.Mongo;
using eSocial.Shared.Exceptions;
using eSocial.Shared.Extensions;
using eSocial.Shared.Security;
using eSocial.Shared.Services;
using eSocial.Shared.ValueObjects;
using Microsoft.AspNetCore.Http;
using MongoDB.Driver;

namespace eSocial.Infrastructure.Services;

public class UserService(IHttpContextAccessor httpContextAccessor, IMongoContext context, AppSettings appSettings) : BaseService(httpContextAccessor), IUserService
{
    public async Task CreateUserAsync(User user)
    {
        user.MarkCreated();
        await context.Collection<User>().InsertOneAsync(user);
    }

    public async Task<User> GetUserAsync(string id)
    {
        var filter = Builders<User>.Filter.Eq(x => x.Id, id);
        var user = await context.Collection<User>().Find(filter).FirstOrDefaultAsync();
        DocumentNotFoundException<User>.ThrowIfNotFound(user, id);
        return user;
    }

    public async Task<string> SignInAsync(string email, string password)
    {
        var filter = Builders<User>.Filter.Eq(x => x.Email, email);
        var user = await context.Collection<User>().Find(filter).FirstOrDefaultAsync();
        DocumentNotFoundException<User>.ThrowIfNotFound(user, email);

        if (!user.PasswordHash.Equals(password.ToSha256()))
        {
            throw new BadRequestException("Password is incorrect");
        }

        var claims = new List<Claim>
        {
            new("id", user.Id),
            new("fullName", user.FullName),
            new("email", user.Email),
        };

        return JWTBearerProvider.GenerateAccessToken(
            appSettings.JwtConfig.TokenSingingKey,
            claims,
            DateTime.Now.AddMinutes(appSettings.JwtConfig.AccessTokenDurationInMinutes));
    }
}