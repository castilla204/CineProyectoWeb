using ApiCine.Modelos;
using Microsoft.EntityFrameworkCore;

namespace ApiCine.Business.Services{
public class SesionService : ISesionService{
private readonly ISesionData _sesionData;

public SesionService(ISesionData sesionData){
_sesionData=sesionData;
}


public List<SesionDTO> ObtenerSesiones(){
    return _sesionData.ObtenerSesionesDTO();


}

public SesionDTO ObtenerSesion(int id){
    return _sesionData.ObtenerSesion(id);
}



public void CrearSesion(SesionCrearDTO sesionDTO){
var nuevaSesion = new Sesion{
    FechaHora = sesionDTO.FechaHora,
    PeliculaID = sesionDTO.PeliculaID,
    SalaID = sesionDTO.SalaID
    };
_sesionData.CrearSesion(nuevaSesion);
}
}

}