using ApiPeliculas.Modelos;
namespace ApiPeliculas.Business.Services{
public interface ISesionService{
    
public List<SesionDTO> ObtenerSesiones();

public SesionDTO ObtenerSesion(int id);
public List<SesionDTO> ObtenerSesionesPeli(int IdPelicula);
public void CrearSesion(SesionCrearDTO sesionDTO);
}}