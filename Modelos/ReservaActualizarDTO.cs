using System.ComponentModel.DataAnnotations;

namespace ApiCine.Modelos
{
    public class ReservaActualizarDTO
    {
        [Required(ErrorMessage = "El ID de la sesión es requerido")]
        public int SesionID { get; set; }

        [Required(ErrorMessage = "El ID de la butaca es requerido")]
        public int ButacaID { get; set; }

        [Required(ErrorMessage = "El ID del usuario es requerido")]
        public int UsuarioID { get; set; }
    }
}