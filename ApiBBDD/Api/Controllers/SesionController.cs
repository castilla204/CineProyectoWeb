
using Microsoft.AspNetCore.Mvc;
using ApiPeliculas.Business.Services;
using ApiPeliculas.Modelos;

[ApiController]
[Route("[Controller]")]

public class SesionController: ControllerBase{
private readonly ISesionService _sesionService;
public SesionController(ISesionService sesionService){
_sesionService= sesionService;
}
[HttpGet]
public ActionResult<List<Sesion>> ObtenerSesiones(){
    return _sesionService.ObtenerSesiones();
}

[HttpGet("{id}")]
public ActionResult<Sesion> ObtenerSesion(int id){
return _sesionService.ObtenerSesion(id);
}

}