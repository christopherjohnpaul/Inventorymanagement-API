using Microsoft.AspNetCore.Http;
using ModelLayer;
using System.IdentityModel.Tokens.Jwt;

namespace InterfaceLayer.JWTAuth
{
    public interface IJWTAuth
    {
        JwtSecurityToken GenerateToken(UserInfo userInfo);
        UserInfo ResolveUser(HttpContext context);
    }
}
