using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using System;


namespace InventarioControl.Server.Helpers
{
    public class JwtHelper
    {
        private readonly IConfiguration _configuracion;

        public JwtHelper(IConfiguration configuracion)
        {
            _configuracion = configuracion;
        }

        public string GenerarToken(string email, string rol)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, rol)
            };

            var clave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuracion["Jwt:Clave"]));
            var credenciales = new SigningCredentials(clave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuracion["Jwt:Emisor"],
                audience: _configuracion["Jwt:Audiencia"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credenciales
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
