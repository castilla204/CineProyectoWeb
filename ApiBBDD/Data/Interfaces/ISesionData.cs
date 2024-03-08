using ApiPeliculas.Modelos;
public interface ISesionData{
public List<Sesion> ObtenerSesiones();
public Sesion ObtenerSesion(int id);
}