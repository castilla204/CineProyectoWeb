using System.ComponentModel.DataAnnotations;

namespace ApiCine.Modelos
{
    public class UsuarioReservasDTO
    {
        [Required(ErrorMessage = "Campo requerido")]
        public int ReservaID { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public string TituloPelicula { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public int SalaID { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public DateTime HoraSesion { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public List<int> NumerosAsiento { get; set; }
    }
}