using InventarioControl.Server.Data;
using InventarioControl.Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace InventarioControl.Server.Services
{
    public class EstadoDeEquipoService
    {
        private readonly InventarioContexto _contexto;

        public EstadoDeEquipoService(InventarioContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<IEnumerable<EstadoDeEquipo>> ObtenerEstadosDeEquipo()
        {
            return await _contexto.EstadosDeEquipo.ToListAsync();
        }

        public async Task<EstadoDeEquipo> ObtenerEstadoDeEquipoPorId(int id)
        {
            return await _contexto.EstadosDeEquipo.FindAsync(id);
        }

        public async Task<EstadoDeEquipo> CrearEstadoDeEquipo(EstadoDeEquipo estadoDeEquipo)
        {
            estadoDeEquipo.FechaCreacion = DateTime.Now;
            estadoDeEquipo.FechaActualizacion = DateTime.Now;
            _contexto.EstadosDeEquipo.Add(estadoDeEquipo);
            await _contexto.SaveChangesAsync();
            return estadoDeEquipo;
        }

        public async Task<bool> ActualizarEstadoDeEquipo(EstadoDeEquipo estadoDeEquipo)
        {
            var estadoDeEquipoExistente = await _contexto.EstadosDeEquipo.FindAsync(estadoDeEquipo.Id);
            if (estadoDeEquipoExistente == null)
            {
                return false;
            }

            estadoDeEquipoExistente.Nombre = estadoDeEquipo.Nombre;
            estadoDeEquipoExistente.Estado = estadoDeEquipo.Estado;
            estadoDeEquipoExistente.FechaActualizacion = DateTime.Now;

            _contexto.EstadosDeEquipo.Update(estadoDeEquipoExistente);
            await _contexto.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarEstadoDeEquipo(int id)
        {
            var estadoDeEquipo = await _contexto.EstadosDeEquipo.FindAsync(id);
            if (estadoDeEquipo == null)
            {
                return false;
            }

            _contexto.EstadosDeEquipo.Remove(estadoDeEquipo);
            await _contexto.SaveChangesAsync();
            return true;
        }
    }
}
