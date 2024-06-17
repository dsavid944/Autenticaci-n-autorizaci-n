    using InventarioControl.Server.Data;
    using InventarioControl.Server.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System;
    using System.Security.Cryptography;
    using System.Text;

    namespace InventarioControl.Server.Services
    {
        public class UsuarioService
        {
            private readonly InventarioContexto _contexto;

            public UsuarioService(InventarioContexto contexto)
            {
                _contexto = contexto;
            }

            public async Task<IEnumerable<Usuario>> ObtenerUsuarios()
            {
                return await _contexto.Usuarios.ToListAsync();
            }

        public async Task<Usuario> ObtenerUsuarioPorId(int id)
        {
            return await _contexto.Usuarios.FindAsync(id);
        }

        public async Task<Usuario> CrearUsuario(Usuario usuario)
        {
            usuario.FechaCreacion = DateTime.Now;
            usuario.FechaActualizacion = DateTime.Now;
            usuario.Contraseña = EncriptarContraseña(usuario.Contraseña);
            _contexto.Usuarios.Add(usuario);
            await _contexto.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> ActualizarUsuario(Usuario usuario)
        {
            var usuarioExistente = await _contexto.Usuarios.FindAsync(usuario.Id);
            if (usuarioExistente == null)
            {
                return false;
            }

            usuarioExistente.Nombre = usuario.Nombre;
            usuarioExistente.Email = usuario.Email;
            usuarioExistente.Rol = usuario.Rol;
            if (!string.IsNullOrEmpty(usuario.Contraseña))
            {
                usuarioExistente.Contraseña = EncriptarContraseña(usuario.Contraseña);
            }
            usuarioExistente.FechaActualizacion = DateTime.Now;

            _contexto.Usuarios.Update(usuarioExistente);
            await _contexto.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarUsuario(int id)
        {
            var usuario = await _contexto.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return false;
            }

            _contexto.Usuarios.Remove(usuario);
            await _contexto.SaveChangesAsync();
            return true;
        }

        private string EncriptarContraseña(string contraseña)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(contraseña);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        public async Task<Usuario> IniciarSesion(string email, string contraseña)
        {
            var contraseñaEncriptada = EncriptarContraseña(contraseña);
            var usuario = await _contexto.Usuarios.FirstOrDefaultAsync(u => u.Email == email && u.Contraseña == contraseñaEncriptada);
            return usuario;
        }
    }
}
