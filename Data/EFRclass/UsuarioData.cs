using ApiCine.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiCine.Data
{
    public class UsuarioData : IUsuarioData
    {
        private readonly Context _context;

        public UsuarioData(Context context)
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


         public List<UsuarioReservasDTO> ObtenerUsuarioReservas(int usuarioId)
        {
            var reservasDTO = _context.Reservas
                .Where(r => r.UsuarioID == usuarioId)
                .Select(r => new UsuarioReservasDTO
                {
                    ReservaID = r.ReservaID,
                    TituloPelicula = r.Sesion.Pelicula.Titulo,
                    SalaID = r.Sesion.SalaID,
                    HoraSesion = r.Sesion.FechaHora,
                    NumerosAsiento = r.ReservaButacas.Select(rb => rb.ButacaID).ToList()
                })
                .ToList();

            return reservasDTO;
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