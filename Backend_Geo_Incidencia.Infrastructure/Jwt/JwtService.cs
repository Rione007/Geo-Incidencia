using Backend_Geo_Incidencia.Domain.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Infrastructure.Jwt
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJwtToken(Session session)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"];
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];
            var expiresMinutes = Convert.ToDouble(jwtSettings["MinutesToExpiration"]);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
            new Claim("id", session.IdUsuario.ToString()),
            new Claim("email", session.Email)
        }),
                Expires = DateTime.UtcNow.AddMinutes(expiresMinutes),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                ),
                Audience = audience,
                Issuer = issuer
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public Session GetSessionFromToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token.Replace("Bearer ", ""));

            return new Session
            {
                IdUsuario = int.Parse(jwtToken.Claims.FirstOrDefault(c => c.Type == "id")?.Value ?? "0", CultureInfo.InvariantCulture),
                Email = jwtToken.Claims.FirstOrDefault(c => c.Type == "cuenta")?.Value
            };
        }

    }
}
