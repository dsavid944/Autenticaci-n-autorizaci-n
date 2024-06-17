using InventarioControl.Server.Models;
using InventarioControl.Server.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventarioControl.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventariosController : ControllerBase
    {
        private readonly InventarioService _inventarioService;

        public InventariosController(InventarioService inventarioService)
        {
            _inventarioService = inventarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventario>>> GetInventarios()
        {
            var inventarios = await _inventarioService.ObtenerInventarios();
            return Ok(inventarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Inventario>> GetInventario(int id)
        {
            var inventario = await _inventarioService.ObtenerInventarioPorId(id);
            if (inventario == null)
            {
                return NotFound();
            }
            return Ok(inventario);
        }

        [HttpPost]
        public async Task<ActionResult<Inventario>> PostInventario(Inventario inventario)
        {
            var inventarioCreado = await _inventarioService.CrearInventario(inventario);
            return CreatedAtAction("GetInventario", new { id = inventarioCreado.Id }, inventarioCreado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventario(int id, Inventario inventario)
        {
            if (id != inventario.Id)
            {
                return BadRequest();
            }

            var resultado = await _inventarioService.ActualizarInventario(inventario);
            if (!resultado)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventario(int id)
        {
            var resultado = await _inventarioService.EliminarInventario(id);
            if (!resultado)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
