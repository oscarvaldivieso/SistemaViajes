using Microsoft.AspNetCore.Mvc;
using SistemaViajes.BusinessLogic.Services;
using SistemaViajes.Models.Models;

namespace SistemaViajes.API.Controllers.RRHH
{
    public class ColaboradoresController : Controller
    {
        private readonly RRHHServices _rrhhServices;

        public ColaboradoresController(RRHHServices rrhhServices)
        {
            _rrhhServices = rrhhServices ?? throw new ArgumentNullException(nameof(rrhhServices));
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var response = _rrhhServices.ColaboradoresListar();
            return Ok(response);
        }

        // POST: Insertar
        [HttpPost("Insertar")]
        public IActionResult Insertar([FromBody] ColaboradoresDTO item)
        {
            var response = _rrhhServices.ColaboradoresInsertar(item);
            return Ok(response);
        }

        // PUT: Actualizar
        [HttpPut("Actualizar")]
        public IActionResult Actualizar([FromBody] ColaboradoresDTO item)
        {
            var response = _rrhhServices.ColaboradoresActualizar(item);
            return Ok(response);
        }

        // DELETE: Eliminar
        [HttpDelete("Eliminar/{id}")]
        public IActionResult Eliminar(int id)
        {
            var response = _rrhhServices.ColaboradoresEliminar(id);
            return Ok(response);
        }
    }
}
