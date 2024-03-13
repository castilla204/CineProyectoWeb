using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiCine.Modelos
{
    public class SesionDTO
    {
        public int SesionID { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public DateTime FechaHora { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Largo inválido")]
        public string TituloPelicula { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Largo inválido")]
        public string NombreSala { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Largo inválido")]
        public string ImagenPelicula { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(500, MinimumLength = 1, ErrorMessage = "Largo inválido")]
        public string DescripcionPelicula { get; set; }

        public List<int> ButacasOcupadasIds { get; set; } = new List<int>();
    }}