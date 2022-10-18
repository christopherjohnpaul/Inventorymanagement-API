using InterfaceLayer.JWTAuth;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ModelLayer;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace InventoryManagementWebApi
{
    public class JWTAuth : IJWTAuth
    {
        private readonly string _key;
        private readonly IConfiguration _configuration;
        public JWTAuth(string key, IConfiguration configuration)
        {
            this._key = key;
            _configuration = configuration;
        }
        public JwtSecurityToken GenerateToken(UserInfo userInfo)
        {
            //if (!(username.Equals(username) || password.Equals(password)))
            //{
            //    return null;
            //}

            // 1. Create Security Token Handler
            var tokenHandler = new JwtSecurityTokenHandler();

            // 2. Create Private Key to Encrypted
            var tokenKey = Encoding.ASCII.GetBytes(this._key);

            //3. Create JETdescriptor
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim("Id",userInfo.ID.ToString()),
                        new Claim("Email", userInfo.ContactInfo.Email),
                        new Claim("Name",userInfo.ContactInfo.FirstName+ " "+userInfo.ContactInfo.LastName),
                        new Claim("UserType",userInfo.ContactInfo.ContactTypeId.ToString())
                    }),

                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            //4. Create Token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // 5. Return Token from method
            return (JwtSecurityToken)token;
        }

        public UserInfo ResolveUser(HttpContext context)
        {
            UserInfo user = new UserInfo();
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            try
            {
                //var key = _configuration["JWT:Secret"];
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                user = new UserInfo()
                {
                    ID = Convert.ToInt32(jwtToken.Claims.First(x => x.Type == "Id").Value.ToString())
                };
                user.ContactInfo.Email = jwtToken.Claims.First(x => x.Type == "Email").Value.ToString();
                user.ContactInfo.FirstName = jwtToken.Claims.First(x => x.Type == "Name").Value.ToString().Split(" ")[0];
                user.ContactInfo.ContactTypeId = Convert.ToInt32(jwtToken.Claims.First(x => x.Type == "UserType").Value.ToString());
                // attach user to context on successful jwt validation
            }
            catch
            {
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
                return null;
            }
            return user;

        }
        //public void DestroyToken()
        //{
        //    try
        //    {
        //        var token = HttpContext cont.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        //        //var key = _configuration["JWT:Secret"];
        //        var tokenHandler = new JwtSecurityTokenHandler();
        //        var key = Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]);
        //        tokenHandler.ValidateToken(token, new TokenValidationParameters
        //        {
        //            ValidateIssuerSigningKey = true,
        //            IssuerSigningKey = new SymmetricSecurityKey(key),
        //            ValidateIssuer = false,
        //            ValidateAudience = false,
        //            // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
        //            ClockSkew = TimeSpan.Zero
        //        }, out SecurityToken validatedToken);

        //        var jwtToken = (JwtSecurityToken)validatedToken;
        //        var userDetails = jwtToken.Claims.First(x => x.Type == "unique_name").Value.ToString();

        //        // attach user to context on successful jwt validation
        //        context.Items["User"] = userDetails;
        //    }
        //    catch
        //    {
        //        // do nothing if jwt validation fails
        //        // user is not attached to context so request won't have access to secure routes
        //    }
        //}

    }
}
