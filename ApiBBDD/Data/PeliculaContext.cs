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
                new Pelicula
                {
                    Id = 1,
                    Imagen = "1.jpg",
                    Titulo = "THE MEG 2",
                    Director = "Jon Turtle",
                    Actores = "Philipe Marcus",
                    Descripcion = "Es una película de acción y ciencia ficción dirigida por Jon Turteltaub y estrenada en 2018. La trama gira en torno a un grupo de científicos que deben detener a un megalodón."
                },
                new Pelicula
                {
                    Id = 2,
                    Imagen = "2.png",
                    Titulo = "EL HOYO",
                    Director = "Galder Gaztelu-Urrutia",
                    Actores = "Martin Scorsese",
                    Descripcion = "Es una película de ciencia ficción española dirigida por Galder Gaztelu-Urrutia, lanzada en 2019. La película se centra en un centro de reclusión vertical donde los prisioneros están dispuestos en celdas apiladas, y una plataforma de comida desciende a través de los niveles, dejando a los prisioneros de los niveles superiores con menos comida."
                },
                new Pelicula
                {
                    Id = 3,
                    Imagen = "3.png",
                    Titulo = "SUPER MARIO BROS",
                    Director = "Martin Scorsese",
                    Actores = "Leonardo DiCaprio",
                    Descripcion = "En el colorido Reino Champiñón, Mario y Luigi disfrutan de una vida tranquila como fontaneros hasta que un día, Bowser, el rey de los Koopas, lanza un malévolo plan para robar todos los champiñones mágicos del reino."
                },
                new Pelicula
                {
                    Id = 4,
                    Imagen = "4.png",
                    Titulo = "GRAN TURISMO",
                    Director = "Quentin Tarantino",
                    Actores = "Meryl Streep",
                    Descripcion = "Un talentoso piloto de carreras que, después de una serie de eventos inesperados, se encuentra en la oportunidad de su vida: competir en el torneo de carreras 'Gran Turismo'."
                },
                new Pelicula
                {
                    Id = 5,
                    Imagen = "5.jpg",
                    Titulo = "THE MEG 2",
                    Director = "Alfred Hitchcock",
                    Actores = "Philipe Marcus",
                    Descripcion = "Es una película de acción y ciencia ficción dirigida por Jon Turteltaub y estrenada en 2018. La trama gira en torno a un grupo de científicos que deben detener a un megalodón."
                },
                new Pelicula
                {
                    Id = 6,
                    Imagen = "6.png",
                    Titulo = "EL HOYO",
                    Director = "Ben Wheatley",
                    Actores = "Julia Roberts",
                    Descripcion = "Es una película de ciencia ficción española dirigida por Galder Gaztelu-Urrutia, lanzada en 2019. La película se centra en un centro de reclusión vertical donde los prisioneros están dispuestos en celdas apiladas, y una plataforma de comida desciende a través de los niveles, dejando a los prisioneros de los niveles superiores con menos comida."
                },
                new Pelicula
                {
                    Id = 7,
                    Imagen = "7.png",
                    Titulo = "SUPER MARIO BROS",
                    Director = "Alfred Hitchcock",
                    Actores = "Leonardo DiCaprio",
                    Descripcion = "En el colorido Reino Champiñón, Mario y Luigi disfrutan de una vida tranquila como fontaneros hasta que un día, Bowser, el rey de los Koopas, lanza un malévolo plan para robar todos los champiñones mágicos del reino."
                },
                new Pelicula
                {
                    Id = 8,
                    Imagen = "8.png",
                    Titulo = "GRAN TURISMO",
                    Director = "Quentin Tarantino",
                    Actores = "Meryl Streep",
                    Descripcion = "Un talentoso piloto de carreras que, después de una serie de eventos inesperados, se encuentra en la oportunidad de su vida: competir en el torneo de carreras 'Gran Turismo'."
                },
                new Pelicula
                {
                    Id = 9,
                    Imagen = "9.png",
                    Titulo = "SUPERMARIO BROS",
                    Director = "Ben Wheatley",
                    Actores = "Leonardo DiCaprio",
                    Descripcion = "En el colorido Reino Champiñón, Mario y Luigi disfrutan de una vida tranquila como fontaneros hasta que un día, Bowser, el rey de los Koopas, lanza un malévolo plan para robar todos los champiñones mágicos del reino."
                },
                new Pelicula
                {
                    Id = 10,
                    Imagen = "10.png",
                    Titulo = "GRAN TURISMO",
                    Director = "Quentin Tarantino",
                    Actores = "Meryl Streep",
                    Descripcion = "Un talentoso piloto de carreras que, después de una serie de eventos inesperados, se encuentra en la oportunidad de su vida: competir en el torneo de carreras 'Gran Turismo'."
                }
            );

            base.OnModelCreating(modelBuilder);
        }
         public DbSet<Pelicula> Peliculas { get; set; }
    }
}