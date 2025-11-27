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
    public class ColaboradoresRepository
    {
        public IEnumerable<ColaboradoresDTO> ColaboradoresListar()
        {
            using var db = new SqlConnection(SistemaViajesContext.ConnectionString);
            var result = db.Query<ColaboradoresDTO>(
                ScriptDatabase.SP_Colaboradores_Listar,
                commandType: System.Data.CommandType.StoredProcedure
            ).ToList();

            return result;
        }

        public RequestStatus ColaboradoresInsertar(ColaboradoresDTO item)
        {
            using var db = new SqlConnection(SistemaViajesContext.ConnectionString);
            var parameters = new DynamicParameters();

            parameters.Add("@Colb_Codigo", item.Colb_Codigo);
            parameters.Add("@Colb_Identidad", item.Colb_Identidad);
            parameters.Add("@Colb_NombreCompleto", item.Colb_NombreCompleto);
            parameters.Add("@Colb_Telefono", item.Colb_Telefono);
            parameters.Add("@Colb_Sexo", item.Colb_Sexo);
            parameters.Add("@Usua_Creacion", item.Usua_Creacion);


            var result = db.QueryFirst<RequestStatus>(
                ScriptDatabase.SP_Colaboradores_Insertar,
                parameters,
                commandType: System.Data.CommandType.StoredProcedure
            );

            return result;
        }

        public RequestStatus ColaboradoresActualizar(ColaboradoresDTO item)
        {
            using var db = new SqlConnection(SistemaViajesContext.ConnectionString);
            var parameters = new DynamicParameters();

            parameters.Add("@Colb_Id", item.Colb_Id);
            parameters.Add("@Colb_Codigo", item.Colb_Codigo);
            parameters.Add("@Colb_Identidad", item.Colb_Identidad);
            parameters.Add("@Colb_NombreCompleto", item.Colb_NombreCompleto);
            parameters.Add("@Colb_Telefono", item.Colb_Telefono);
            parameters.Add("@Colb_Sexo", item.Colb_Sexo);
            parameters.Add("@Usua_Modificacion", item.Usua_Modificacion);

            var result = db.QueryFirst<RequestStatus>(
                ScriptDatabase.SP_Colaboradores_Actualizar,
                parameters,
                commandType: System.Data.CommandType.StoredProcedure
            );

            return result;
        }

        public Re​questStatus ColaboradoresEliminar(int id)
        {
            using var db = new SqlConnection(SistemaViajesContext.ConnectionString);
            var parameters = new DynamicParameters();

            parameters.Add("@Colb_Id", id);

            var result = db.QueryFirst<RequestStatus>(
                ScriptDatabase.SP_Colaboradores_Eliminar,
                parameters,
                commandType: System.Data.CommandType.StoredProcedure
            );

            return result;
        }


        public IEnumerable<ColaboradoresDTO> ListarPorSucursal(int sucu_Id)
        {
            using var db = new SqlConnection(SistemaViajesContext.ConnectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@Sucu_Id", sucu_Id);

            var result = db.Query<ColaboradoresDTO>(
                ScriptDatabase.SP_Colaboradores_ListarPorSucursal,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }
    }
}
