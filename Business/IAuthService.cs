using ApiCine.Modelos;

namespace ApiCine.Business.Services{
public interface IAuthService{
void CrearUsuario(UsuarioCrearDTO usuarioDTO);

UsuarioDTO Login(string usuario, string passwordHasheada);
}}