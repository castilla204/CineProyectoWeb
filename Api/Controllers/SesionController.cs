using Microsoft.AspNetCore.Mvc;
using ApiCine.Business.Services;
using ApiCine.Modelos;
using ApiCine.Api.LogErrores;
using System;

[ApiController]
[Route("[Controller]")]
public class SesionController : ControllerBase
{
    private readonly ISesionService _sesionService;
    private readonly ILogErrores _logErrores;

    public SesionController(ISesionService sesionService, ILogErrores logErrores)
    {
        _sesionService = sesionService ?? throw new ArgumentNullException(nameof(sesionService));
        _logErrores = logErrores ?? throw new ArgumentNullException(nameof(logErrores));
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
            _logErrores.LogError($"Error obteniendo sesiones: {ex.Message}");
            return BadRequest($"Error obteniendo sesiones: {ex.Message}");
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
            _logErrores.LogError($"Error obteniendo la sesión con ID '{id}': {ex.Message}");
            return BadRequest($"Error obteniendo la sesión con ID '{id}': {ex.Message}");
        }
    }

    [HttpPost]
    public IActionResult CrearSesion([FromBody] SesionCrearDTO sesionDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            _sesionService.CrearSesion(sesionDTO);
            return Ok("Sesión creada con éxito");
        }
        catch (Exception ex)
        {
            _logErrores.LogError($"Error creando sesión: {ex.Message}");
            return BadRequest($"Error creando sesión: {ex.Message}");
        }
    }
}