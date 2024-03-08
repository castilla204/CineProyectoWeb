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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(false);//dejo aqui la carga diferida desactivada, ya se que esta por defecto dejo la linea por si necesito activarla
            // optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); // Limitar la profundidad de carga
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
                    FechaHora=new DateTime(2024, 2, 29, 21, 30, 0)
                },
                new Sesion{
                    SesionID=2,
                    PeliculaID=2,
                    SalaID=2,
                    FechaHora=new DateTime(2024, 2, 28, 19, 0, 0)
                }
            );
        


            //Creacion de salas y sus correspondientes butacas estas creadas automaticamente para las salas por defecto.
            var salas = new List<Sala>
            {
                new Sala { SalaID = 1, NombreSala = "Sala 1" },
                new Sala { SalaID = 2, NombreSala = "Sala 2" }
            };

            modelBuilder.Entity<Sala>().HasData(salas);

            var totalButacasPorSala = 60; 
            var butacas = new List<Butaca>();

            foreach (var sala in salas)
            {
                for (int butacaNum = 1; butacaNum <= totalButacasPorSala; butacaNum++)
                {
                    butacas.Add(new Butaca
                    {
                        ButacaID = ((sala.SalaID - 1) * totalButacasPorSala) + butacaNum,
                        SalaID = sala.SalaID
                    });
                }
            }
            modelBuilder.Entity<Butaca>().HasData(butacas);
            //






            modelBuilder.Entity<Usuario>().HasData(
                new Usuario{
                    UsuarioID=1,
                    Nombre="Juan",
                    CorreoElectronico="Alonsoalvira@gmail.com",
                    Contrasena="1234",
                    Rol=RolAlumno.Administrador
                }

            
            );
            
            modelBuilder.Entity<Reserva>().HasData(
            new Reserva {
                ReservaID = 1,
                SesionID = 1,
                ButacaID = 1,
                UsuarioID = 1
           
            },
            new Reserva {
                ReservaID = 2,
                SesionID = 2,
                ButacaID = 2,
                UsuarioID = 1
          
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

            // Definiendo las relaciones entre las entidades

             // Sala -> Sesiones
            modelBuilder.Entity<Sala>()
                .HasMany(s => s.Sesiones)
                .WithOne(se => se.Sala)
                .HasForeignKey(se => se.SalaID)
                .OnDelete(DeleteBehavior.Restrict); // Prevenir ciclos en cascada

            // Sala -> Butacas
            modelBuilder.Entity<Sala>()
                .HasMany(s => s.Butacas)
                .WithOne(b => b.Sala)
                .HasForeignKey(b => b.SalaID)
                .OnDelete(DeleteBehavior.Restrict); // Prevenit ciclos en cascada

            // Película -> Sesiones
            modelBuilder.Entity<Pelicula>()
                .HasMany(p => p.Sesiones)
                .WithOne(se => se.Pelicula)
                .HasForeignKey(se => se.PeliculaID)
                .OnDelete(DeleteBehavior.Restrict); // Prevenir ciclos en cascada

            // Sesión -> Reservas
            modelBuilder.Entity<Sesion>()
                .HasMany(se => se.Reservas)
                .WithOne(r => r.Sesion)
                .HasForeignKey(r => r.SesionID)
                .OnDelete(DeleteBehavior.Restrict); // Prevenir eliminación en cascada de reservas

            // Butaca -> Reservas
            modelBuilder.Entity<Butaca>()
                .HasMany(b => b.Reservas)
                .WithOne(r => r.Butaca)
                .HasForeignKey(r => r.ButacaID)
                .OnDelete(DeleteBehavior.Restrict); // Prevenir eliminación en cascada de reservas

            // Usuario -> Reservas
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Reservas)
                .WithOne(r => r.Usuario)
                .HasForeignKey(r => r.UsuarioID)
                .OnDelete(DeleteBehavior.Restrict); // Prevenir eliminación en cascada de reservas


            

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