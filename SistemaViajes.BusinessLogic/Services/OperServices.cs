using SistemaViajes.DataAccess.Repositories.Gral;
using SistemaViajes.DataAccess.Repositories.Oper;
using SistemaViajes.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaViajes.BusinessLogic.Services
{
    public class OperServices
    {
        private readonly ViajesRepository _viajesRepository;

        public OperServices(ViajesRepository viajesRepository)
        {
            _viajesRepository = viajesRepository;
        }

        #region Viajes

        public ServiceResult ListarViajes()
        {
            var result = new ServiceResult();
            try
            {
                var response = _viajesRepository.ListarViajes();
                return result.Ok("Viajes listados correctamente.", response);
            }
            catch (Exception ex)
            {
                return result.Error($"Error al obtener los viajes: {ex.Message}");
            }
        }

        public ServiceResult ViajeInsertar(ViajesDTO viaje)
        {
            var result = new ServiceResult();
            try
            {
                var response = _viajesRepository.ViajeInsertar(viaje);
                if (response.CodeStatus == 1)
                    return result.Ok("Viaje registrado exitosamente.");
                return result.Error(response.MessageStatus ?? "No se pudo registrar el viaje.");
            }
            catch (Exception ex)
            {
                return result.Error($"Error inesperado al registrar el viaje: {ex.Message}");
            }
        }

        #endregion
    }
}
