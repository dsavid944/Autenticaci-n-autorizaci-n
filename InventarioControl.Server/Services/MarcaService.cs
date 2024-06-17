using InventarioControl.Server.Data;
using InventarioControl.Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace InventarioControl.Server.Services
{
    public class MarcaService
    {
        private readonly InventarioContexto _contexto;

        public MarcaService(InventarioContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<IEnumerable<Marca>> ObtenerMarcas()
        {
            return await _contexto.Marcas.ToListAsync();
        }

        public async Task<Marca> ObtenerMarcaPorId(int id)
        {
            return await _contexto.Marcas.FindAsync(id);
        }

        public async Task<Marca> CrearMarca(Marca marca)
        {
            marca.FechaCreacion = DateTime.Now;
            marca.FechaActualizacion = DateTime.Now;
            _contexto.Marcas.Add(marca);
            await _contexto.SaveChangesAsync();
            return marca;
        }

        public async Task<bool> ActualizarMarca(Marca marca)
        {
            var marcaExistente = await _contexto.Marcas.FindAsync(marca.Id);
            if (marcaExistente == null)
            {
                return false;
            }

            marcaExistente.Nombre = marca.Nombre;
            marcaExistente.Estado = marca.Estado;
            marcaExistente.FechaActualizacion = DateTime.Now;

            _contexto.Marcas.Update(marcaExistente);
            await _contexto.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarMarca(int id)
        {
            var marca = await _contexto.Marcas.FindAsync(id);
            if (marca == null)
            {
                return false;
            }

            _contexto.Marcas.Remove(marca);
            await _contexto.SaveChangesAsync();
            return true;
        }
    }
}
