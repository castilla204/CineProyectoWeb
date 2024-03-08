using ApiPeliculas.Modelos;
public interface IUsuarioData{

public List<UsuarioDTO> ObtenerUsuarios();
public UsuarioDTO ObtenerUsuario(int id);
public void CrearUsuario(Usuario usuario);


}
    