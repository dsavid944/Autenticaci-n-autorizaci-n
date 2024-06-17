using InventarioControl.Server.Data;
using InventarioControl.Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace InventarioControl.Server.Services
{
    public class InventarioService
    {
        private readonly InventarioContexto _contexto;

        public InventarioService(InventarioContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<IEnumerable<Inventario>> ObtenerInventarios()
        {
            return await _contexto.Inventarios
                .Include(i => i.Usuario)
                .Include(i => i.Marca)
                .Include(i => i.EstadoDeEquipo)
                .Include(i => i.TipoDeEquipo)
                .ToListAsync();
        }

        public async Task<Inventario> ObtenerInventarioPorId(int id)
        {
            return await _contexto.Inventarios
                .Include(i => i.Usuario)
                .Include(i => i.Marca)
                .Include(i => i.EstadoDeEquipo)
                .Include(i => i.TipoDeEquipo)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Inventario> CrearInventario(Inventario inventario)
        {
            inventario.FechaCompra = DateTime.Now;
            _contexto.Inventarios.Add(inventario);
            await _contexto.SaveChangesAsync();
            return inventario;
        }

        public async Task<bool> ActualizarInventario(Inventario inventario)
        {
            var inventarioExistente = await _contexto.Inventarios.FindAsync(inventario.Id);
            if (inventarioExistente == null)
            {
                return false;
            }

            inventarioExistente.Serial = inventario.Serial;
            inventarioExistente.Modelo = inventario.Modelo;
            inventarioExistente.Descripcion = inventario.Descripcion;
            inventarioExistente.FotoUrl = inventario.FotoUrl;
            inventarioExistente.Color = inventario.Color;
            inventarioExistente.FechaCompra = inventario.FechaCompra;
            inventarioExistente.Precio = inventario.Precio;
            inventarioExistente.UsuarioId = inventario.UsuarioId;
            inventarioExistente.MarcaId = inventario.MarcaId;
            inventarioExistente.EstadoDeEquipoId = inventario.EstadoDeEquipoId;
            inventarioExistente.TipoDeEquipoId = inventario.TipoDeEquipoId;

            _contexto.Inventarios.Update(inventarioExistente);
            await _contexto.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarInventario(int id)
        {
            var inventario = await _contexto.Inventarios.FindAsync(id);
            if (inventario == null)
            {
                return false;
            }

            _contexto.Inventarios.Remove(inventario);
            await _contexto.SaveChangesAsync();
            return true;
        }
    }
}
