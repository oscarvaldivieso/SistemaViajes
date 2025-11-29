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
        [ProducesResponseType(typeof(ServiceResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ServiceResult), StatusCodes.Status400BadRequest)]
        public IActionResult List()
        {
            var result = _operServices.ListarViajes();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("Detalle/{id:int}")]
        [ProducesResponseType(typeof(ServiceResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ServiceResult), StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var result = _operServices.ListarViajes();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            var viajes = result.Data as IEnumerable<ViajeListDTO>;
            var viaje = viajes?.FirstOrDefault(v => v.Viaj_Id == id);

            if (viaje == null)
            {
                return NotFound(new ServiceResult
                {
                    Success = false,
                    Message = $"No se encontró el viaje con ID {id}"
                });
            }

            return Ok(new ServiceResult
            {
                Success = true,
                Message = "Viaje encontrado.",
                Data = viaje
            });
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
