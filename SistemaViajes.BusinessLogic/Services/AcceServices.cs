using Microsoft.IdentityModel.Tokens;
using SistemaViajes.BusinessLogic.Configuration;
using SistemaViajes.DataAccess.Repositories.Acce;
using SistemaViajes.DataAccess.Repositories.Gral;
using SistemaViajes.Models.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SistemaViajes.BusinessLogic.Services
{
    public class AcceServices
    {
        private readonly UsuariosRepository _usuariosRepository;

        public AcceServices(UsuariosRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }

        #region Usuarios
        public ServiceResult Login(LoginRequestDTO loginRequest)
        {
            var result = new ServiceResult();
            try
            {
                // Validaciones
                if (loginRequest == null)
                    return result.BadRequest("Login data is required");
                if (string.IsNullOrWhiteSpace(loginRequest.Usua_Usuario))
                    return result.BadRequest("User is required");
                if (string.IsNullOrWhiteSpace(loginRequest.Usua_Clave))
                    return result.BadRequest("Password is required");

                var loginResponse = _usuariosRepository.Login(loginRequest);

                if (loginResponse == null)
                    return result.Error("Error connecting to database");

                switch (loginResponse.Resultado)
                {
                    case "LOGIN_EXITOSO":
                        var token = GenerateJwtToken(loginResponse);
                        var jwtResponse = new JwtResponseDTO
                        {
                            token = token,
                            Usua_Id = loginResponse.Usua_Id,
                            Usua_Usuario = loginResponse.Usua_Usuario,
                            Role_Id = loginResponse.Role_Id,
                            Role_Descripcion = loginResponse.Role_Descripcion,
                            expires_at = DateTime.UtcNow.AddHours(JwtSettings.ExpirationHours)
                        };
                        return result.Ok(jwtResponse);

                    case "ERROR":
                        result.Unauthorized(loginResponse.Mensaje);
                        result.Data = new
                        {
                            Code = loginResponse.Resultado,
                            Message = loginResponse.Mensaje
                        };
                        return result;

                    case "ERROR_SERVIDOR":
                        return result.Error(loginResponse.Mensaje);

                    default:
                        return result.Error("Unknown login result");
                }
            }
            catch (Exception ex)
            {
                return result.Error($"Unexpected error during login: {ex.Message}");
            }
        }

        private string GenerateJwtToken(LoginResponseDTO loginResponse)
        {
            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(JwtSettings.Key)
            );
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, loginResponse.Usua_Id.ToString()),
        new Claim(ClaimTypes.Name, loginResponse.Usua_Usuario),
        new Claim("Role_Id", loginResponse.Role_Id.ToString()),
        new Claim(ClaimTypes.Role, loginResponse.Role_Descripcion)
    };

            var token = new JwtSecurityToken(
                issuer: JwtSettings.Issuer,
                audience: JwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(JwtSettings.ExpirationHours),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        #endregion
    }
}
