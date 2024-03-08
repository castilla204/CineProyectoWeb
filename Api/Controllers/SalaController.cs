using ApiPeliculas.Business.Services;
using ApiPeliculas.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ApiPeliculas.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalaController : ControllerBase
    {
        private readonly ISalaService _salaService;

        public SalaController(ISalaService salaService)
        {
            _salaService = salaService ?? throw new ArgumentNullException(nameof(salaService));
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
                return BadRequest($"error obteniendo las salas {ex.Message}");
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
                return BadRequest($"error al obtener sala con id'{id}': {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CrearSala([FromBody] SalaCrearDTO salaCrearDTO)
        {
            if (salaCrearDTO == null)
            {
                return BadRequest("no se han mandado datos");
            }
            try
            {
                _salaService.CrearSala(salaCrearDTO);
                return Ok("sala creada ");
            }
            catch (Exception ex)
            {
                return BadRequest($"error en la creacion {ex.Message}");
            }
        }
    }
}