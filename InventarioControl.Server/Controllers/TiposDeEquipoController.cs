using InventarioControl.Server.Models;
using InventarioControl.Server.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventarioControl.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposDeEquipoController : ControllerBase
    {
        private readonly TipoDeEquipoService _tipoDeEquipoService;

        public TiposDeEquipoController(TipoDeEquipoService tipoDeEquipoService)
        {
            _tipoDeEquipoService = tipoDeEquipoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoDeEquipo>>> GetTiposDeEquipo()
        {
            var tiposDeEquipo = await _tipoDeEquipoService.ObtenerTiposDeEquipo();
            return Ok(tiposDeEquipo);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoDeEquipo>> GetTipoDeEquipo(int id)
        {
            var tipoDeEquipo = await _tipoDeEquipoService.ObtenerTipoDeEquipoPorId(id);
            if (tipoDeEquipo == null)
            {
                return NotFound();
            }
            return Ok(tipoDeEquipo);
        }

        [HttpPost]
        public async Task<ActionResult<TipoDeEquipo>> PostTipoDeEquipo(TipoDeEquipo tipoDeEquipo)
        {
            var tipoDeEquipoCreado = await _tipoDeEquipoService.CrearTipoDeEquipo(tipoDeEquipo);
            return CreatedAtAction("GetTipoDeEquipo", new { id = tipoDeEquipoCreado.Id }, tipoDeEquipoCreado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoDeEquipo(int id, TipoDeEquipo tipoDeEquipo)
        {
            if (id != tipoDeEquipo.Id)
            {
                return BadRequest();
            }

            var resultado = await _tipoDeEquipoService.ActualizarTipoDeEquipo(tipoDeEquipo);
            if (!resultado)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoDeEquipo(int id)
        {
            var resultado = await _tipoDeEquipoService.EliminarTipoDeEquipo(id);
            if (!resultado)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
