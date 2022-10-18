using TPI_UNLAM_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TPI_UNLAM_Backend.Servicios.Interfaces;

namespace TPI_UNLAM_Backend.Servicios
{
    public class AppSharedFunction : IAppSharedFunction
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _contextAccessor;

        public AppSharedFunction(IConfiguration configuration, IHttpContextAccessor contextAccessor)
        {
            _configuration = configuration;
            _contextAccessor = contextAccessor;
        }
        public UserTokenDto BuildTokenUsuario(string usuario, string password )
        {
            var claims = new[]{
                    new Claim("usuario", usuario.ToUpper()),
                    new Claim("password", password.ToUpper()),
                    };
      
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            // Tiempo de expiración del token. En nuestro caso lo hacemos de una hora.
            var expiration = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["jwt:expireMin"]));
            JwtSecurityToken token = new JwtSecurityToken(
            issuer: null,
            audience: null,
            claims: claims,
            expires: expiration,
            signingCredentials: creds);
            return new UserTokenDto()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }

        public string GetUsuarioPorToken()
        {
            var claimsIdentity = _contextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var valor = claimsIdentity.FindFirst("usuario")?.Value;
            return valor;
        }
    }
}
