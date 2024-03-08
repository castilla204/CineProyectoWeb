
using Microsoft.AspNetCore.Mvc;
using ApiPeliculas.Business.Services;
using ApiPeliculas.Modelos;

[ApiController]
[Route("[Controller]")]

public class UsuarioController: ControllerBase{
private readonly IUsuarioService _usuarioService;
public UsuarioController(IUsuarioService usuarioService){
_usuarioService= usuarioService;
}
[HttpGet]
public ActionResult<List<UsuarioDTO>> ObtenerUsuarios(){
    return _usuarioService.ObtenerUsuarios();
}

[HttpGet("{id}")]
public ActionResult<UsuarioDTO> ObtenerUsuario(int id){
return _usuarioService.ObtenerUsuario(id);
}

[HttpPost]
public IActionResult CrearSesion([FromBody]UsuarioCrearDTO usuarioDTO){
_usuarioService.CrearUsuario(usuarioDTO);
return Ok("UsuarioCreado");

}

}