using System;
using System.Security.Cryptography;
using System.Text;
using ApiCine.Modelos;

namespace ApiCine.Business.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioData _usuarioData;

        public UsuarioService(IUsuarioData usuarioData)
        {
            _usuarioData = usuarioData;
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
                Contrasena = usuarioDTO.Contrasena,
                CorreoElectronico = usuarioDTO.CorreoElectronico,
                Rol = usuarioDTO.Rol
            };
            _usuarioData.CrearUsuario(nuevoUsuario);
        }

       public UsuarioDTO Login(string usuario, string passwordHasheada)
        {
            return _usuarioData.Login(usuario, passwordHasheada);
        }
    
    }
}