using System;
using System.Security.Cryptography;
using System.Text;
using ApiPeliculas.Modelos;

namespace ApiPeliculas.Business.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioData _usuarioData;

        public UsuarioService(IUsuarioData usuarioData)
        {
            _usuarioData = usuarioData;
        }

        private string HashearSHA256(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));//Hashear la password
                return Convert.ToBase64String(hashedBytes); // Convertir hash a base64
            }
        }

        public List<UsuarioDTO> ObtenerUsuarios()
        {
            return _usuarioData.ObtenerUsuarios();
        }

        public UsuarioDTO ObtenerUsuario(int id)
        {
            return _usuarioData.ObtenerUsuario(id);
        }

        public void CrearUsuario(UsuarioCrearDTO usuarioDTO)
        {
            var nuevoUsuario = new Usuario
            {
                Nombre = usuarioDTO.Nombre,
                Contrasena = HashearSHA256(usuarioDTO.Contrasena), 
                CorreoElectronico = usuarioDTO.CorreoElectronico,
                Rol = usuarioDTO.Rol
            };
            _usuarioData.CrearUsuario(nuevoUsuario);
        }
    }
}