using ApiPeliculas.Modelos;
namespace ApiPeliculas.Business.Services{
public interface ISesionService{
    
public List<Sesion> ObtenerSesiones();

public Sesion ObtenerSesion(int id);
}}