using System.Security.Cryptography;
using ApiCine.Modelos;
namespace ApiCine.Data{
public interface IAuthData{
  void CrearUsuario(Usuario usuario);
   UsuarioDTO Login(string usuario, string passwordHasheada);
}}