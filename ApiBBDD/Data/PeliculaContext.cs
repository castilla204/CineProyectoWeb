using System;
using ApiPeliculas.Modelos;
using Microsoft.EntityFrameworkCore;

namespace ApiPeliculas.Data
{
    public class PeliculaContext : DbContext
    {
        public PeliculaContext(DbContextOptions<PeliculaContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pelicula>().HasData(
                new Pelicula{
                    PeliculaID = 1,
                    Imagen = "1.jpg",
                    Titulo = "THE MEG 2",
                    Director = "Jon Turtle",
                    Actores = "Philipe Marcus",
                    Descripcion = "Es una película de acción y ciencia ficción dirigida por Jon Turteltaub y estrenada en 2018. La trama gira en torno a un grupo de científicos que deben detener a un megalodón."
                },
                new Pelicula{
                    PeliculaID = 2,
                    Imagen = "2.png",
                    Titulo = "EL HOYO",
                    Director = "Galder Gaztelu-Urrutia",
                    Actores = "Martin Scorsese",
                    Descripcion = "Es una película de ciencia ficción española dirigida por Galder Gaztelu-Urrutia, lanzada en 2019. La película se centra en un centro de reclusión vertical donde los prisioneros están dispuestos en celdas apiladas, y una plataforma de comida desciende a través de los niveles, dejando a los prisioneros de los niveles superiores con menos comida."
                },
                new Pelicula{
                    PeliculaID = 3,
                    Imagen = "3.png",
                    Titulo = "SUPER MARIO BROS",
                    Director = "Martin Scorsese",
                    Actores = "Leonardo DiCaprio",
                    Descripcion = "En el colorido Reino Champiñón, Mario y Luigi disfrutan de una vida tranquila como fontaneros hasta que un día, Bowser, el rey de los Koopas, lanza un malévolo plan para robar todos los champiñones mágicos del reino."
                },
                new Pelicula{
                    PeliculaID = 4,
                    Imagen = "4.png",
                    Titulo = "GRAN TURISMO",
                    Director = "Quentin Tarantino",
                    Actores = "Meryl Streep",
                    Descripcion = "Un talentoso piloto de carreras que, después de una serie de eventos inesperados, se encuentra en la oportunidad de su vida: competir en el torneo de carreras 'Gran Turismo'."
                },
                new Pelicula{
                    PeliculaID = 5,
                    Imagen = "5.jpg",
                    Titulo = "THE MEG 2",
                    Director = "Alfred Hitchcock",
                    Actores = "Philipe Marcus",
                    Descripcion = "Es una película de acción y ciencia ficción dirigida por Jon Turteltaub y estrenada en 2018. La trama gira en torno a un grupo de científicos que deben detener a un megalodón."
                },
                new Pelicula{
                    PeliculaID = 6,
                    Imagen = "6.png",
                    Titulo = "EL HOYO",
                    Director = "Ben Wheatley",
                    Actores = "Julia Roberts",
                    Descripcion = "Es una película de ciencia ficción española dirigida por Galder Gaztelu-Urrutia, lanzada en 2019. La película se centra en un centro de reclusión vertical donde los prisioneros están dispuestos en celdas apiladas, y una plataforma de comida desciende a través de los niveles, dejando a los prisioneros de los niveles superiores con menos comida."
                },
                new Pelicula{
                    PeliculaID = 7,
                    Imagen = "7.png",
                    Titulo = "SUPER MARIO BROS",
                    Director = "Alfred Hitchcock",
                    Actores = "Leonardo DiCaprio",
                    Descripcion = "En el colorido Reino Champiñón, Mario y Luigi disfrutan de una vida tranquila como fontaneros hasta que un día, Bowser, el rey de los Koopas, lanza un malévolo plan para robar todos los champiñones mágicos del reino."
                },
                new Pelicula{
                    PeliculaID = 8,
                    Imagen = "8.png",
                    Titulo = "GRAN TURISMO",
                    Director = "Quentin Tarantino",
                    Actores = "Meryl Streep",
                    Descripcion = "Un talentoso piloto de carreras que, después de una serie de eventos inesperados, se encuentra en la oportunidad de su vida: competir en el torneo de carreras 'Gran Turismo'."
                },
                new Pelicula{
                    PeliculaID = 9,
                    Imagen = "9.png",
                    Titulo = "SUPERMARIO BROS",
                    Director = "Ben Wheatley",
                    Actores = "Leonardo DiCaprio",
                    Descripcion = "En el colorido Reino Champiñón, Mario y Luigi disfrutan de una vida tranquila como fontaneros hasta que un día, Bowser, el rey de los Koopas, lanza un malévolo plan para robar todos los champiñones mágicos del reino."
                },
                new Pelicula{
                    PeliculaID = 10,
                    Imagen = "10.png",
                    Titulo = "GRAN TURISMO",
                    Director = "Quentin Tarantino",
                    Actores = "Meryl Streep",
                    Descripcion = "Un talentoso piloto de carreras que, después de una serie de eventos inesperados, se encuentra en la oportunidad de su vida: competir en el torneo de carreras 'Gran Turismo'."
                }

                
            );

            modelBuilder.Entity<Sesion>().HasData(
                new Sesion{
                    SesionID=1,
                    PeliculaID=1,
                    SalaID=1,
                    FechaHora=new DateTime(2024, 2, 30, 21, 30, 0)
                },
                new Sesion{
                    SesionID=2,
                    PeliculaID=2,
                    SalaID=2,
                    FechaHora=new DateTime(2024, 2, 31, 19, 0, 0)
                }
            );
        
            modelBuilder.Entity<Sala>().HasData(
                new Sala{
                    SalaID=1,
                    NombreSala="Sala 1",
                   
                },
                new Sala{
                    SalaID=2,
                    NombreSala="Sala 2"
                }
            );
            
            modelBuilder.Entity<Butaca>().HasData(
                new Butaca{
                    ButacaID=1,
                    SalaID=1,
                    Estado=EstadoButaca.Disponible

                },
                    new Butaca{
                    ButacaID=2,
                    SalaID=1,
                    Estado=EstadoButaca.Reservada
                },
                    new Butaca{
                    ButacaID=3,
                    SalaID=1,
                    Estado=EstadoButaca.Ocupada
                }
            );

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario{
                    UsuarioID=1,
                    Nombre="Juan",
                    CorreoElectronico="Alonsoalvira@gmail.com",
                    Contrasena="1234",
                    Rol=RolAlumno.Administrador
                }
            );

