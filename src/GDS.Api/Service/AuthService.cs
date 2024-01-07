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
    public class AuthService : BaseService, IAuthService
    {
        public AuthService(IHttpContextAccessor contextAccessor, IServiceProvider serviceProvider) : base(contextAccessor, serviceProvider)
        {

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

        public ProfileSecrets GetProfileSecrets()
        {
            return GetProfileSecrets();
        }
    }
}
