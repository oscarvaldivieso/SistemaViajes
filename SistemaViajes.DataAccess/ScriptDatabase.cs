using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaViajes.DataAccess
{
    public class ScriptDatabase
    {

        #region Departamentos

        public static string SP_Departamentos_Listar = "[Gral].[SP_Departamentos_Listar]";
        #endregion

        #region Municipios
        public static string SP_Municipios_Listar = "[Gral].[SP_MunicipiosPorDepartamento_Listar]";
        #endregion

        #region Sucursales
        public static string SP_Sucursales_Listar = "[Gral].[SP_Sucursales_Listar]";
        public static string SP_Sucursales_Insertar = "[Gral].[SP_Sucursales_Insertar]";
        public static string SP_Sucursales_Actualizar = "[Gral].[SP_Sucursales_Actualizar]";
        public static string SP_Sucursales_Eliminar = "[Gral].[SP_Sucursales_Eliminar]";
        public static string SP_Sucursales_Buscar = "[Gral].[SP_Sucursales_Buscar]";
        #endregion

        #region Colaboradores
        public static string SP_Colaboradores_Listar = "[RRHH].[SP_Colaboradores_Listar]";
        public static string SP_Colaboradores_Insertar = "[RRHH].[SP_Colaboradores_Insertar]";
        public static string SP_Colaboradores_Actualizar = "[RRHH].[SP_Colaboradores_Actualizar]";
        public static string SP_Colaboradores_Eliminar = "[RRHH].[SP_Colaboradores_Eliminar]";
        #endregion

        #region Viajes
        public static string SP_Viajes_Listar = "[Oper].[SP_Viajes_Listar]";
        public static string SP_Viajes_Insertar = "[Oper].[SP_Viajes_Insertar]";
        #endregion
    }
}
