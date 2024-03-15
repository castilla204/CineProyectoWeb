using Microsoft.AspNetCore.Mvc;
using ApiCine.Business.Services;
using ApiCine.Modelos;
using ApiCine.Api.LogErrores;
using System;

[ApiController]
[Route("[Controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;
    private readonly ILogErrores _logErrores;

    public UsuarioController(IUsuarioService usuarioService, ILogErrores logErrores)
    {
        _usuarioService = usuarioService ?? throw new ArgumentNullException(nameof(usuarioService));
        _logErrores = logErrores ?? throw new ArgumentNullException(nameof(logErrores));
    }

    [HttpGet]
    public ActionResult<List<UsuarioDTO>> ObtenerUsuarios()
    {
        try
        {
            var usuarios = _usuarioService.ObtenerUsuarios();
            return Ok(usuarios);
        }
        catch (Exception ex)
        {
            _logErrores.LogError($"Error al obtener los usuarios: {ex.Message}");
            return BadRequest($"Error al obtener los usuarios: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public ActionResult<UsuarioDTO> ObtenerUsuario(int id)
    {
        try
        {
            var usuario = _usuarioService.ObtenerUsuario(id);
            if (usuario == null)
            {
                return BadRequest($"No se encuentra ningún usuario con ID '{id}'");
            }
            return Ok(usuario);
        }
        catch (Exception ex)
        {
            _logErrores.LogError($"El usuario no existe con ID '{id}': {ex.Message}");
            return BadRequest($"El usuario no existe con ID '{id}': {ex.Message}");
        }
    }

    [HttpGet("{usuarioId}/Reservas")]
    public ActionResult<List<UsuarioReservasDTO>> ObtenerUsuarioReservas(int usuarioId)
    {
        try
        {
            var reservasUsuario = _usuarioService.ObtenerUsuarioReservas(usuarioId);
            return Ok(reservasUsuario);
        }
        catch (Exception ex)
        {
            _logErrores.LogError($"Error al obtener las reservas del usuario con ID '{usuarioId}': {ex.Message}");
            return BadRequest($"Error al obtener las reservas del usuario con ID '{usuarioId}': {ex.Message}");
        }
    }

    [HttpPost]
    public IActionResult CrearUsuario([FromBody] UsuarioCrearDTO usuarioDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            _usuarioService.CrearUsuario(usuarioDTO);
            return Ok("Usuario creado satisfactoriamente");
        }
        catch (Exception ex)
        {
            _logErrores.LogError($"Error en la creación de usuario: {ex.Message}");
            return BadRequest($"Error en la creación de usuario: {ex.Message}");
        }
    }
}