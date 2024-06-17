namespace InventarioControl.Server.Models
{
    public class Inventario
    {
        public int Id { get; set; }
        public string Serial { get; set; } // Campo único
        public string Modelo { get; set; } // Campo único
        public string Descripcion { get; set; }
        public string FotoUrl { get; set; }
        public string Color { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal Precio { get; set; }

        // Relaciones
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int MarcaId { get; set; }
        public Marca Marca { get; set; }

        public int EstadoDeEquipoId { get; set; }
        public EstadoDeEquipo EstadoDeEquipo { get; set; }

        public int TipoDeEquipoId { get; set; }
        public TipoDeEquipo TipoDeEquipo { get; set; }
    }
}
