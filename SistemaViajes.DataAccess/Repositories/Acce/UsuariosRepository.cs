using Dapper;
using Microsoft.Data.SqlClient;
using SistemaViajes.Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaViajes.DataAccess.Repositories.Acce
{
    public class UsuariosRepository
    {
        public LoginResponseDTO Login(LoginRequestDTO loginRequest)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Usua_Usuario", loginRequest.Usua_Usuario);
            parameter.Add("@Usua_Clave", loginRequest.Usua_Clave);

            try
            {
                using var db = new SqlConnection(SistemaViajesContext.ConnectionString);
                var result = db.QueryFirstOrDefault<LoginResponseDTO>(
                    ScriptDatabase.SP_Usuarios_Login,
                    parameter,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
            catch (Exception ex)
            {
                return new LoginResponseDTO
                {
                    Resultado = "ERROR_SERVIDOR",
                    Mensaje = $"Error en el servidor: {ex.Message}"
                };
            }
        }

    }
}
