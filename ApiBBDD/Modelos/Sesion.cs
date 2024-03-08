namespace ApiPeliculas.Modelos{
public class Sesion
{
    public int SesionID { get; set; }
    public int PeliculaID { get; set; } // Clave Foranea a Película
    public int SalaID { get; set; } // Clave Foranea a Sala
    public DateTime FechaHora { get; set; } 

    
}}