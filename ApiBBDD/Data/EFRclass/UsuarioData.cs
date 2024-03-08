using ApiPeliculas.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiPeliculas.Data
{
    public class UsuarioData : IUsuarioData
    {
        private readonly PeliculaContext _context;

        public UsuarioData(PeliculaContext context)
        {
            _context = context;
        }

        public List<UsuarioDTO> ObtenerUsuarios()
        {
            var usuariosDTO = _context.Usuarios
                .Include(u => u.Reservas)
                .Select(u => new UsuarioDTO
                {
                    UsuarioID = u.UsuarioID,
                    Nombre = u.Nombre,
                    Contrasena = u.Contrasena,
                    CorreoElectronico = u.CorreoElectronico,
                    Rol = u.Rol,
                    CantidadReservas = u.Reservas.Count
                })
                .ToList();

            return usuariosDTO;
        }

        public UsuarioDTO ObtenerUsuario(int id)
        {
            var usuario = _context.Usuarios
                .Where(u => u.UsuarioID == id)
                .Include(u => u.Reservas)
                .Select(u => new UsuarioDTO
                {
                    UsuarioID = u.UsuarioID,
                    Nombre = u.Nombre,
                    Contrasena = u.Contrasena,
                    CorreoElectronico = u.CorreoElectronico,
                    Rol = u.Rol,
                    CantidadReservas = u.Reservas.Count
                })
                .FirstOrDefault();

            return usuario;
        }

        public void CrearUsuario(Usuario usuario)
        {
            _context.Add(usuario);
            _context.SaveChanges();
        }

 public UsuarioDTO Login(string usuario, string passwordHasheada)
        {
            var hashedPassword = DecodePassword(passwordHasheada);
            var user = _context.Usuarios
                .Where(u => u.Nombre == usuario && u.Contrasena == hashedPassword)
                .Include(u => u.Reservas)
                .Select(u => new UsuarioDTO
                {
                    UsuarioID = u.UsuarioID,
                    Nombre = u.Nombre,
                    CorreoElectronico = u.CorreoElectronico,
                    Rol = u.Rol,
                    CantidadReservas = u.Reservas.Count
                })
                .FirstOrDefault();

            return user;
        }

        private string DecodePassword(string hashedPasswordBase64)
        {
            var decodedBytes = Convert.FromBase64String(hashedPasswordBase64);
            return Encoding.UTF8.GetString(decodedBytes);
        }
    }
}