using ApiPeliculas.Modelos;
using ApiPeliculas.Business.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ApiPeliculas.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeliculaController : ControllerBase
    {
        private readonly IPeliculaService _peliculaService;

        public PeliculaController(IPeliculaService peliculaService)
        {
            _peliculaService = peliculaService ?? throw new ArgumentNullException(nameof(peliculaService));
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
                return BadRequest($"Error obteniedno las peliculas: {ex.Message}");
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
                    return BadRequest($"no hay ninguna pelicula con ID '{id}'");
                }
                return Ok(pelicula);
            }
            catch (Exception ex)
            {
                return BadRequest($"no existe pelicula con ID '{id}': {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CrearPelicula([FromBody]PeliculaCrearDTO peliculaDTO)
        {
            if (peliculaDTO == null)
            {
                return BadRequest("No se han pasado datos");
            }
            try
            {
                _peliculaService.CrearPelicula(peliculaDTO);
                return Ok("pelicula añadida");
            }
            catch (Exception ex)
            {
                return BadRequest($"error creando pelicula {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarPelicula(int id, [FromBody] PeliculaCrearDTO peliculaDTO)
        {
            if (peliculaDTO == null)
            {
                return BadRequest("Datos o Id invalidos");
            }
            try
            {
                _peliculaService.ActualizarPelicula(id, peliculaDTO);
                return Ok("pelicula actualizada");
            }
            catch (Exception ex)
            {
                return BadRequest($"error obteniendo la pelicula {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarPelicula(int id)
        {
            try
            {
                _peliculaService.EliminarPelicula(id);
                return Ok($"la pelicula con ID '{id}' ha sido eliminada correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest($"error eliminando la pelicula: {ex.Message}");
            }
        }
    }
}