using ApiCine.Business.Services;
using ApiCine.Api.LogErrores;
using ApiCine.Modelos;
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
                _logErrores.LogError($"error obteniendo peliculas: {ex.Message}");
                return BadRequest($"error obteniedno peliculas: {ex.Message}");
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
                    _logErrores.LogError($"No hay pelicula con ID '{id}'");
                    return NotFound($"o hay pelicula con ID'{id}'");
                }
                return Ok(pelicula);
            }
            catch (Exception ex)
            {
                _logErrores.LogError($"No se puede obtener la pelcicula con ID {id}: {ex.Message}");
                return BadRequest($"No se puede obtener la pelicula con ID '{id}': {ex.Message}");
            }
        }

        [HttpGet("{IdPelicula}/Sesiones")]
        public ActionResult<List<PeliculaSesionesDTO>> ObtenerPeliculaSesiones(int IdPelicula)
        {
            var sesiones = _peliculaService.ObtenerPeliculaSesiones(IdPelicula);
            return Ok(sesiones);
        }

        [HttpPost]
        public IActionResult CrearPelicula([FromBody] PeliculaCrearDTO peliculaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (peliculaDTO == null)
            {
                _logErrores.LogError("Datos enviados incorrectos para creacion pelicula");
                return BadRequest("Datos enviados incorrectos para creacion pelicula");
            }
            try
            {
                _peliculaService.CrearPelicula(peliculaDTO);
                return Ok("Película creada");
            }
            catch (Exception ex)
            {
                _logErrores.LogError($"error creando la pelicula: {ex.Message}");
                return BadRequest($"error creando la pelicula: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarPelicula(int id, [FromBody] PeliculaCrearDTO peliculaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (peliculaDTO == null)
            {
                _logErrores.LogError($"datos erroneos o vacios al crear peli {id}");
                return BadRequest("Datos o ID inválidos");
            }
            try
            {
                _peliculaService.ActualizarPelicula(id, peliculaDTO);
                return Ok("Pelicula Creada");
            }
            catch (Exception ex)
            {
                _logErrores.LogError($"eror actualizando la pelicula con ID {id}: {ex.Message}");
                return BadRequest($"error en la actualizacion de peliculas {id}: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarPelicula(int id)
        {
            try
            {
                _peliculaService.EliminarPelicula(id);
                return Ok($"pelicula con ID '{id}' eliminada correctamente");
            }
            catch (Exception ex)
            {
                _logErrores.LogError($" eliminando la pelicula con ID {id}: {ex.Message}");
                return BadRequest($"eliminando la pelicula con ID {id}: {ex.Message}");
            }
        }
    }
}