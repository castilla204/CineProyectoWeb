using Microsoft.AspNetCore.Mvc;
using ApiPeliculas.Business.Services;
using ApiPeliculas.Modelos;
using System;

[ApiController]
[Route("[Controller]")]
public class SesionController : ControllerBase
{
    private readonly ISesionService _sesionService;

    public SesionController(ISesionService sesionService)
    {
        _sesionService = sesionService ?? throw new ArgumentNullException(nameof(sesionService));
    }

    [HttpGet]
    public ActionResult<List<SesionDTO>> ObtenerSesiones()
    {
        try
        {
            var sesiones = _sesionService.ObtenerSesiones();
            return Ok(sesiones);
        }
        catch (Exception ex)
        {
            return BadRequest($"error obteniendo sesiones {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public ActionResult<SesionDTO> ObtenerSesion(int id)
    {
        try
        {
            var sesion = _sesionService.ObtenerSesion(id);
            if (sesion == null)
            {
                return NotFound();
            }
            return Ok(sesion);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error la sesion no existe con '{id}': {ex.Message}");
        }
    }

    [HttpGet("Pelicula/{IdPelicula}")]
    public ActionResult<List<SesionDTO>> ObtenerSesionesPeli(int IdPelicula)
    {
        try
        {
            var sesiones = _sesionService.ObtenerSesionesPeli(IdPelicula);
            return Ok(sesiones);
        }
        catch (Exception ex)
        {
            return BadRequest($"error obteniendo sesiones pelicula con ID '{IdPelicula}': {ex.Message}");
        }
    }

    [HttpPost]
    public IActionResult CrearSesion([FromBody] SesionCrearDTO sesionDTO)
    {
        if (sesionDTO == null)
        {
            return BadRequest("No se han proporcionado datos");
        }
        try
        {
            _sesionService.CrearSesion(sesionDTO);
            return Ok("Sesion creada");
        }
        catch (Exception ex)
        {
            return BadRequest($"error creando sesion {ex.Message}");
        }
    }
}