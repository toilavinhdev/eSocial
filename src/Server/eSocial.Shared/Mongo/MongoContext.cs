using eSocial.Shared.ValueObjects;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;

namespace eSocial.Shared.Mongo;

public interface IMongoContext
{
    IMongoCollection<T> Collection<T>() where T : Document;
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
                logger.LogInformation($"Mongo driver execute command {e.CommandName}: {@e.Command.ToJson()}");
            });
        };
        var client = new MongoClient(settings);
        _database = client.GetDatabase(appSettings.MongoConfig.DatabaseName);
    }

    public IMongoCollection<T> Collection<T>() where T : Document => _database.GetCollection<T>(typeof(T).Name);
}