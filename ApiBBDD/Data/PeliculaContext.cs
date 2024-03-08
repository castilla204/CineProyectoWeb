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
            Titulo = "THE MEG 2: THE TRENCH",
            Director = "John Smith",
            Actores = "Jason Statham, Li Bingbing",
            Descripcion = "En esta emocionante secuela, Jason Statham regresa como el experto buceador Jonas Taylor, enfrentándose una vez más al megalodón, el gigantesco tiburón prehistórico. La historia lleva a los personajes a nuevas y aterradoras profundidades en una trinchera inexplorada del océano, donde los secretos oscuros y peligros mortales aguardan en las sombrías aguas."
        },
        new Pelicula{
            PeliculaID = 2,
            Imagen = "2.png",
            Titulo = "EL HOYO",
            Director = "Galder Gaztelu-Urrutia",
            Actores = "Iván Massagué, Antonia San Juan",
            Descripcion = "En un futuro distópico, 'El Hoyo' presenta una sociedad encerrada en una estructura vertical, donde los niveles determinan tu supervivencia. Los residentes luchan por su subsistencia mientras la comida desciende de los niveles superiores, dejando a los de abajo con menos y menos. La película explora temas de clase, sociedad y humanidad en un entorno inquietantemente claustrofóbico."
        },
        new Pelicula{
            PeliculaID = 3,
            Imagen = "3.png",
            Titulo = "GRAN TURISMO",
            Director = "Carlos Ruiz",
            Actores = "Antonio Banderas, Penélope Cruz",
            Descripcion = "Basada en el emblemático videojuego, 'Gran Turismo' narra la historia de un joven y talentoso piloto que pasa de las carreras virtuales a las competiciones reales. Bajo la tutela de un veterano piloto, interpretado por Antonio Banderas, el protagonista enfrentará desafíos tanto en la pista como en su vida personal, en una historia llena de velocidad, pasión y superación."
        },
        new Pelicula{
            PeliculaID = 4,
            Imagen = "4.png",
            Titulo = "1917",
            Director = "Sam Mendes",
            Actores = "George MacKay, Dean-Charles Chapman",
            Descripcion = "Ambientada en el apogeo de la Primera Guerra Mundial, '1917' sigue a dos soldados británicos en una misión aparentemente imposible que podría salvar miles de vidas. Dirigida con un estilo visual impresionante que simula una toma continua, la película sumerge a los espectadores en la intensidad y desesperación del frente de batalla, destacando el heroísmo, la amistad y la humanidad en tiempos de guerra."
        },
        new Pelicula{
            PeliculaID = 5,
            Imagen = "5.jpg",
            Titulo = "DUNE",
            Director = "Denis Villeneuve",
            Actores = "Timothée Chalamet, Zendaya",
            Descripcion = "En un futuro lejano donde los planetas son gobernados por casas nobiliarias, 'Dune' sigue a Paul Atreides, cuya familia asume el control del planeta desértico Arrakis, fuente del recurso más valioso del universo. Entre conflictos políticos, religiosos y culturales, Paul debe navegar por un terreno peligroso para asegurar el futuro de su familia y su pueblo."
        },
        new Pelicula{
            PeliculaID = 6,
            Imagen = "6.png",
            Titulo = "PARÁSITOS",
            Director = "Bong Joon Ho",
            Actores = "Song Kang-ho, Choi Woo-shik",
            Descripcion = "'Parásitos' es una incisiva crítica social disfrazada de comedia negra, donde dos familias de distintas clases sociales en Corea del Sur se entrelazan en un complejo juego de engaños y ambición. La película analiza la disparidad económica y las pretensiones sociales con una narrativa ingeniosa y giros inesperados, llevando a los espectadores a cuestionar las verdaderas intenciones de cada personaje."
        },
         new Pelicula{
            PeliculaID = 7,
            Imagen = "7.png",
            Titulo = "SUPER MARIO BROS",
            Director = "Roberto Gómez",
            Actores = "Chris Pratt, Jack Black",
            Descripcion = "La clásica franquicia de videojuegos cobra vida en 'Super Mario Bros', una aventura cinematográfica que sigue a Mario y Luigi en su misión para salvar al Reino Champiñón de la tiranía de Bowser. A través de mundos vibrantes y llenos de desafíos, los hermanos plomeros enfrentarán obstáculos y resolverán acertijos, demostrando el poder de la amistad y el coraje. Un homenaje lleno de acción y humor a la icónica serie de juegos."
        },
        new Pelicula{
            PeliculaID = 8,
            Imagen = "8.png",
            Titulo = "EL IRLANDÉS",
            Director = "Martin Scorsese",
            Actores = "Robert De Niro, Al Pacino",
            Descripcion = "Esta épica del crimen organizado, dirigida por el legendario Martin Scorsese, narra la vida de Frank Sheeran, un veterano de guerra que se convierte en sicario de la mafia. 'El Irlandés' explora los oscuros recovecos del crimen organizado en el siglo XX, las conexiones políticas y la desaparición del sindicalista Jimmy Hoffa. Un profundo estudio de personajes y un viaje a través de la historia americana, contado con la maestría narrativa de Scorsese."
        },
        new Pelicula{
            PeliculaID = 9,
            Imagen = "9.png",
            Titulo = "JOKER",
            Director = "Todd Phillips",
            Actores = "Joaquin Phoenix, Robert De Niro",
            Descripcion = "'Joker' ofrece una nueva mirada al icónico villano de Gotham, explorando su origen y su transformación de Arthur Fleck, un hombre ignorado por la sociedad, en el maestro del caos. La película se sumerge en la psicología de su personaje, retratando una sociedad fracturada que ignora a los marginados y crea sus propios monstruos. Un poderoso drama psicológico que desafía las convenciones del género de superhéroes."
        },
        new Pelicula{
            PeliculaID = 10,
            Imagen = "10.png",
            Titulo = "SIN TIEMPO PARA MORIR",
            Director = "Cary Joji Fukunaga",
            Actores = "Daniel Craig, Rami Malek",
            Descripcion = "Daniel Craig regresa como James Bond en 'Sin Tiempo Para Morir', donde el espía se enfrenta a uno de sus desafíos más peligrosos. Retirado del servicio activo, Bond es arrastrado de vuelta al mundo del espionaje cuando un científico es secuestrado, llevándolo al rastro de un misterioso villano armado con una nueva y peligrosa tecnología. La película promete ser un emocionante capítulo final para el icónico personaje, lleno de acción, traición y revelaciones."
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
        PeliculaID=1,
        SalaID=1,
        FechaHora=new DateTime(2024, 3, 1, 15, 0, 0)
    },
    new Sesion{
        SesionID=3,
        PeliculaID=1,
        SalaID=2,
        FechaHora=new DateTime(2024, 3, 2, 18, 0, 0)
    },
    new Sesion{
        SesionID=4,
        PeliculaID=2,
        SalaID=3,
        FechaHora=new DateTime(2024, 3, 1, 20, 0, 0)
    },
    new Sesion{
        SesionID=5,
        PeliculaID=2,
        SalaID=4,
        FechaHora=new DateTime(2024, 3, 2, 16, 0, 0)
    },
    new Sesion{
        SesionID=6,
        PeliculaID=3,
        SalaID=1,
        FechaHora=new DateTime(2024, 3, 1, 19, 0, 0)
    },
    new Sesion{
        SesionID=7,
        PeliculaID=3,
        SalaID=2,
        FechaHora=new DateTime(2024, 3, 1, 22, 0, 0)
    },
    new Sesion{
        SesionID=8,
        PeliculaID=3,
        SalaID=3,
        FechaHora=new DateTime(2024, 3, 2, 20, 0, 0)
    },
    new Sesion{
        SesionID=9,
        PeliculaID=3,
        SalaID=4,
        FechaHora=new DateTime(2024, 3, 3, 17, 0, 0)
    },
  
    new Sesion{
        SesionID=10,
        PeliculaID=4,
        SalaID=1,
        FechaHora=new DateTime(2024, 3, 2, 19, 0, 0)
    },
    new Sesion{
        SesionID=11,
        PeliculaID=4,
        SalaID=2,
        FechaHora=new DateTime(2024, 3, 3, 20, 0, 0)
    },
    new Sesion{
        SesionID=12,
        PeliculaID=5,
        SalaID=3,
        FechaHora=new DateTime(2024, 3, 2, 21, 0, 0)
    },
    new Sesion{
        SesionID=13,
        PeliculaID=5,
        SalaID=4,
        FechaHora=new DateTime(2024, 3, 3, 18, 0, 0)
    },
    new Sesion{
        SesionID=14,
        PeliculaID=6,
        SalaID=1,
        FechaHora=new DateTime(2024, 3, 1, 20, 0, 0)
    },
    new Sesion{
        SesionID=15,
        PeliculaID=6,
        SalaID=2,
        FechaHora=new DateTime(2024, 3, 2, 17, 0, 0)
    },
    new Sesion{
        SesionID=16,
        PeliculaID=7,
        SalaID=3,
        FechaHora=new DateTime(2024, 3, 1, 17, 0, 0)
    },
    new Sesion{
        SesionID=17,
        PeliculaID=7,
        SalaID=4,
        FechaHora=new DateTime(2024, 3, 2, 19, 0, 0)
    },
    
    new Sesion{
        SesionID=18,
        PeliculaID=8,
        SalaID=1,
        FechaHora=new DateTime(2024, 3, 1, 18, 0, 0)
    },
    new Sesion{
        SesionID=19,
        PeliculaID=8,
        SalaID=2,
        FechaHora=new DateTime(2024, 3, 2, 19, 0, 0)
    },
    new Sesion{
        SesionID=20,
        PeliculaID=8,
        SalaID=3,
        FechaHora=new DateTime(2024, 3, 3, 20, 0, 0)
    },
    new Sesion{
        SesionID=21,
        PeliculaID=8,
        SalaID=4,
        FechaHora=new DateTime(2024, 3, 4, 17, 0, 0)
    },
    new Sesion{
        SesionID=22,
        PeliculaID=9,
        SalaID=1,
        FechaHora=new DateTime(2024, 3, 2, 18, 0, 0)
    },
    new Sesion{
        SesionID=23,
        PeliculaID=9,
        SalaID=2,
        FechaHora=new DateTime(2024, 3, 3, 19, 0, 0)
    },
    new Sesion{
        SesionID=24,
        PeliculaID=9,
        SalaID=3,
        FechaHora=new DateTime(2024, 3, 4, 20, 0, 0)
    },
    new Sesion{
        SesionID=25,
        PeliculaID=9,
        SalaID=4,
        FechaHora=new DateTime(2024, 3, 5, 17, 0, 0)
    },
    new Sesion{
        SesionID=26,
        PeliculaID=10,
        SalaID=1,
        FechaHora=new DateTime(2024, 3, 3, 18, 0, 0)
    },
    new Sesion{
        SesionID=27,
        PeliculaID=10,
        SalaID=2,
        FechaHora=new DateTime(2024, 3, 4, 19, 0, 0)
    },
    new Sesion{
        SesionID=28,
        PeliculaID=10,
        SalaID=3,
        FechaHora=new DateTime(2024, 3, 5, 20, 0, 0)
    },
    new Sesion{
        SesionID=29,
        PeliculaID=10,
        SalaID=4,
        FechaHora=new DateTime(2024, 3, 6, 17, 0, 0)
    }
    );
        


            
            var salas = new List<Sala>
            {
                new Sala { SalaID = 1, NombreSala = "Sala 1" },
                new Sala { SalaID = 2, NombreSala = "Sala 2" },
                new Sala { SalaID = 3, NombreSala = "Sala 3" },
                new Sala { SalaID = 4, NombreSala = "Sala 4" }
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
                },
                    new Usuario{
                    UsuarioID=2,
                    Nombre="admin",
                    CorreoElectronico="admin@gmail.com",
                    Contrasena="admin",
                    Rol=RolAlumno.Administrador
                }

            
            );

            
            modelBuilder.Entity<Reserva>().HasData(
            new Reserva {
                ReservaID = 1,
                SesionID = 1,
                UsuarioID = 1
           
            },
            new Reserva {
                ReservaID = 2,
                SesionID = 2,
                UsuarioID = 1
          
            }
            );


        modelBuilder.Entity<ReservaButaca>().HasData(
            new ReservaButaca {
                 ReservaID = 1, 
                 ButacaID = 1 
            },
            new ReservaButaca { 
                ReservaID = 1, 
                ButacaID = 2 
            },
            new ReservaButaca { 
            ReservaID = 2, 
            ButacaID = 3 
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
                        
            modelBuilder.Entity<ReservaButaca>()
                .HasKey(rb => new { rb.ReservaID, rb.ButacaID });

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
                .HasMany(b => b.ReservaButacas)
                .WithOne(r => r.Butaca)
                .HasForeignKey(r => r.ButacaID)
                .OnDelete(DeleteBehavior.Restrict); // Prevenir eliminación en cascada de reservas

            // Usuario -> Reservas
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Reservas)
                .WithOne(r => r.Usuario)
                .HasForeignKey(r => r.UsuarioID)
                .OnDelete(DeleteBehavior.Restrict); // Prevenir eliminación en cascada de reservas


            //Relaccion muchos a miuchos desde Reserva a Butaca
            modelBuilder.Entity<ReservaButaca>()
                    .HasOne(rb => rb.Reserva)
                    .WithMany(r => r.ReservaButacas)
                    .HasForeignKey(rb => rb.ReservaID);

            // Relaccion uno a muchos desde Butaca hacia ReservaButaca, 
             modelBuilder.Entity<ReservaButaca>()
                    .HasOne(rb => rb.Butaca)
                    .WithMany(b => b.ReservaButacas)
                    .HasForeignKey(rb => rb.ButacaID);
                        

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ReservaButaca> ReservaButacas { get; set; }
        public DbSet<Usuario> Usuarios {get; set;}
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Sesion> Sesiones {get; set;}
        public DbSet<Sala> Salas {get; set;}
        public DbSet<Butaca> Butacas { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
     
    }
}