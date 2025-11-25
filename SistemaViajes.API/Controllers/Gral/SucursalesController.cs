using Microsoft.AspNetCore.Mvc;
using SistemaViajes.BusinessLogic.Services;
using SistemaViajes.Models.Models;

namespace SistemaViajes.API.Controllers.Gral
{
    [Route("[controller]")]
    [ApiController]
    public class SucursalesController : Controller
    {
        private readonly GralServices _gralServices;

        public SucursalesController(GralServices gralServices)
        {
            _gralServices = gralServices ?? throw new ArgumentNullException(nameof(gralServices));
        }

        [HttpGet("Listar")]
        public IActionResult List()
        {
            var result = _gralServices.ListarSucursales();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Insertar")]
        public IActionResult Create([FromBody] SucursalesDTO sucursal)
        {
            try
            {
                var result = _gralServices.SucursalInsertar(sucursal);
                return result.Success ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Success = false,
                    Message = "Internal server error",
                    Details = ex.Message
                });
            }
        }

        [HttpPost("Actualizar")]
        public IActionResult Update([FromBody] SucursalesDTO sucursal)
        {
            try
            {
                var result = _gralServices.SucursalActualizar(sucursal);
                return result.Success ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Success = false,
                    Message = "Internal server error",
                    Details = ex.Message
                });
            }
        }

        [HttpDelete("Elliminar")]
        public IActionResult Delete(int id)
        {
            var result = _gralServices.SucursalEliminar(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
