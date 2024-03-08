public class SesionDTO
{
    public int SesionID { get; set; }
    public DateTime FechaHora { get; set; }
    public string TituloPelicula { get; set; }
    public string NombreSala { get; set; }
    public string ImagenPelicula {get; set;}
    public string DescripcionPelicula {get; set;}

      public List<int> ButacasOcupadasIds { get; set; } = new List<int>(); 
}