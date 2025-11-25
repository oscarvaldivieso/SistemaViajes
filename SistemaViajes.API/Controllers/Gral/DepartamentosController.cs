using AutoMapper;
using SistemaViajes.BusinessLogic.Services;
using SistemaViajes.Models.Models;
using Microsoft.AspNetCore.Mvc;
using SistemaViajes.Models.Models;

namespace SistemaViajes.API.Controllers.UNI
{
    [Route("[controller]")]
    [ApiController]
    public class DepartamentosController : Controller
    {
        private readonly GralServices _gralServices;

        public DepartamentosController(GralServices gralServices)
        {
            _gralServices = gralServices ?? throw new ArgumentNullException(nameof(gralServices));
        }


        [HttpGet("Listar")]
        public IActionResult List()
        {
            var result = _gralServices.ListDepartamentos();

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
