namespace ApiPeliculas.Modelos{
public class Sesion
{
    public int SesionID { get; set; }
    public DateTime FechaHora { get; set; } 
    public int PeliculaID { get; set; } // Clave Foranea a Película
    public int SalaID { get; set; } // Clave Foranea a Sala


    //Propiedades de Navegacion
    public Pelicula Pelicula { get; set; }//una sesion puede tener una pelicula asignada
    public Sala Sala { get; set; }//una sesion puede tener una sala asignada
    public ICollection<Reserva> Reservas { get; set; } //Una sesion puede tener muchas reservas


    
}}