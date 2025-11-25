using Dapper;
using Microsoft.Data.SqlClient;
using SistemaViajes.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaViajes.DataAccess.Repositories.Gral
{
    public class MunicipiosRepository
    {
        public IEnumerable<MunicipiosDTO> ListarPorDepartamento(string depaCodigo)
        {
            using var db = new SqlConnection(SistemaViajesContext.ConnectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@Depa_Codigo", depaCodigo, System.Data.DbType.String);
            var result = db.Query<MunicipiosDTO>(ScriptDatabase.SP_Municipios_Listar, parameters, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return result;
        }
    }
}
