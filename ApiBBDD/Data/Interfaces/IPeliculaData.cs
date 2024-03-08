using System.Security.Cryptography;
using ApiPeliculas.Modelos;

public interface IPeliculaData{
List<Pelicula>ObtenerPizzas();
Pelicula ObtenerPizzaPorID(int id);
void EliminarPizza(int id);
void CrearPizza(Pelicula pelicula);
void ActualizarPelicula(Pelicula pelicula);

}