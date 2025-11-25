using Microsoft.AspNetCore.Mvc;
using SistemaViajes.BusinessLogic.Services;

namespace SistemaViajes.API.Controllers.Gral
{
    [Route("[controller]")]
    [ApiController]
    public class MunicipiosController : Controller
    {

        private readonly GralServices _gralServices;

        public MunicipiosController(GralServices gralServices)
        {
            _gralServices = gralServices ?? throw new ArgumentNullException(nameof(gralServices));
        }


        [HttpGet("Listar/{depaCodigo}")]
        public IActionResult ListarPorDepartamento(string depaCodigo)
        {
            var result = _gralServices.ListarMunicipiosPorDepartamento(depaCodigo);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
