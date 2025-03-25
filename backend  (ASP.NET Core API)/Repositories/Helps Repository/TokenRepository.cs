using Microsoft.IdentityModel.Tokens;
using SmartHealthcare.Interfaces.Helps_Interface;
using SmartHealthcare.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SmartHealthcare.Repositories.Helps_Repository
{
    public class TokenRepository : ITokenRepository
    {
        private readonly JwtOptions _Options;

        public TokenRepository(JwtOptions jwtOptions)
        {
            _Options = jwtOptions;
        }
        public async Task<string> CreateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, user.Name),
                new(ClaimTypes.Email, user.Email)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _Options.Issuer,
                Audience = _Options.Audience,
                Expires = DateTime.UtcNow.AddHours(48),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Options.SigningKey)),
                    SecurityAlgorithms.HmacSha256),

                Subject = new ClaimsIdentity(claims)
            };

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = tokenHandler.WriteToken(securityToken);

            return accessToken;
        }
    }
}
