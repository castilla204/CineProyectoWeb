
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
public ActionResult<List<SesionDTO>> ObtenerSesiones(){
    return _sesionService.ObtenerSesiones();
}

[HttpGet("{id}")]
public ActionResult<SesionDTO> ObtenerSesion(int id){
return _sesionService.ObtenerSesion(id);
}

[HttpGet("Sesion/{IdPelicula}")]
public List<SesionDTO> ObtenerSesionesPeli(int IdPelicula){
    return _sesionService.ObtenerSesionesPeli(IdPelicula);
}

[HttpPost]
public IActionResult CrearSesion([FromBody]SesionCrearDTO sesionDTO){
_sesionService.CrearSesion(sesionDTO);
return Ok("SesionCreada");

}

}