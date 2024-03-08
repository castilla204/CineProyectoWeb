using ApiPeliculas.Business.Services;
using ApiPeliculas.Modelos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiPeliculas.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalaController : ControllerBase
    {
        private readonly ISalaService _salaService;

        public SalaController(ISalaService salaService)
        {
            _salaService = salaService;
        }

        [HttpGet]
        public ActionResult<List<SalaDTO>> ObtenerSalas()
        {
            var salas = _salaService.ObtenerSalas();
            return Ok(salas); 
        }

        [HttpGet("{id}")]
        public ActionResult<SalaDTO> ObtenerSala(int id)
        {
            var sala = _salaService.ObtenerSala(id);
            if (sala == null)
            {
                return NotFound(); 
            }
            return Ok(sala); 
        }

        [HttpPost]
        public IActionResult CrearSala([FromBody] SalaCrearDTO salaCrearDTO)
        {
            _salaService.CrearSala(salaCrearDTO);
            return Ok("Sala creada correctamente"); 
        }
    }
}