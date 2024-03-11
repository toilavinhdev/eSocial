using System.IdentityModel.Tokens.Jwt;
using eSocial.Shared.ValueObjects;
using Microsoft.AspNetCore.Http;

namespace eSocial.Shared.Services;

public interface IBaseService
{
    UserClaimValue? GetUserClaimValue();
}

public class BaseService(IHttpContextAccessor httpContextAccessor) : IBaseService
{
    public UserClaimValue? GetUserClaimValue()
    {
        var stringValue = httpContextAccessor.HttpContext?.Request.Headers
            .FirstOrDefault(x => x.Key == "Authorization").Value.ToString();
        var accessToken = stringValue?.Split(" ").LastOrDefault();

        if (string.IsNullOrEmpty(accessToken)) return null;
        
        var decodedToken = new JwtSecurityTokenHandler().ReadJwtToken(accessToken);
        
        return new UserClaimValue()
        {
            Id = decodedToken.Claims.FirstOrDefault(x => x.Type.Equals("id"))?.Value 
                 ?? throw new NullReferenceException("Claim type 'id' is required"),
            FullName = decodedToken.Claims.FirstOrDefault(x => x.Type.Equals("fullName"))?.Value
                       ?? throw new NullReferenceException("Claim type 'fullName' is required"),
            Email = decodedToken.Claims.FirstOrDefault(x => x.Type.Equals("email"))?.Value 
                    ?? throw new NullReferenceException("Claim type 'email' is required"),
        };
    }
}