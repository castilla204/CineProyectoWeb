using System.ComponentModel.DataAnnotations;

namespace ApiCine.Modelos
{
    public class UsuarioDTO
    {
        [Required(ErrorMessage = "Campo requerido")]
        public int UsuarioID { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(50, ErrorMessage = "El nombre debe tener como máximo 50 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [EmailAddress(ErrorMessage = "Correo electrónico no válido.")]
        public string CorreoElectronico { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "La contraseña debe tener entre 6 y 100 caracteres.")]
        public string Contrasena { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public RolAlumno Rol { get; set; }

        public int CantidadReservas { get; set; }
    }
}