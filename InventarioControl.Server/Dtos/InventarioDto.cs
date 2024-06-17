namespace InventarioControl.Server.Dtos
{
    public class InventarioDto
    {
        public int Id { get; set; }
        public string Serial { get; set; }
        public string Modelo { get; set; }
        public string Descripcion { get; set; }
        public string FotoUrl { get; set; }
        public string Color { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal Precio { get; set; }
        public int UsuarioId { get; set; }
        public int MarcaId { get; set; }
        public int EstadoDeEquipoId { get; set; }
        public int TipoDeEquipoId { get; set; }
    }
}
