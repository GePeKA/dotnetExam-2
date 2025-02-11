using Domain.Entities;
using Main.Infrastructure.Options;
using Main.Infrastructure.Services.Abstractions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Main.Infrastructure.Services.Implementations
{
    public class TokenService(IOptionsMonitor<JwtOptions> jwtOptionsMonitor): ITokenService
	{
		private JwtOptions _jwtOptions = jwtOptionsMonitor.CurrentValue;

        public string GenerateJwtAccessToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtOptions.Key);
            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                [
                    new Claim(ClaimTypes.Name, user.UserName)
                ]),

                Expires = DateTime.UtcNow.AddHours(_jwtOptions.AccessTokenLifetimeInHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(descriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
