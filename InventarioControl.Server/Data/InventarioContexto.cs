using InventarioControl.Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace InventarioControl.Server.Data
{
    public class InventarioContexto : DbContext
    {
        public InventarioContexto(DbContextOptions<InventarioContexto> opciones) : base(opciones) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TipoDeEquipo> TiposDeEquipo { get; set; }
        public DbSet<EstadoDeEquipo> EstadosDeEquipo { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuraciones adicionales
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Inventario>()
                .HasIndex(i => i.Serial)
                .IsUnique();

            modelBuilder.Entity<Inventario>()
                .HasIndex(i => i.Modelo)
                .IsUnique();

            // Configuración de la columna 'Precio' con tipo decimal específico
            modelBuilder.Entity<Inventario>()
                .Property(i => i.Precio)
                .HasColumnType("decimal(18,2)");
        }
    }
}
