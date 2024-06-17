using InventarioControl.Server.Data;
using InventarioControl.Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace InventarioControl.Server.Services
{
    public class TipoDeEquipoService
    {
        private readonly InventarioContexto _contexto;

        public TipoDeEquipoService(InventarioContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<IEnumerable<TipoDeEquipo>> ObtenerTiposDeEquipo()
        {
            return await _contexto.TiposDeEquipo.ToListAsync();
        }

        public async Task<TipoDeEquipo> ObtenerTipoDeEquipoPorId(int id)
        {
            return await _contexto.TiposDeEquipo.FindAsync(id);
        }

        public async Task<TipoDeEquipo> CrearTipoDeEquipo(TipoDeEquipo tipoDeEquipo)
        {
            tipoDeEquipo.FechaCreacion = DateTime.Now;
            tipoDeEquipo.FechaActualizacion = DateTime.Now;
            _contexto.TiposDeEquipo.Add(tipoDeEquipo);
            await _contexto.SaveChangesAsync();
            return tipoDeEquipo;
        }

        public async Task<bool> ActualizarTipoDeEquipo(TipoDeEquipo tipoDeEquipo)
        {
            var tipoDeEquipoExistente = await _contexto.TiposDeEquipo.FindAsync(tipoDeEquipo.Id);
            if (tipoDeEquipoExistente == null)
            {
                return false;
            }

            tipoDeEquipoExistente.Nombre = tipoDeEquipo.Nombre;
            tipoDeEquipoExistente.Estado = tipoDeEquipo.Estado;
            tipoDeEquipoExistente.FechaActualizacion = DateTime.Now;

            _contexto.TiposDeEquipo.Update(tipoDeEquipoExistente);
            await _contexto.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarTipoDeEquipo(int id)
        {
            var tipoDeEquipo = await _contexto.TiposDeEquipo.FindAsync(id);
            if (tipoDeEquipo == null)
            {
                return false;
            }

            _contexto.TiposDeEquipo.Remove(tipoDeEquipo);
            await _contexto.SaveChangesAsync();
            return true;
        }
    }
}
