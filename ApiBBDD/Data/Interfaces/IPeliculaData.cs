using System.Security.Cryptography;
using ApiPeliculas.Modelos;

public interface IPeliculaData{


List<PeliculaDTO> ObtenerPeliculas();
PeliculaDTO ObtenerPelicula(int id);
void EliminarPelicula(int id);
void CrearPelicula(Pelicula pelicula);
void ActualizarPelicula(Pelicula pelicula);

}