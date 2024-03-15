using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiCine.Modelos
{
    public class PeliculaSesionesDTO
    {
        [Required(ErrorMessage = "El ID de sesión es requerido")]
        public int SesionID { get; set; }

        [Required(ErrorMessage = "La fecha y hora de la sesión son requeridas")]
        public DateTime FechaHora { get; set; }

        [Required(ErrorMessage = "El título de la película es requerido")]
        public string TituloPelicula { get; set; }

        [Required(ErrorMessage = "El nombre de la sala es requerido")]
        public string NombreSala { get; set; }

        [Required(ErrorMessage = "La URL de la imagen de la película es requerida")]
        public string ImagenPelicula { get; set; }

        [Required(ErrorMessage = "La descripción de la película es requerida")]
        public string DescripcionPelicula { get; set; }

        public List<int> ButacasOcupadasIds { get; set; } = new List<int>();
    }
}