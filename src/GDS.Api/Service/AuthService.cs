using GDS.Api.Model;
using GDS.Api.Model.Configuration;
using GDS.Api.Model.Request;
using GDS.Api.Service.Interface;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GDS.Api.Service
{
    public class AuthService : IAuthService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly JwtSection _jwtSection;
        public AuthService(IHttpContextAccessor contextAccessor, IServiceProvider serviceProvider)
        {
            _jwtSection = serviceProvider.GetService<JwtSection>();
            _contextAccessor = contextAccessor;
        }
        public string CreateAccessToken(CreateTokenRequest createTokenRequest)
        {
            var accessToken = CreateToken(
                _jwtSection,
                createTokenRequest);

            return accessToken;
        }

        private static string CreateToken(JwtSection jwtSection, CreateTokenRequest createTokenRequest)
        {
            var keyBytes = Encoding.UTF8.GetBytes(jwtSection.SigningKey);
            var symmetricKey = new SymmetricSecurityKey(keyBytes);

            var signingCredentials = new SigningCredentials(
                symmetricKey,
                SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
    {
        new Claim("user", createTokenRequest.User),
        new Claim("pass", createTokenRequest.Password),
        new Claim("profileFileName", createTokenRequest.ProfileFileName)
    };

            var date = DateTime.Now.AddMinutes(jwtSection.ExpirationMinutes);
            

            var token = new JwtSecurityToken(
                issuer: jwtSection.Issuer,
                audience: jwtSection.Audience,
                claims: claims,
                expires: date,
                signingCredentials: signingCredentials);

            var rawToken = new JwtSecurityTokenHandler().WriteToken(token);
            return rawToken;
        }

        public ProfileSecrets GetProfileSettings()
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
            return new ProfileSecrets() { 
                Password = claims.FindFirst("pass").Value, 
                User = claims.FindFirst("user").Value,
                ProfileFileName = claims.FindFirst("profileFileName").Value
            };
        }
    }
}
