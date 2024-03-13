using System;
using System.Security.Cryptography;
using System.Text;
using ApiCine.Modelos;
using ApiCine.Data;

namespace ApiCine.Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthData _authData;

        public AuthService(IAuthData authData)
        {
            _authData = authData;
        }
         public void CrearUsuario(UsuarioCrearDTO usuarioDTO)
        {
            var nuevoUsuario = new Usuario
            {
                Nombre = usuarioDTO.Nombre,
                Contrasena = usuarioDTO.Contrasena,
                CorreoElectronico = usuarioDTO.CorreoElectronico,
                Rol = usuarioDTO.Rol
            };
            _authData.CrearUsuario(nuevoUsuario);
        }

       public UsuarioDTO Login(string usuario, string passwordHasheada)
        {
            return _authData.Login(usuario, passwordHasheada);
        }
    }
}