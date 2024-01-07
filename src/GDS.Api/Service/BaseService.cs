using GDS.Api.Model.Configuration;
using GDS.Api.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace GDS.Api.Service
{
    public class BaseService(IHttpContextAccessor contextAccessor, IServiceProvider serviceProvider)
    {
        private readonly IHttpContextAccessor _contextAccessor = contextAccessor;
        public readonly JwtSection _jwtSection = serviceProvider.GetService<JwtSection>();
        public ProfileSecrets GetProfileSecrets()
        {
            var token = _contextAccessor.HttpContext.Request.Headers["Authorization"][0].Split(" ")[1];

            var key = Encoding.ASCII.GetBytes(_jwtSection.SigningKey);
            var handler = new JwtSecurityTokenHandler();
            var validations = new TokenValidationParameters
            {
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
            var claims = handler.ValidateToken(token, validations, out var signingCredentials);
            return new ProfileSecrets()
            {
                Password = claims.FindFirst("pass").Value,
                User = claims.FindFirst("user").Value,
                ProfileFileName = claims.FindFirst("profileFileName").Value
            };
        }
    }
}
