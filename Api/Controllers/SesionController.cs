using Microsoft.AspNetCore.Mvc;
using ApiCine.Business.Services;
using ApiCine.Modelos;
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