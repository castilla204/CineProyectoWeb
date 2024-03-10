using ApiPeliculas.Business.Services;
using ApiPeliculas.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ApiPeliculas.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaService _reservaService;

        public ReservaController(IReservaService reservaService)
        {
            _reservaService = reservaService ?? throw new ArgumentNullException(nameof(reservaService));
        }

        [HttpGet]
        public IActionResult ObtenerReservas()
        {
            try
            {
                var reservas = _reservaService.ObtenerReservas();
                return Ok(reservas);
            }
            catch (Exception ex)
            {
                return BadRequest($"error al obtener las reservas {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerReservaPorId(int id)
        {
            try
            {
                var reserva = _reservaService.ObtenerReservaPorId(id);
                if (reserva == null)
                {
                    return NotFound($"no hay ninguna reserva con ID '{id}'");
                }
                return Ok(reserva);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error obteniendo la reserva'{id}': {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CrearReserva([FromBody] ReservaCrearDTO reservaCrearDTO)
        {
            try
            {
                _reservaService.CrearReserva(reservaCrearDTO);
                return Ok(new { message = "Reserva creada con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest($"error creacion reserva {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarReserva(int id, [FromBody] ReservaActualizarDTO reservaActualizarDTO)
        {
            try
            {
                _reservaService.ActualizarReserva(id, reservaActualizarDTO);
                return Ok("reserva actualizada");
            }
            catch (Exception ex)
            {
                return BadRequest($"error actualizando reserva con ID '{id}': {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarReserva(int id)
        {
            try
            {
                _reservaService.EliminarReserva(id);
                return Ok($"La reserva con ID '{id}' se ha eliminado");
            }
            catch (Exception ex)
            {
                return BadRequest($"error eliminando la reserva '{id}': {ex.Message}");
            }
        }
    }
}