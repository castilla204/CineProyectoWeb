namespace ApiPeliculas.Modelos{
public class Sala
{
    public int SalaID { get; set; }
    public string NombreSala { get; set; }


    // Propiedades de navegacion
    public ICollection<Sesion> Sesiones { get; set; }  // Una Sala puede tener muchas Sesiones
    public ICollection<Butaca> Butacas { get; set; }//Una Sala puede tener muchas Butacas
}}