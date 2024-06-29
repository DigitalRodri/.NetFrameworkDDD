using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Application.Tags
{
    public class RequiresAuthorization : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            string secretKey = "qwertyuiopasdfghjklzxcvbnm123456";
            string jwtToken = actionContext.Request.Headers.Authorization.Parameter;
            var token = new JwtSecurityToken(jwtToken);

            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(secretKey)),
                ValidateIssuer = true,
                ValidIssuer = "Online JWT Builder",
                ValidateAudience = true,
                ValidAudience = "www.example.com",
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            SecurityToken validatedToken;
            var principal = tokenHandler.ValidateToken(jwtToken, validationParameters, out validatedToken);

            return true;
        }
    }
}