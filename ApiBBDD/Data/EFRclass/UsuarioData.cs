using ApiPeliculas.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.ObjectPool;

namespace ApiPeliculas.Data{
    public class UsuarioData: IUsuarioData{
        private readonly PeliculaContext _context;

        public UsuarioData(PeliculaContext context){
            _context=context;
        }

        public List<UsuarioDTO> ObtenerUsuarios(){
            var UsuariosDTO= _context.Usuarios
                .Include(u => u.Reservas)
                .Select(u => new UsuarioDTO{
                UsuarioID=u.UsuarioID,
                Nombre=u.Nombre,
                Contrasena=u.Contrasena,
                CorreoElectronico=u.CorreoElectronico,
                Rol=u.Rol,
                CantidadReservas=u.Reservas.Count
        }).ToList();

        return UsuariosDTO;
        }


    public UsuarioDTO ObtenerUsuario(int id){
    var usuario = _context.Usuarios
        .Where(u => u.UsuarioID == id)
        .Include(u => u.Reservas)
        .Select(u => new UsuarioDTO
        {
            UsuarioID = u.UsuarioID,
            Nombre = u.Nombre,
            Contrasena=u.Contrasena,
            CorreoElectronico = u.CorreoElectronico,
            Rol=u.Rol,
            CantidadReservas = u.Reservas.Count
        })
        .FirstOrDefault();

    return usuario;
}


public void CrearUsuario(Usuario usuario){
_context.Add(usuario);
_context.SaveChanges();
}

      
    }
}