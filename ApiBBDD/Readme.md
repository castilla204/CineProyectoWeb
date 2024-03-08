dotnet tool install --global dotnet-ef --version 6.0.0
docker-compose up --build
dotnet ef migrations add 20240226202918_ReservaButacaMuchosAMuchos -p ./Data/Data.csproj -s ./Api/Api.csproj
dotnet ef database update -p ./Data/Data.csproj -s ./Api/Api.csproj





los modelos utilizados
namespace ApiPeliculas.Modelos
{
    public class Pelicula
    {
        public int PeliculaID { get; set; }
        public string Imagen { get; set; }
        public string Titulo { get; set; }
        public string Director { get; set; }
        public string Actores { get; set; }
        public string Descripcion { get; set; }
        
        // Propiedad de navegación: Una Película puede tener muchas Sesiones
        public ICollection<Sesion> Sesiones { get; set; }
    }

    public class Sala
    {
        public int SalaID { get; set; }
        public string NombreSala { get; set; }

        // Propiedad de navegación: Una Sala puede tener muchas Sesiones
        public ICollection<Sesion> Sesiones { get; set; }

        // Propiedad de navegación: Una Sala puede tener muchas Butacas
        public ICollection<Butaca> Butacas { get; set; }
    }

    public class Sesion
    {
        public int SesionID { get; set; }
        public DateTime FechaHora { get; set; }

        // Claves foráneas
        public int PeliculaID { get; set; }
        public int SalaID { get; set; }

        // Propiedades de navegación
        public Pelicula Pelicula { get; set; }
        public Sala Sala { get; set; }

        // Propiedad de navegación: Una Sesión puede tener muchas Reservas
        public ICollection<Reserva> Reservas { get; set; }
    }

    public class Butaca
    {
        public int ButacaID { get; set; }
        public EstadoButaca Estado { get; set; }

        // Clave foránea
        public int SalaID { get; set; }

        // Propiedad de navegación: Una Butaca puede tener muchas Reservas
        public ICollection<Reserva> Reservas { get; set; }

        // Propiedad de navegación inversa: Una Butaca pertenece a una Sala
        public Sala Sala { get; set; }
    }

    public class Usuario
    {
        public int UsuarioID { get; set; }
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contrasena { get; set; }
        public RolAlumno Rol { get; set; }

        // Propiedad de navegación: Un Usuario puede tener muchas Reservas
        public ICollection<Reserva> Reservas { get; set; }
    }

    public class Reserva
    {
        public int ReservaID { get; set; }

        // Claves foráneas
        public int SesionID { get; set; }
        public int ButacaID { get; set; }
        public int UsuarioID { get; set; }

        // Propiedades de navegación
        public Sesion Sesion { get; set; }
        public Butaca Butaca { get; set; }
        public Usuario Usuario { get; set; }
    }

    public enum EstadoButaca
    {
        Disponible,
        Reservada,
        Ocupada
    }

    public enum RolAlumno
    {
        Administrador,
        Usuario
    }
}