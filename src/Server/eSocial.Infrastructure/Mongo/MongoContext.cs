using eSocial.Shared.ValueObjects;
using MongoDB.Driver;

namespace eSocial.Infrastructure.Mongo;

public interface IMongoContext
{
    IMongoCollection<T> Collection<T>();
}

public class MongoContext : IMongoContext
{
    private readonly IMongoDatabase _database;
    
    public MongoContext(AppSettings appSettings)
    {
        var client = new MongoClient(appSettings.MongoConfig.ConnectionString);
        _database = client.GetDatabase(appSettings.MongoConfig.DatabaseName);
    }

    public IMongoCollection<T> Collection<T>() => _database.GetCollection<T>(typeof(T).Name);
}