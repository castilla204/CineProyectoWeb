


using ApiPeliculas.Business.Services;
using ApiPeliculas.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace ApiPeliculas.Api.Controllers{

[ApiController]
[Route("[controller]")]
public class ButacaController:ControllerBase{

private readonly IButacaService _butacaService;

public ButacaController(IButacaService butacaService){
_butacaService=butacaService;
}

[HttpGet()]
public ActionResult<List<Butaca>> ObtenerButacas(){
    return _butacaService.ObtenerButacas();
}
[HttpGet("/Ocupadas")]
public ActionResult<List<Butaca>> ObtenerButacasOcupadas(){
    return _butacaService.ObtenerButacasOcupadas();
}


}}