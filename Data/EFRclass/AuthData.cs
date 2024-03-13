using ApiCine.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApiCine.Data;


namespace ApiCine.Data
{
    public class AuthData : IAuthData
    {
        private readonly Context _context;

        public AuthData(Context context)
        {
            _context = context;
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