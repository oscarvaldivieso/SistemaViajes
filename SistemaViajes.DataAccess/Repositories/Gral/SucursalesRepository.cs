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
    public class SucursalesRepository
    {
        public IEnumerable<SucursalesDTO> ListarSucursales()
        {
            using var db = new SqlConnection(SistemaViajesContext.ConnectionString);
            var result = db.Query<SucursalesDTO>(
                ScriptDatabase.SP_Sucursales_Listar,
                commandType: CommandType.StoredProcedure
            ).ToList();

            return result;
        }

        public RequestStatus SucursalInsertar(SucursalesDTO sucursal)
        {
            var parameter = new DynamicParameters();

            parameter.Add("@Sucu_Codigo", sucursal.Sucu_Codigo);
            parameter.Add("@Sucu_Nombre", sucursal.Sucu_Nombre);
            parameter.Add("@Sucu_Direccion", sucursal.Sucu_Direccion);
            parameter.Add("@Muni_Codigo", sucursal.Muni_Codigo);
            parameter.Add("@Usua_Creacion", sucursal.Usua_Creacion);
            parameter.Add("@Sucu_Imagen", sucursal.Sucu_Imagen);

            try
            {
                using var db = new SqlConnection(SistemaViajesContext.ConnectionString);
                // Esto obtiene lo que retorna tu SP
                var result = db.QueryFirstOrDefault<RequestStatus>(
                    ScriptDatabase.SP_Sucursales_Insertar,
                    parameter,
                    commandType: CommandType.StoredProcedure
                );

                return result; // <-- no crees un nuevo RequestStatus aquí
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


        public RequestStatus SucursalActualizar(SucursalesDTO sucursal)
        {
            var parameter = new DynamicParameters();

            parameter.Add("@Sucu_Id", sucursal.Sucu_Id);
            parameter.Add("@Sucu_Codigo", sucursal.Sucu_Codigo);
            parameter.Add("@Sucu_Nombre", sucursal.Sucu_Nombre);
            parameter.Add("@Sucu_Direccion", sucursal.Sucu_Direccion);
            parameter.Add("@Muni_Codigo", sucursal.Muni_Codigo);
            parameter.Add("@Usua_Modificacion", sucursal.Usua_Modificacion);
            parameter.Add("@Sucu_Imagen", sucursal.Sucu_Imagen);

            try
            {
                using var db = new SqlConnection(SistemaViajesContext.ConnectionString);
                // Devuelve lo que retorna el SP
                var result = db.QueryFirstOrDefault<RequestStatus>(
                    ScriptDatabase.SP_Sucursales_Actualizar,
                    parameter,
                    commandType: CommandType.StoredProcedure
                );

                return result ?? new RequestStatus
                {
                    CodeStatus = 0,
                    MessageStatus = "Error desconocido al actualizar la sucursal"
                };
            }
            catch (Exception ex)
            {
                return new RequestStatus
                {
                    CodeStatus = 0,
                    MessageStatus = $"Error inesperado: {ex.Message}"
                };
            }
        }

        public RequestStatus SucursalEliminar(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Sucu_Id", id);

            try
            {
                using var db = new SqlConnection(SistemaViajesContext.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(
                    ScriptDatabase.SP_Sucursales_Eliminar,
                    parameter,
                    commandType: CommandType.StoredProcedure
                );

                return result ?? new RequestStatus
                {
                    CodeStatus = 0,
                    MessageStatus = "Error desconocido al eliminar la sucursal"
                };
            }
            catch (Exception ex)
            {
                return new RequestStatus
                {
                    CodeStatus = 0,
                    MessageStatus = $"Error inesperado: {ex.Message}"
                };
            }
        }

    }
}
