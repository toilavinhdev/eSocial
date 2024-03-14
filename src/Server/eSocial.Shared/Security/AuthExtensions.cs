using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace eSocial.Shared.Security;

public static class AuthExtensions
{
    public static IServiceCollection AddJWTBearerAuth(this IServiceCollection services, 
                                                      JwtConfig config, 
                                                      Action<JwtBearerOptions>? jwtOptions = null)
    {
        services
            .AddAuthentication(
                options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
            .AddJwtBearer(
                options =>
                {
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.TokenSingingKey));
                    
                    // defaults
                    options.TokenValidationParameters.IssuerSigningKey = key;
                    options.TokenValidationParameters.ValidateIssuerSigningKey = true;
                    options.TokenValidationParameters.ValidateLifetime = true;
                    options.TokenValidationParameters.ClockSkew = TimeSpan.FromSeconds(60);
                    options.TokenValidationParameters.ValidAudience = null;
                    options.TokenValidationParameters.ValidateAudience = false;
                    options.TokenValidationParameters.ValidIssuer = null;
                    options.TokenValidationParameters.ValidateIssuer = false;
                    
                    jwtOptions?.Invoke(options);

                    // correct any user mistake
                    options.TokenValidationParameters.ValidateAudience = options.TokenValidationParameters.ValidAudience is not null;
                    options.TokenValidationParameters.ValidateIssuer = options.TokenValidationParameters.ValidIssuer is not null;
                });
        
        return services;
    }
}