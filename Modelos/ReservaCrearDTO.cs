using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiCine.Modelos
{
    public class ReservaCrearDTO
    {
        [Required(ErrorMessage = "El ID de la sesión es requerido")]
        public int SesionID { get; set; }

        [Required(ErrorMessage = "El ID del usuario es requerido")]
        public int UsuarioID { get; set; }

        [Required(ErrorMessage = "La lista de IDs de butacas es requerida")]
        public List<int> ButacasIds { get; set; } = new List<int>();
    }
}
