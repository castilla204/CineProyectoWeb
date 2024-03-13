using ApiCine.Modelos;
public interface ISesionData{
public List<SesionDTO> ObtenerSesionesDTO();
public SesionDTO ObtenerSesion(int id);
public void CrearSesion(Sesion sesion);
}