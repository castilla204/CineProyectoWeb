using ApiPeliculas.Modelos;
namespace ApiPeliculas.Business.Services{
public interface IPeliculaService{
List<Pelicula>ObtenerPizzas();
Pelicula ObtenerPizzaPorID(int id);
void EliminarPizza(int id);
void CrearPizza(PeliculaDTO peliculaDTO);
void ActualizarPelicula(int id, PeliculaDTO peliculaDTO);

}}
