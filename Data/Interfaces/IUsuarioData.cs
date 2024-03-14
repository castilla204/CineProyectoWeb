using ApiCine.Modelos;
public interface IUsuarioData{

public List<UsuarioDTO> ObtenerUsuarios();
public UsuarioDTO ObtenerUsuario(int id);
public void CrearUsuario(Usuario usuario);
List<UsuarioReservasDTO> ObtenerUsuarioReservas(int usuarioId);
public UsuarioDTO Login(string usuario, string passwordHasheada);


}
    