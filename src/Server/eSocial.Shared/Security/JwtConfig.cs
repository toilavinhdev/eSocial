﻿namespace eSocial.Shared.Security;

public class JwtConfig
{
    public string TokenSingingKey { get; set; } = default!;
    
    public int AccessTokenDurationInMinutes { get; set; }
}