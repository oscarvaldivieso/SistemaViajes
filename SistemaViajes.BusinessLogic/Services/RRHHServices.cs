using SistemaViajes.DataAccess.Repositories.Gral;
using SistemaViajes.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaViajes.BusinessLogic.Services
{
    public class RRHHServices
    {
        private readonly ColaboradoresRepository _colaboradoresRepository;

        public RRHHServices(ColaboradoresRepository colaboradoresRepository)
        {
            _colaboradoresRepository = colaboradoresRepository;
        }


        #region Colaboradores
        public ServiceResult ColaboradoresListar()
        {
            var result = new ServiceResult();

            try
            {
                var data = _colaboradoresRepository.ColaboradoresListar();
                return result.Ok("Listado obtenido correctamente.", data);
            }
            catch (Exception ex)
            {
                return result.Error($"Error al listar colaboradores: {ex.Message}");
            }
        }

        public ServiceResult ColaboradoresInsertar(ColaboradoresInsertarDTO item)
        {
            var result = new ServiceResult();

            try
            {
                // Validación: Debe tener al menos una sucursal
                if (item.Sucursales == null || !item.Sucursales.Any())
                {
                    return result.SetMessage("Debe asignar al menos una sucursal al colaborador.", ServiceResultType.Warning);
                }

                // Validación: Distancias válidas
                if (item.Sucursales.Any(s => s.CoSu_DistanciaKm <= 0 || s.CoSu_DistanciaKm > 50))
                {
                    return result.SetMessage("Las distancias deben ser mayores a 0 y no exceder los 50 km.", ServiceResultType.Warning);
                }

                var response = _colaboradoresRepository.ColaboradoresInsertar(item);

                if (response.CodeStatus == 1)
                    return result.Ok("Colaborador y sucursales registrados exitosamente.", null);

                return result.SetMessage(response.MessageStatus, ServiceResultType.Warning);
            }
            catch (Exception ex)
            {
                return result.Error($"Error al insertar colaborador: {ex.Message}");
            }
        }

        public ServiceResult ColaboradoresActualizar(ColaboradoresDTO item)
        {
            var result = new ServiceResult();

            try
            {
                var response = _colaboradoresRepository.ColaboradoresActualizar(item);

                if (response.CodeStatus == 1)
                    return result.Ok(null, "Colaborador actualizado correctamente.");

                return result.SetMessage(response.MessageStatus, ServiceResultType.Warning);
            }
            catch (Exception ex)
            {
                return result.Error($"Error al actualizar colaborador: {ex.Message}");
            }
        }

        public ServiceResult ColaboradoresEliminar(int id)
        {
            var result = new ServiceResult();

            try
            {
                var response = _colaboradoresRepository.ColaboradoresEliminar(id);

                if (response.CodeStatus == 1)
                    return result.Ok(null, "Colaborador eliminado correctamente.");

                return result.SetMessage(response.MessageStatus, ServiceResultType.Warning);
            }
            catch (Exception ex)
            {
                return result.Error($"Error al eliminar colaborador: {ex.Message}");
            }
        }


        public ServiceResult ListarPorSucursal(int sucu_Id)
        {
            var result = new ServiceResult();

            try
            {
                var lista = _colaboradoresRepository.ListarPorSucursal(sucu_Id);

                if (!lista.Any())
                    return result.NotFound("No se encontraron colaboradores para esta sucursal.");

                return result.Ok( "Listado obtenido correctamente.",lista);
            }
            catch (Exception ex)
            {
                return result.Error($"Error al obtener los colaboradores: {ex.Message}");
            }
        }
        #endregion
    }
}
