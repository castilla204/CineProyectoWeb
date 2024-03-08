using ApiPeliculas.Modelos;
using Microsoft.EntityFrameworkCore;

namespace ApiPeliculas.Business.Services{
public class SesionService : ISesionService{
private readonly ISesionData _sesionData;

public SesionService(ISesionData sesionData){
_sesionData=sesionData;
}


public List<Sesion> ObtenerSesiones(){
return _sesionData.ObtenerSesiones();

}

public Sesion ObtenerSesion(int id){
return _sesionData.ObtenerSesion(id);
}
}

}