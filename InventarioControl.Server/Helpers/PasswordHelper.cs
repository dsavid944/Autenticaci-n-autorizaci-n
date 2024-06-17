using System.Security.Cryptography;
using System.Text;

namespace InventarioControl.Server.Helpers
{
    public static class PasswordHelper
    {
        public static string EncriptarContraseña(string contraseña)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(contraseña);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        public static bool VerificarContraseña(string contraseña, string hash)
        {
            var hashVerificacion = EncriptarContraseña(contraseña);
            return hashVerificacion == hash;
        }
    }
}
