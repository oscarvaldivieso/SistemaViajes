using Dapper;
using Microsoft.Data.SqlClient;
using SistemaViajes.Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaViajes.DataAccess.Repositories.Gral
{
    public class TransportistasRepository
    {
        private readonly string _connectionString;

        public TransportistasRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<TransportistasDTO> List()
        {
            using var db = new SqlConnection(_connectionString);
            return db.Query<TransportistasDTO>(
                ScriptDatabase.SP_Transportistas_Listar,
                commandType: CommandType.StoredProcedure
            ).ToList();
        }

        public TransportistasDTO Find(int id)
        {
            using var db = new SqlConnection(_connectionString);
            return db.QueryFirstOrDefault<TransportistasDTO>(
                ScriptDatabase.SP_Transportistas_Buscar,
                new { Tran_Id = id },
                commandType: CommandType.StoredProcedure
            );
        }

        public RequestStatus Insert(TransportistasDTO item)
        {
            using var db = new SqlConnection(_connectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@Tran_Identidad", item.Tran_Identidad);
            parameters.Add("@Tran_NombreCompleto", item.Tran_NombreCompleto);
            parameters.Add("@Tran_Telefono", item.Tran_Telefono);
            parameters.Add("@Tran_TarifaPorKm", item.Tran_TarifaPorKm);
            parameters.Add("@Usua_Creacion", item.Usua_Creacion);

            return db.QueryFirst<RequestStatus>(
                ScriptDatabase.SP_Transportistas_Insertar,
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        public RequestStatus Update(TransportistasDTO item)
        {
            using var db = new SqlConnection(_connectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@Tran_Id", item.Tran_Id);
            parameters.Add("@Tran_Identidad", item.Tran_Identidad);
            parameters.Add("@Tran_NombreCompleto", item.Tran_NombreCompleto);
            parameters.Add("@Tran_Telefono", item.Tran_Telefono);
            parameters.Add("@Tran_TarifaPorKm", item.Tran_TarifaPorKm);
            parameters.Add("@Usua_Modificacion", item.Usua_Modificacion);

            return db.QueryFirst<RequestStatus>(
                ScriptDatabase.SP_Transportistas_Actualizar,
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        public RequestStatus Delete(int id)
        {
            using var db = new SqlConnection(_connectionString);

            return db.QueryFirst<RequestStatus>(
                ScriptDatabase.SP_Transportistas_Eliminar,
                new { Tran_Id = id },
                commandType: CommandType.StoredProcedure
            );
        }
    }

}
