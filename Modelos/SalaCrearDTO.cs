using System.ComponentModel.DataAnnotations;

namespace ApiCine.Modelos
{
    public class SalaCrearDTO
    {
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Largo inválido")]
        public string NombreSala { get; set; }
    }
}