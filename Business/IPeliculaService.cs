using ApiCine.Modelos;
namespace ApiCine.Business.Services{
public interface IPeliculaService{
List<PeliculaDTO>ObtenerPeliculas();
PeliculaDTO ObtenerPelicula(int id);
void EliminarPelicula(int id);
void CrearPelicula(PeliculaCrearDTO peliculaDTO);
void ActualizarPelicula(int id, PeliculaCrearDTO peliculaDTO);
List<PeliculaSesionesDTO> ObtenerPeliculaSesiones(int id);

}}
