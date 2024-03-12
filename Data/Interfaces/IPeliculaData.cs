using System.Security.Cryptography;
using ApiCine.Modelos;

public interface IPeliculaData{


List<PeliculaDTO> ObtenerPeliculas();
PeliculaDTO ObtenerPelicula(int id);
void EliminarPelicula(int id);
void CrearPelicula(Pelicula pelicula); 
List<PeliculaSesionesDTO> ObtenerPeliculaSesiones(int id);

void ActualizarPelicula(Pelicula pelicula);

}