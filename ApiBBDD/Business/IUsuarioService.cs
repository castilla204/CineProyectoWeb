namespace ApiPeliculas.Business.Services{
using ApiPeliculas.Modelos;
public interface IUsuarioService{


        public List<UsuarioDTO> ObtenerUsuarios();

        public UsuarioDTO ObtenerUsuario(int id);

        public void CrearUsuario(UsuarioCrearDTO usuarioDTO);
    
}}