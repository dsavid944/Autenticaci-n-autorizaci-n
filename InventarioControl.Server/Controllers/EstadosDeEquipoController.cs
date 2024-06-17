using InventarioControl.Server.Models;
using InventarioControl.Server.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventarioControl.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosDeEquipoController : ControllerBase
    {
        private readonly EstadoDeEquipoService _estadoDeEquipoService;

        public EstadosDeEquipoController(EstadoDeEquipoService estadoDeEquipoService)
        {
            _estadoDeEquipoService = estadoDeEquipoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadoDeEquipo>>> GetEstadosDeEquipo()
        {
            var estadosDeEquipo = await _estadoDeEquipoService.ObtenerEstadosDeEquipo();
            return Ok(estadosDeEquipo);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoDeEquipo>> GetEstadoDeEquipo(int id)
        {
            var estadoDeEquipo = await _estadoDeEquipoService.ObtenerEstadoDeEquipoPorId(id);
            if (estadoDeEquipo == null)
            {
                return NotFound();
            }
            return Ok(estadoDeEquipo);
        }

        [HttpPost]
        public async Task<ActionResult<EstadoDeEquipo>> PostEstadoDeEquipo(EstadoDeEquipo estadoDeEquipo)
        {
            var estadoDeEquipoCreado = await _estadoDeEquipoService.CrearEstadoDeEquipo(estadoDeEquipo);
            return CreatedAtAction("GetEstadoDeEquipo", new { id = estadoDeEquipoCreado.Id }, estadoDeEquipoCreado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadoDeEquipo(int id, EstadoDeEquipo estadoDeEquipo)
        {
            if (id != estadoDeEquipo.Id)
            {
                return BadRequest();
            }

            var resultado = await _estadoDeEquipoService.ActualizarEstadoDeEquipo(estadoDeEquipo);
            if (!resultado)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstadoDeEquipo(int id)
        {
            var resultado = await _estadoDeEquipoService.EliminarEstadoDeEquipo(id);
            if (!resultado)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
