using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiCine.Modelos
{
    public class SalaDTO
    {
        [Required(ErrorMessage = "Campo requerido")]
        public int SalaID { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Largo inválido")]
        public string NombreSala { get; set; }

        public List<int> SesionesIds { get; set; } = new List<int>();
    }
}