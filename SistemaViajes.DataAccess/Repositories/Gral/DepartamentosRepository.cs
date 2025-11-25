using Dapper;
using SistemaViajes.Models.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaViajes.DataAccess.Repositories.Gral
{
    public class DepartamentosRepository
    {
        public IEnumerable<DepartamentosDTO> List()
        {
            using var db = new SqlConnection(SistemaViajesContext.ConnectionString);
            var result = db.Query<DepartamentosDTO>(ScriptDatabase.SP_Departamentos_Listar, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return result;
        }



    }
}
