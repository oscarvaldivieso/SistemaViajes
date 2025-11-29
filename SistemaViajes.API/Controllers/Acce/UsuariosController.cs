using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaViajes.BusinessLogic;
using SistemaViajes.BusinessLogic.Services;
using SistemaViajes.Models.Models;

namespace SistemaViajes.API.Controllers.Acce
{
    [Route("[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        public AcceServices _acceServices;


        public UsuariosController(AcceServices acceService)
        {
            _acceServices = acceService ?? throw new ArgumentNullException(nameof(acceService));
        }


        [HttpPost("Login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginRequestDTO loginRequest)
        {
            try
            {
                var result = _acceServices.Login(loginRequest);

                // Retornar el código HTTP según el Type del ServiceResult
                return StatusCode(result.Code, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ServiceResult().Error($"Internal server error: {ex.Message}"));
            }
        }

    }
}
