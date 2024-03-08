namespace ApiPeliculas.Modelos{
public class Usuario
{
    public int UsuarioID { get; set; }//clave primaria
    public string Nombre { get; set; }
    public string CorreoElectronico { get; set; }
    public string Contrasena { get; set; }              
    public RolAlumno Rol { get; set; } 

    // Propiedad de navegación
    public  ICollection<Reserva> Reservas { get; set; }=new HashSet<Reserva>(); //Un Usuario puede tener muchas Reservas
}}