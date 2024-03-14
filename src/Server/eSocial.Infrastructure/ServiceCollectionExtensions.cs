using eSocial.Application.Contracts;
using eSocial.Infrastructure.Services;
using eSocial.Shared.Mongo;
using eSocial.Shared.Services;
using Microsoft.Extensions.DependencyInjection;

namespace eSocial.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServiceCollections(this IServiceCollection services)
    {
        services.AddScoped<IMongoContext, MongoContext>();
        services.AddTransient<IBaseService, BaseService>();
        services.AddTransient<IStorageService, StorageService>();
        services.AddScoped<IUserService, UserService>();
        return services;
    }
}