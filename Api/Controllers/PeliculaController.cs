using ApiCine.Modelos;
using ApiCine.Business.Services;
using ApiCine.Api.LogErrores;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ApiCine.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeliculaController : ControllerBase
    {
        private readonly IPeliculaService _peliculaService;
        private readonly ILogErrores _logErrores;

        public PeliculaController(IPeliculaService peliculaService, ILogErrores logErrores)
        {
            _peliculaService = peliculaService ?? throw new ArgumentNullException(nameof(peliculaService));
            _logErrores = logErrores ?? throw new ArgumentNullException(nameof(logErrores));
        }

        [HttpGet]
        public IActionResult ObtenerPeliculas()
        {
            try
            {
                var peliculas = _peliculaService.ObtenerPeliculas();
                return Ok(peliculas);
            }
            catch (Exception ex)
            {
                _logErrores.LogError($"Error obteniendo las películas: {ex.Message}");
                return BadRequest($"Error obteniendo las películas: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerPelicula(int id)
        {
            try
            {
                var pelicula = _peliculaService.ObtenerPelicula(id);
                if (pelicula == null)
                {
                    _logErrores.LogError($"No hay ninguna película con ID '{id}'");
                    return NotFound($"No hay ninguna película con ID '{id}'");
                }
                return Ok(pelicula);
            }
            catch (Exception ex)
            {
                _logErrores.LogError($"Error obteniendo la película con ID {id}: {ex.Message}");
                return BadRequest($"Error obteniendo la película con ID '{id}': {ex.Message}");
            }
        }



        [HttpGet("/Sesiones")]
        public ActionResult <List<PeliculaSesionesDTO>> ObtenerPeliculaSesiones(int id){
        var sesiones=_peliculaService.ObtenerPeliculaSesiones(id);
        return Ok(sesiones);

        }

        [HttpPost]
        public IActionResult CrearPelicula([FromBody] PeliculaCrearDTO peliculaDTO)
        {
            if (peliculaDTO == null)
            {
                _logErrores.LogError("Intento de crear una película sin proporcionar datos");
                return BadRequest("No se han proporcionado datos para la película");
            }
            try
            {
                _peliculaService.CrearPelicula(peliculaDTO);
                return Ok("Película añadida con éxito");
            }
            catch (Exception ex)
            {
                _logErrores.LogError($"Error creando la película: {ex.Message}");
                return BadRequest($"Error creando la película: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarPelicula(int id, [FromBody] PeliculaCrearDTO peliculaDTO)
        {
            if (peliculaDTO == null)
            {
                _logErrores.LogError($"Intento de actualizar una película sin datos: ID {id}");
                return BadRequest("Datos o ID inválidos");
            }
            try
            {
                _peliculaService.ActualizarPelicula(id, peliculaDTO);
                return Ok("Película actualizada con éxito");
            }
            catch (Exception ex)
            {
                _logErrores.LogError($"Error actualizando la película con ID {id}: {ex.Message}");
                return BadRequest($"Error actualizando la película con ID {id}: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarPelicula(int id)
        {
            try
            {
                _peliculaService.EliminarPelicula(id);
                return Ok($"La película con ID '{id}' ha sido eliminada correctamente");
            }
            catch (Exception ex)
            {
                _logErrores.LogError($"Error eliminando la película con ID {id}: {ex.Message}");
                return BadRequest($"Error eliminando la película con ID {id}: {ex.Message}");
            }
        }
    }
}