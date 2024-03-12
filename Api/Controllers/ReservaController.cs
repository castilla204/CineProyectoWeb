using ApiCine.Business.Services;
using ApiCine.Modelos;
using ApiCine.Api.LogErrores;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ApiCine.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaService _reservaService;
        private readonly ILogErrores _logErrores; 

        public ReservaController(IReservaService reservaService, ILogErrores logErrores) 
        {
            _reservaService = reservaService ?? throw new ArgumentNullException(nameof(reservaService));
            _logErrores = logErrores ?? throw new ArgumentNullException(nameof(logErrores));
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
                _logErrores.LogError($"Error obteniendo las reservas: {ex.Message}"); 
                return BadRequest($"Error obteniendo las reservas: {ex.Message}");
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
                    _logErrores.LogError($"No hay ninguna reserva con ID '{id}'"); 
                    return NotFound($"No hay ninguna reserva con ID '{id}'");
                }
                return Ok(reserva);
            }
            catch (Exception ex)
            {
                _logErrores.LogError($"Error obteniendo la reserva '{id}': {ex.Message}");
                return BadRequest($"Error obteniendo la reserva '{id}': {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CrearReserva([FromBody] ReservaCrearDTO reservaCrearDTO)
        {
            try
            {
                _reservaService.CrearReserva(reservaCrearDTO);
                return Ok(new { message = "Reserva creada con éxito" });
            }
            catch (Exception ex)
            {
                _logErrores.LogError($"Error creando reserva: {ex.Message}"); 
                return BadRequest($"Error creando reserva: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarReserva(int id, [FromBody] ReservaActualizarDTO reservaActualizarDTO)
        {
            try
            {
                _reservaService.ActualizarReserva(id, reservaActualizarDTO);
                return Ok("Reserva actualizada con éxito");
            }
            catch (Exception ex)
            {
                _logErrores.LogError($"Error actualizando reserva con ID '{id}': {ex.Message}"); 
                return BadRequest($"Error actualizando reserva con ID '{id}': {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarReserva(int id)
        {
            try
            {
                _reservaService.EliminarReserva(id);
                return Ok($"La reserva con ID '{id}' ha sido eliminada correctamente");
            }
            catch (Exception ex)
            {
                _logErrores.LogError($"Error eliminando la reserva con ID '{id}': {ex.Message}"); 
                return BadRequest($"Error eliminando la reserva con ID '{id}': {ex.Message}");
            }
        }
    }
}