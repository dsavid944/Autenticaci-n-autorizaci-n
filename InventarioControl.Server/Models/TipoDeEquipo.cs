namespace InventarioControl.Server.Models
{
    public class TipoDeEquipo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; } // Activo o Inactivo
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}
