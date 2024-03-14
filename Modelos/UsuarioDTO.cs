using System.ComponentModel.DataAnnotations;

namespace ApiCine.Modelos
{
    public class UsuarioDTO
    {
        public int UsuarioID { get; set; }


        public string Nombre { get; set; }


        public string CorreoElectronico { get; set; }


        public string Contrasena { get; set; }


        public RolAlumno Rol { get; set; }

        public int CantidadReservas { get; set; }
    }
}