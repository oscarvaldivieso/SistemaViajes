using Microsoft.AspNetCore.Mvc;
using SistemaViajes.BusinessLogic.Services;
using SistemaViajes.BusinessLogic;
using SistemaViajes.Models.Models;

namespace SistemaViajes.API.Controllers.Oper
{
    [Route("[controller]")]
    [ApiController]
    public class ViajesController : ControllerBase
    {
        private readonly OperServices _operServices;

        public ViajesController(OperServices operServices)
        {
            _operServices = operServices ?? throw new ArgumentNullException(nameof(operServices));
        }

        [HttpGet("Listar")]
        public IActionResult List()
        {
            var result = _operServices.ListarViajes();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Insertar")]
        public IActionResult Create([FromBody] ViajesDTO viaje)
        {
            try
            {
                // Validaciones básicas del request
                if (viaje == null)
                {
                    return BadRequest(new ServiceResult
                    {
                        Success = false,
                        Message = "Los datos del viaje son requeridos."
                    });
                }

                if (viaje.Colaboradores == null || !viaje.Colaboradores.Any())
                {
                    return BadRequest(new ServiceResult
                    {
                        Success = false,
                        Message = "Debe incluir al menos un colaborador en el viaje."
                    });
                }

                // Llamar al servicio
                var result = _operServices.ViajeInsertar(viaje);

                // Retornar según el resultado
                return result.Success ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ServiceResult
                {
                    Success = false,
                    Message = "Error interno del servidor.",
                    Data = ex.Message
                });
            }
        }
    }
}
