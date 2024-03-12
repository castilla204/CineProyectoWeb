using Microsoft.AspNetCore.Mvc;
using ApiCine.Business.Services;
using ApiCine.Modelos;
using System;

[ApiController]
[Route("[Controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService ?? throw new ArgumentNullException(nameof(usuarioService));
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
            return BadRequest($"error al obtener los usuarios {ex.Message}");
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
            return BadRequest($"No se encvuentra ningun usuario con ID '{id}'");
        }
        return Ok(usuario);
    }
    catch (Exception ex)
    {
        return BadRequest($"el usuario no existe con ID '{id}': {ex.Message}");
    }
}

    [HttpPost]
    public IActionResult CrearUsuario([FromBody] UsuarioCrearDTO usuarioDTO)
    {
        if (usuarioDTO == null)
        {
            return BadRequest("Datos del usuario no proporcionados");
        }
        try
        {
            _usuarioService.CrearUsuario(usuarioDTO);
            return Ok("Usuario creado satisfactoriamente");
        }
        catch (Exception ex)
        {
            return BadRequest($"error en la creacion {ex.Message}");
        }
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] UsuarioLoginDTO loginDTO)
    {
        try
        {
            var user = _usuarioService.Login(loginDTO.Usuario, loginDTO.PasswordHasheada);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return BadRequest("Credenciales no validas");
            }
        }
        catch (Exception ex)
        {
            return BadRequest($"error al iniciar sesion {ex.Message}");
        }
    }
}