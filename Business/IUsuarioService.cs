namespace ApiCine.Business.Services{
using ApiCine.Modelos;
public interface IUsuarioService{


        public List<UsuarioDTO> ObtenerUsuarios();

        public UsuarioDTO ObtenerUsuario(int id);

        public void CrearUsuario(UsuarioCrearDTO usuarioDTO);
        public UsuarioDTO Login(string usuario, string passwordHasheada);
    
}}