        //Relacciones
            //Definiendo las claves Primarias
            modelBuilder.Entity<Pelicula>()
                .HasKey(p => p.PeliculaID);

            modelBuilder.Entity<Sala>()
                .HasKey(s => s.SalaID);

            modelBuilder.Entity<Sesion>()
                .HasKey(se => se.SesionID);

            modelBuilder.Entity<Butaca>()
                .HasKey(b => b.ButacaID);

            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.UsuarioID);

            modelBuilder.Entity<Reserva>()
                .HasKey(r => r.ReservaID);

            // Definiendo relaciones entre las entidades

            // Relación: Una Sala puede tener muchas Sesiones
            modelBuilder.Entity<Sala>()
                .HasMany(s => s.Sesiones)              // Una Sala puede tener muchas Sesiones
                .WithOne(se => se.Sala)                // Cada Sesión pertenece a una Sala
                .HasForeignKey(se => se.SalaID);      // La clave foránea en la tabla de Sesiones es SalaID

            // Relación: Una Sala puede tener muchas Butacas
            modelBuilder.Entity<Sala>()
                .HasMany(s => s.Butacas)               // Una Sala puede tener muchas Butacas
                .WithOne(b => b.Sala)                  // Cada Butaca pertenece a una Sala
                .HasForeignKey(b => b.SalaID);        // La clave foránea en la tabla de Butacas es SalaID

            // Relación: Una Película puede tener muchas Sesiones
            modelBuilder.Entity<Pelicula>()
                .HasMany(p => p.Sesiones)              // Una Película puede tener muchas Sesiones
                .WithOne(se => se.Pelicula)            // Cada Sesión pertenece a una Película
                .HasForeignKey(se => se.PeliculaID);  // La clave foránea en la tabla de Sesiones es PeliculaID

            // Relación: Una Sesión puede tener muchas Reservas
            modelBuilder.Entity<Sesion>()
                .HasMany(se => se.Reservas)            // Una Sesión puede tener muchas Reservas
                .WithOne(r => r.Sesion)                // Cada Reserva pertenece a una Sesión
                .HasForeignKey(r => r.SesionID);      // La clave foránea en la tabla de Reservas es SesionID

            // Relación: Una Butaca puede tener muchas Reservas
            modelBuilder.Entity<Butaca>()
                .HasMany(b => b.Reservas)              // Una Butaca puede tener muchas Reservas
                .WithOne(r => r.Butaca)                // Cada Reserva pertenece a una Butaca
                .HasForeignKey(r => r.ButacaID);      // La clave foránea en la tabla de Reservas es ButacaID

            // Relación: Un Usuario puede tener muchas Reservas
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Reservas)              // Un Usuario puede tener muchas Reservas
                .WithOne(r => r.Usuario)               // Cada Reserva pertenece a un Usuario
                .HasForeignKey(r => r.UsuarioID);     // La clave foránea en la tabla de Reservas es UsuarioID



            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Usuario> Usuarios {get; set;}
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Sesion> Sesiones {get; set;}
        public DbSet<Sala> Salas {get; set;}
        public DbSet<Butaca> Butacas { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
     
    }
}