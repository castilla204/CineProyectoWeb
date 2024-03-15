using System.ComponentModel.DataAnnotations;

namespace ApiCine.Modelos
{
    public class PeliculaCrearDTO
    {
        [Required(ErrorMessage = "La imagen es requerida")]
        public string Imagen { get; set; }

        [Required(ErrorMessage = "El título es requerido")]
        [StringLength(100, ErrorMessage = "El título no puede tener más de 100 caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "El director es requerido")]
        [StringLength(100, ErrorMessage = "El director no puede tener más de 100 caracteres")]
        public string Director { get; set; }

        [Required(ErrorMessage = "La lista de actores es requerida")]
        public string Actores { get; set; }

        [Required(ErrorMessage = "La descripción es requerida")]
        public string Descripcion { get; set; }
    }
}