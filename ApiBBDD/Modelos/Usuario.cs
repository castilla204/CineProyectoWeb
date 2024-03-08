namespace ApiPeliculas.Modelos{
public class Usuario
{
    public int UsuarioID { get; set; }//clave primaria
    public string Nombre { get; set; }
    public string CorreoElectronico { get; set; }
    public string Contrasena { get; set; }              // almacenar de forma segura
    public RolAlumno Rol { get; set; } 
}}