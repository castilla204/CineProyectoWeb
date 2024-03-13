namespace ApiCine.Modelos{
    using System.ComponentModel.DataAnnotations;
        public class PeliculaCrearDTO
        {
        [Required(ErrorMessage = "La ruta de la imagen es obligatoria")]
        public string Imagen { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "La longitud del título debe estar entre 1 y 100 caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "El director es obligatorio")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "La longitud del nombre del director debe estar entre 1 y 50 caracteres")]
        public string Director { get; set; }

        [Required(ErrorMessage = "La lista de actores es obligatoria")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "La longitud de la lista de actores debe estar entre 1 y 255 caracteres")]
        public string Actores { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "La longitud de la descripción debe estar entre 1 y 255 caracteres")]
        public string Descripcion { get; set; }

}}