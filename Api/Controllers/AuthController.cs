    
    using Microsoft.AspNetCore.Mvc;
    using ApiCine.Business.Services;
    using ApiCine.Modelos;
    using System;



    namespace ApiCine.Api.Controllers{

    [ApiController]
    [Route("[Controller]")]

    public class AuthController : ControllerBase {
    private readonly IUsuarioService _usuarioService;

    public AuthController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService ?? throw new ArgumentNullException(nameof(usuarioService));
    }
   [HttpPost("Register")]
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

    [HttpPost("Login")]
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
    }}
    