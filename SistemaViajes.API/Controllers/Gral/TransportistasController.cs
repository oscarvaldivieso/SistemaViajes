 using Microsoft.AspNetCore.Mvc;
using SistemaViajes.BusinessLogic.Services;
using SistemaViajes.Models.Models;

namespace SistemaViajes.API.Controllers.Gral
{
    [Route("[controller]")]
    [ApiController]
    public class TransportistasController : ControllerBase
    {
        private readonly GralServices _generalServices;

        public TransportistasController(GralServices generalServices)
        {
            _generalServices = generalServices;
        }

        [HttpGet("Listar")]
        public IActionResult List()
        {
            return Ok(_generalServices.ListarTransportistas());
        }

        [HttpGet("Buscar/{id}")]
        public IActionResult Find(int id)
        {
            return Ok(_generalServices.BuscarTransportistas(id));
        }

        [HttpPost("Insertar")]
        public IActionResult Insert(TransportistasDTO dto)
        {
            return Ok(_generalServices.InsertarTransportistas(dto));
        }

        [HttpPut("Actualizar")]
        public IActionResult Update(TransportistasDTO dto)
        {
            return Ok(_generalServices.ActualizarTransportistas(dto));
        }

        [HttpDelete("Eliminar/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_generalServices.EliminarTransportistas(id));
        }
    }

}
