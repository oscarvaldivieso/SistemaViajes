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

        public GralServices(DepartamentosRepository departamentosRepository, MunicipiosRepository municipiosRepository, SucursalesRepository sucursalesRepository)
        {
            _departamentosRepository = departamentosRepository;
            _municipiosRepository = municipiosRepository;
            _sucursalesRepository = sucursalesRepository;
        }

        #region Departamentos
        public ServiceResult ListDepartamentos()
        { 
            var result = new ServiceResult();
            try
            {
                var response = _departamentosRepository.List();
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion


        #region Municipios
        public ServiceResult ListarMunicipiosPorDepartamento(string depaCodigo)
        {   

            var result = new ServiceResult();

            if (string.IsNullOrWhiteSpace(depaCodigo))
                return result.Error("El Codigo del departamento es requerido");

            try
            {
                var response = _municipiosRepository.ListarPorDepartamento(depaCodigo);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
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
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult SucursalInsertar(SucursalesDTO sucursal)
        {
            var result = new ServiceResult();

            try
            {
                var response = _sucursalesRepository.SucursalInsertar(sucursal);

                return response.CodeStatus == 1
                    ? result.Ok(response)
                    : result.Error(response);
            }
            catch (Exception ex)
            {
                return result.Error($"Unexpected error during Sucursal inserting: {ex.Message}");
            }
        }

        public ServiceResult SucursalActualizar(SucursalesDTO sucursal)
        {
            var result = new ServiceResult();

            try
            {
                var response = _sucursalesRepository.SucursalActualizar(sucursal);

                return response.CodeStatus == 1
                    ? result.Ok(response)
                    : result.Error(response);
            }
            catch (Exception ex)
            {
                return result.Error($"Unexpected error during Sucursal updating: {ex.Message}");
            }
        }

        public ServiceResult SucursalEliminar(int id)
        {
            var result = new ServiceResult();

            if (id <= 0)
                return result.Error("Sucursal ID is required");

            try
            {
                var response = _sucursalesRepository.SucursalEliminar(id);

                return response.CodeStatus == 1
                    ? result.Ok(response)
                    : result.Error(response);
            }
            catch (Exception ex)
            {
                return result.Error($"Unexpected error during Sucursal deletion: {ex.Message}");
            }
        }
        #endregion
    }
}
