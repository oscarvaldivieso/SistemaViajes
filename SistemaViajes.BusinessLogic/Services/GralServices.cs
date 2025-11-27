using SistemaViajes.DataAccess.Repositories.Gral;
using SistemaViajes.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaViajes.BusinessLogic.Services
{
    public class GralServices
    {
        private readonly DepartamentosRepository _departamentosRepository;
        private readonly MunicipiosRepository _municipiosRepository;
        private readonly SucursalesRepository _sucursalesRepository;
        private readonly TransportistasRepository _transportistasRepository;

        public GralServices(DepartamentosRepository departamentosRepository, MunicipiosRepository municipiosRepository, SucursalesRepository sucursalesRepository, TransportistasRepository transportistasRepository)
        {
            _departamentosRepository = departamentosRepository;
            _municipiosRepository = municipiosRepository;
            _sucursalesRepository = sucursalesRepository;
            _transportistasRepository = transportistasRepository;
        }

        #region Departamentos
        public ServiceResult ListDepartamentos()
        {
            var result = new ServiceResult();

            try
            {
                var response = _departamentosRepository.List();
                return result.Ok("Departamentos listados correctamente.", response);
            }
            catch (Exception ex)
            {
                return result.Error($"Error al obtener departamentos: {ex.Message}");
            }
        }

        #endregion


        #region Municipios
        public ServiceResult ListarMunicipiosPorDepartamento(string depaCodigo)
        {
            var result = new ServiceResult();

            if (string.IsNullOrWhiteSpace(depaCodigo))
                return result.Error("El código del departamento es requerido.");

            try
            {
                var response = _municipiosRepository.ListarPorDepartamento(depaCodigo);
                return result.Ok("Municipios listados correctamente.", response);
            }
            catch (Exception ex)
            {
                return result.Error($"Error al obtener municipios: {ex.Message}");
            }
        }
        #endregion

        #region Sucursales
        public ServiceResult ListarSucursales()
        {
            var result = new ServiceResult();

            try
            {
                var response = _sucursalesRepository.ListarSucursales();
                return result.Ok("Sucursales listadas correctamente.", response);
            }
            catch (Exception ex)
            {
                return result.Error($"Error al obtener las sucursales: {ex.Message}");
            }
        }

        public ServiceResult SucursalInsertar(SucursalesDTO sucursal)
        {
            var result = new ServiceResult();

            try
            {
                var response = _sucursalesRepository.SucursalInsertar(sucursal);

                if (response.CodeStatus == 1)
                    return result.Ok("Sucursal insertada correctamente.");

                return result.Error(response.MessageStatus ?? "No se pudo insertar la sucursal.");
            }
            catch (Exception ex)
            {
                return result.Error($"Error inesperado al insertar la sucursal: {ex.Message}");
            }
        }


        public ServiceResult SucursalActualizar(SucursalesDTO sucursal)
        {
            var result = new ServiceResult();

            try
            {
                var response = _sucursalesRepository.SucursalActualizar(sucursal);

                if (response.CodeStatus == 1)
                    return result.Ok("Sucursal actualizada correctamente.");

                return result.Error(response.MessageStatus ?? "No se pudo actualizar la sucursal.");
            }
            catch (Exception ex)
            {
                return result.Error($"Error inesperado al actualizar la sucursal: {ex.Message}");
            }
        }

        public ServiceResult SucursalEliminar(int id)
        {
            var result = new ServiceResult();

            if (id <= 0)
                return result.Error("El ID de la sucursal es requerido.");

            try
            {
                var response = _sucursalesRepository.SucursalEliminar(id);

                if (response.CodeStatus == 1)
                    return result.Ok("Sucursal eliminada correctamente.");

                return result.Error(response.MessageStatus ?? "No se pudo eliminar la sucursal.");
            }
            catch (Exception ex)
            {
                return result.Error($"Error inesperado al eliminar la sucursal: {ex.Message}");
            }
        }


        #endregion

        #region Transportistas
        public ServiceResult ListarTransportistas()
        {
            var result = new ServiceResult();
            try
            {
                var list = _transportistasRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult BuscarTransportistas(int id)
        {
            var result = new ServiceResult();
            try
            {
                var item = _transportistasRepository.Find(id);
                return result.Ok(item);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult InsertarTransportistas(TransportistasDTO dto)
        {
            var result = new ServiceResult();
            try
            {
                var response = _transportistasRepository.Insert(dto);
                return response.CodeStatus == 1 ? result.Ok(response) : result.Error(response.MessageStatus);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ActualizarTransportistas(TransportistasDTO dto)
        {
            var result = new ServiceResult();
            try
            {
                var response = _transportistasRepository.Update(dto);
                return response.CodeStatus == 1 ? result.Ok(response) : result.Error(response.MessageStatus);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarTransportistas(int id)
        {
            var result = new ServiceResult();
            try
            {
                var response = _transportistasRepository.Delete(id);
                return response.CodeStatus == 1 ? result.Ok(response) : result.Error(response.MessageStatus);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion
    }
}
