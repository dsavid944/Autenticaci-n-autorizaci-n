using InventarioControl.Server.Models;
using InventarioControl.Server.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace InventarioControl.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasController : ControllerBase
    {
        private readonly MarcaService _marcaService;

        public MarcasController(MarcaService marcaService)
        {
            _marcaService = marcaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Marca>>> GetMarcas()
        {
            var marcas = await _marcaService.ObtenerMarcas();
            return Ok(marcas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Marca>> GetMarca(int id)
        {
            var marca = await _marcaService.ObtenerMarcaPorId(id);
            if (marca == null)
            {
                return NotFound();
            }
            return Ok(marca);
        }

        [HttpPost]
        public async Task<ActionResult<Marca>> PostMarca(Marca marca)
        {
            var marcaCreada = await _marcaService.CrearMarca(marca);
            return CreatedAtAction("GetMarca", new { id = marcaCreada.Id }, marcaCreada);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarca(int id, Marca marca)
        {
            if (id != marca.Id)
            {
                return BadRequest();
            }

            var resultado = await _marcaService.ActualizarMarca(marca);
            if (!resultado)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMarca(int id)
        {
            var resultado = await _marcaService.EliminarMarca(id);
            if (!resultado)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
