using ApiPeliculas.Modelos;
namespace ApiPeliculas.Business.Services{
public interface IButacaService{

public List <Butaca> ObtenerButacas();

public List <Butaca> ObtenerButacasOcupadas();
}}