using eSocial.Shared.ValueObjects;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;

namespace eSocial.Infrastructure.Mongo;

public interface IMongoContext
{
    IMongoCollection<T> Collection<T>();
}

public class MongoContext : IMongoContext
{
    private readonly IMongoDatabase _database;
    
    public MongoContext(AppSettings appSettings, ILogger<MongoContext> logger)
    {
        var settings = MongoClientSettings.FromConnectionString(appSettings.MongoConfig.ConnectionString);
        settings.ClusterConfigurator = builder =>
        {
            builder.Subscribe<CommandStartedEvent>(e =>
            {
                logger.LogInformation($"Executed mongo driver command {e.CommandName}: {@e.Command.ToJson()}");
            });
        };
        var client = new MongoClient(settings);
        _database = client.GetDatabase(appSettings.MongoConfig.DatabaseName);
    }

    public IMongoCollection<T> Collection<T>() => _database.GetCollection<T>(typeof(T).Name);
}