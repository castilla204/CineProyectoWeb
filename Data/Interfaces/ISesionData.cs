using ApiCine.Modelos;
public interface ISesionData{
public List<SesionDTO> ObtenerSesionesDTO();
public SesionDTO ObtenerSesion(int id);
public List<SesionDTO> ObtenerSesionesPeli(int IdPelicula);
public void CrearSesion(Sesion sesion);
}