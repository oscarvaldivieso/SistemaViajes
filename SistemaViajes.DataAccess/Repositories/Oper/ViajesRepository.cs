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
        public IEnumerable<ViajeListDTO> ListarViajes()
        {
            using var db = new SqlConnection(SistemaViajesContext.ConnectionString);

            // Usar QueryMultiple porque el SP devuelve 2 result sets
            using var multi = db.QueryMultiple(
                ScriptDatabase.SP_Viajes_Listar,
                commandType: CommandType.StoredProcedure
            );

            // Leer el primer result set (Viajes con totales)
            var viajes = multi.Read<ViajeListDTO>().ToList();

            // Leer el segundo result set (Colaboradores de cada viaje)
            var colaboradores = multi.Read<ColaboradorViajeDetalleDTO>().ToList();

            // Agrupar colaboradores por Viaj_Id y asignarlos a cada viaje
            var colaboradoresPorViaje = colaboradores
                .GroupBy(c => c.Viaj_Id)
                .ToDictionary(g => g.Key, g => g.ToList());

            // Asignar colaboradores a cada viaje
            foreach (var viaje in viajes)
            {
                if (colaboradoresPorViaje.ContainsKey(viaje.Viaj_Id))
                {
                    viaje.Colaboradores = colaboradoresPorViaje[viaje.Viaj_Id];
                }
            }

            return viajes;
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
