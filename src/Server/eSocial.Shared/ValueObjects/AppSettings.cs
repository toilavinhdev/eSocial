using eSocial.Shared.Extensions;
using eSocial.Shared.Mongo;
using eSocial.Shared.Security;

namespace eSocial.Shared.ValueObjects;

public class AppSettings
{
    public string Host { get; set; } = default!;

    public StaticFileConfig StaticFileConfig { get; set; } = default!;

    public MongoConfig MongoConfig { get; set; } = default!;
    
    public JWTConfig JWTConfig { get; set; } = default!;
}
