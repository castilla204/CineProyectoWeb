public class SesionDTO
{
    public int SesionID { get; set; }
    public DateTime FechaHora { get; set; }
    public string TituloPelicula { get; set; } // Solo el título de la película, no el objeto Pelicula completo
    public string NombreSala { get; set; } // Solo el nombre de la sala, no el objeto Sala completo

    public string ImagenPelicula {get; set;}

      public List<int> ButacasOcupadasIds { get; set; } = new List<int>(); // Lista para almacenar los IDs de las butacas ocupadas
    // Puedes incluir otros campos específicos necesarios para tu operación o vista
}