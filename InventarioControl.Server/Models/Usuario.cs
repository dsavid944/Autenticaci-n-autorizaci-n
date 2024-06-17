namespace InventarioControl.Server.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public bool Estado { get; set; } // Activo o Inactivo
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public string Rol { get; set; } // "administrador" o "docente"
    }
}
