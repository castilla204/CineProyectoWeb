using System.ComponentModel.DataAnnotations;

namespace ApiCine.Modelos
{
    public class UsuarioLoginDTO
    {
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Largo inválido")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Largo inválido")]
        public string PasswordHasheada { get; set; }
    }
}