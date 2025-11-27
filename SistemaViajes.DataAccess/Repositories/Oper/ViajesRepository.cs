using Dapper;
using Microsoft.Data.SqlClient;
using SistemaViajes.Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaViajes.DataAccess.Repositories.Oper
{

    public class ViajesRepository
    {
        public IEnumerable<ViajesDTO> ListarViajes()
        {
            using var db = new SqlConnection(SistemaViajesContext.ConnectionString);
            var result = db.Query<ViajesDTO>(
                ScriptDatabase.SP_Viajes_Listar,
                commandType: CommandType.StoredProcedure
            ).ToList();
            return result;
        }

        public RequestStatus ViajeInsertar(ViajesDTO viaje)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Viaj_Fecha", viaje.Viaj_Fecha);
            parameter.Add("@Sucu_Id", viaje.Sucu_Id);
            parameter.Add("@Tran_Id", viaje.Tran_Id);
            parameter.Add("@Usua_Creacion", viaje.Usua_Creacion);

            // Convertir la lista de colaboradores a un DataTable
            var colaboradoresTable = new DataTable();
            colaboradoresTable.Columns.Add("Colb_Id", typeof(int));
            colaboradoresTable.Columns.Add("ClVj_DistanciaKm", typeof(decimal));

            foreach (var colaborador in viaje.Colaboradores)
            {
                colaboradoresTable.Rows.Add(colaborador.Colb_Id, colaborador.ClVj_DistanciaKm);
            }

            parameter.Add("@Colaboradores", colaboradoresTable.AsTableValuedParameter("Oper.ColaboradoresViajeType"));

            try
            {
                using var db = new SqlConnection(SistemaViajesContext.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(
                    ScriptDatabase.SP_Viajes_Insertar,
                    parameter,
                    commandType: CommandType.StoredProcedure
                );
                return result;
            }
            catch (Exception ex)
            {
                return new RequestStatus
                {
                    CodeStatus = 0,
                    MessageStatus = $"Unexpected error: {ex.Message}"
                };
            }
        }
    }
}
