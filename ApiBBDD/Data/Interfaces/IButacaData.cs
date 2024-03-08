using ApiPeliculas.Modelos;

namespace ApiPeliculas.Data{
public interface IButacaData{
    public List <Butaca> ObtenerButacasOcupadas();
    public List<Butaca> ObtenerButacas();
}}