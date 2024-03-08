using ApiPeliculas.Modelos;
namespace ApiPeliculas.Business.Services{
public interface IPeliculaService{
List<PeliculaDTO>ObtenerPeliculas();
PeliculaDTO ObtenerPelicula(int id);
void EliminarPelicula(int id);
void CrearPelicula(PeliculaCrearDTO peliculaDTO);
void ActualizarPelicula(int id, PeliculaCrearDTO peliculaDTO);

}}
