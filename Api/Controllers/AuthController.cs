using Microsoft.AspNetCore.Mvc;
using ApiCine.Business.Services;
using ApiCine.Api.LogErrores;
using ApiCine.Modelos;
using System;

namespace ApiCine.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ILogErrores _logErrores;

        public AuthController(IUsuarioService usuarioService, ILogErrores logErrores)
        {
            _usuarioService = usuarioService ?? throw new ArgumentNullException(nameof(usuarioService));
            _logErrores = logErrores ?? throw new ArgumentNullException(nameof(logErrores));
        }

        [HttpPost("Register")]
        public IActionResult CrearUsuario([FromBody] UsuarioCrearDTO usuarioDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _usuarioService.CrearUsuario(usuarioDTO);
                return Ok("Usuario creado correctamente");
            }
            catch (Exception ex)
            {
                _logErrores.LogError($"Error ecreando usuario: {ex.Message}");
                return BadRequest($"Errorcreando usuario {ex.Message}");
            }
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] UsuarioLoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = _usuarioService.Login(loginDTO.Usuario, loginDTO.PasswordHasheada);
                if (user != null)
                {
                    return Ok(user);
                }
                else
                {
                    return BadRequest("Contraseña o usuario Incorrectos");
                }
            }
            catch (Exception ex)
            {
                _logErrores.LogError($"Error iniciando sesion: {ex.Message}");
                return BadRequest($"Error iniciando sesion: {ex.Message}");
            }
        }
    }
}