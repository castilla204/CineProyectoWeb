using ApiCine.Business.Services;
using ApiCine.Modelos;
using ApiCine.Api.LogErrores;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ApiCine.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalaController : ControllerBase
    {
        private readonly ISalaService _salaService;
        private readonly ILogErrores _logErrores;

        public SalaController(ISalaService salaService, ILogErrores logErrores)
        {
            _salaService = salaService ?? throw new ArgumentNullException(nameof(salaService));
            _logErrores = logErrores ?? throw new ArgumentNullException(nameof(logErrores));
        }

        [HttpGet]
        public ActionResult<List<SalaDTO>> ObtenerSalas()
        {
            try
            {
                var salas = _salaService.ObtenerSalas();
                return Ok(salas);
            }
            catch (Exception ex)
            {
                _logErrores.LogError($"Error obteniendo las salas: {ex.Message}");
                return BadRequest($"Error obteniendo las salas: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<SalaDTO> ObtenerSala(int id)
        {
            try
            {
                var sala = _salaService.ObtenerSala(id);
                if (sala == null)
                {
                    return NotFound();
                }
                return Ok(sala);
            }
            catch (Exception ex)
            {
                _logErrores.LogError($"Error al obtener sala con ID '{id}': {ex.Message}");
                return BadRequest($"Error al obtener sala con ID '{id}': {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CrearSala([FromBody] SalaCrearDTO salaCrearDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _salaService.CrearSala(salaCrearDTO);
                return Ok("Sala creada con éxito");
            }
            catch (Exception ex)
            {
                _logErrores.LogError($"Error en la creación de sala: {ex.Message}");
                return BadRequest($"Error en la creación de sala: {ex.Message}");
            }
        }
    }
}