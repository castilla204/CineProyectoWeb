using ApiPeliculas.Business.Services;
using ApiPeliculas.Modelos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiPeliculas.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaService _reservaService;

        public ReservaController(IReservaService reservaService)
        {
            _reservaService = reservaService;
        }

        [HttpGet]
        public ActionResult<List<ReservaDTO>> ObtenerReservas()
        {
            return Ok(_reservaService.ObtenerReservas());
        }

        [HttpGet("{id}")]
        public ActionResult<ReservaDTO> ObtenerReservaPorId(int id)
        {
            var reserva = _reservaService.ObtenerReservaPorId(id);
            if (reserva == null)
            {
                return NotFound();
            }
            return Ok(reserva);
        }

        [HttpPost]
        public IActionResult CrearReserva([FromBody] ReservaCrearDTO reservaCrearDTO)
        {
            _reservaService.CrearReserva(reservaCrearDTO);
            return Ok("Creada");
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarReserva(int id, [FromBody] ReservaActualizarDTO reservaActualizarDTO)
        {
            _reservaService.ActualizarReserva(id, reservaActualizarDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarReserva(int id)
        {
            _reservaService.EliminarReserva(id);
            return NoContent();
        }
    }
}