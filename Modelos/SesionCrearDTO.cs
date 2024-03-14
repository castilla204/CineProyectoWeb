using System;
using System.ComponentModel.DataAnnotations;

namespace ApiCine.Modelos
{
    public class SesionCrearDTO
    {
        [Required(ErrorMessage = "Campo requerido")]
        public DateTime FechaHora { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public int PeliculaID { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public int SalaID { get; set; }
    }
}