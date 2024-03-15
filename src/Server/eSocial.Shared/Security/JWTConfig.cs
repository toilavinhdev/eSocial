namespace eSocial.Shared.Security;

public class JWTConfig
{
    public string TokenSingingKey { get; set; } = default!;
    
    public int AccessTokenDurationInMinutes { get; set; }
}