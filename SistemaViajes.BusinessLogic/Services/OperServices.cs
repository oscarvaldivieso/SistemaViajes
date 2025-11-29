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
                var viajes = _viajesRepository.ListarViajes();

                if (viajes == null || !viajes.Any())
                {
                    return result.Ok("No se encontraron viajes registrados.", new List<ViajeListDTO>());
                }

                return result.Ok($"Se encontraron {viajes.Count()} viaje(s).", viajes);
            }
            catch (Exception ex)
            {
                // Log the exception here if you have logging
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


        public ServiceResult ObtenerReportePorTransportista(ViajesReporteRequestDTO request)
        {
            var result = new ServiceResult();
            try
            {
                // Validaciones
                if (request.FechaInicio > request.FechaFin)
                    return result.BadRequest("La fecha de inicio no puede ser mayor que la fecha fin");

                var reporte = _viajesRepository.ObtenerReportePorTransportista(request);

                if (reporte == null)
                    return result.Error("Error al generar el reporte");

                return result.Ok(reporte);
            }
            catch (Exception ex)
            {
                return result.Error($"Error inesperado: {ex.Message}");
            }
        }

        #endregion
    }
}
