using ApiPeliculas.Modelos;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiPeliculas.Modelos{
public class Pelicula
{

    public int PeliculaID { get; set; }

    public string Imagen { get; set; }

    public string Titulo { get; set; }

    public string Director { get; set; }

    public string Actores { get; set; }
    public string Descripcion {get; set;}

    // Propiedad de navegacion
    public  ICollection<Sesion> Sesiones { get; set; }=new HashSet<Sesion>();// Una Película puede tener muchas Sesiones
}}