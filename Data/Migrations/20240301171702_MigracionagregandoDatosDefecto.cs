using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class MigracionagregandoDatosDefecto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaID",
                keyValue: 1,
                columns: new[] { "Actores", "Descripcion", "Director", "Titulo" },
                values: new object[] { "Jason Statham, Li Bingbing", "Secuela de la película de suspenso y acción submarina enfrentando a un megalodón prehistórico.", "John Smith", "THE MEG 2: THE TRENCH" });

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaID",
                keyValue: 2,
                columns: new[] { "Actores", "Descripcion" },
                values: new object[] { "Iván Massagué, Antonia San Juan", "Drama de ciencia ficción en un inquietante futuro distópico con un nuevo sistema carcelario." });

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaID",
                keyValue: 3,
                columns: new[] { "Actores", "Descripcion", "Director", "Titulo" },
                values: new object[] { "Antonio Banderas, Penélope Cruz", "Aventura de velocidad y superación, inspirada en el famoso videojuego de carreras.", "Carlos Ruiz", "GRAN TURISMO" });

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaID",
                keyValue: 4,
                columns: new[] { "Actores", "Descripcion", "Director", "Titulo" },
                values: new object[] { "George MacKay, Dean-Charles Chapman", "Impresionante relato de la Primera Guerra Mundial centrado en una misión imposible de dos soldados.", "Sam Mendes", "1917" });

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaID",
                keyValue: 5,
                columns: new[] { "Actores", "Descripcion", "Director", "Titulo" },
                values: new object[] { "Timothée Chalamet, Zendaya", "Épica historia de ciencia ficción sobre la lucha por el recurso más valioso del universo.", "Denis Villeneuve", "DUNE" });

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaID",
                keyValue: 6,
                columns: new[] { "Actores", "Descripcion", "Director", "Titulo" },
                values: new object[] { "Song Kang-ho, Choi Woo-shik", "Comedia negra que explora las tensiones de clase a través de la historia de dos familias coreanas.", "Bong Joon Ho", "PARÁSITOS" });

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaID",
                keyValue: 7,
                columns: new[] { "Actores", "Descripcion", "Director" },
                values: new object[] { "Chris Pratt, Jack Black", "Adaptación cinematográfica de la icónica serie de videojuegos, siguiendo las aventuras de Mario y Luigi.", "Roberto Gómez" });

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaID",
                keyValue: 8,
                columns: new[] { "Actores", "Descripcion", "Director", "Titulo" },
                values: new object[] { "Robert De Niro, Al Pacino", "Crónica de la vida del mafioso Frank Sheeran y su posible implicación en el caso Hoffa.", "Martin Scorsese", "EL IRLANDÉS" });

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaID",
                keyValue: 9,
                columns: new[] { "Actores", "Descripcion", "Director", "Titulo" },
                values: new object[] { "Joaquin Phoenix, Robert De Niro", "Estudio profundo del icónico villano de Gotham, explorando su compleja psique y origen.", "Todd Phillips", "JOKER" });

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaID",
                keyValue: 10,
                columns: new[] { "Actores", "Descripcion", "Director", "Titulo" },
                values: new object[] { "Daniel Craig, Rami Malek", "La última misión de Daniel Craig como James Bond lo lleva a la persecución de un villano enigmático.", "Cary Joji Fukunaga", "SIN TIEMPO PARA MORIR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaID",
                keyValue: 1,
                columns: new[] { "Actores", "Descripcion", "Director", "Titulo" },
                values: new object[] { "Philipe Marcus", "Es una película de acción y ciencia ficción dirigida por Jon Turteltaub y estrenada en 2018. La trama gira en torno a un grupo de científicos que deben detener a un megalodón.", "Jon Turtle", "THE MEG 2" });

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaID",
                keyValue: 2,
                columns: new[] { "Actores", "Descripcion" },
                values: new object[] { "Martin Scorsese", "Es una película de ciencia ficción española dirigida por Galder Gaztelu-Urrutia, lanzada en 2019. La película se centra en un centro de reclusión vertical donde los prisioneros están dispuestos en celdas apiladas, y una plataforma de comida desciende a través de los niveles, dejando a los prisioneros de los niveles superiores con menos comida." });

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaID",
                keyValue: 3,
                columns: new[] { "Actores", "Descripcion", "Director", "Titulo" },
                values: new object[] { "Leonardo DiCaprio", "En el colorido Reino Champiñón, Mario y Luigi disfrutan de una vida tranquila como fontaneros hasta que un día, Bowser, el rey de los Koopas, lanza un malévolo plan para robar todos los champiñones mágicos del reino.", "Martin Scorsese", "SUPER MARIO BROS" });

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaID",
                keyValue: 4,
                columns: new[] { "Actores", "Descripcion", "Director", "Titulo" },
                values: new object[] { "Meryl Streep", "Un talentoso piloto de carreras que, después de una serie de eventos inesperados, se encuentra en la oportunidad de su vida: competir en el torneo de carreras 'Gran Turismo'.", "Quentin Tarantino", "GRAN TURISMO" });

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaID",
                keyValue: 5,
                columns: new[] { "Actores", "Descripcion", "Director", "Titulo" },
                values: new object[] { "Philipe Marcus", "Es una película de acción y ciencia ficción dirigida por Jon Turteltaub y estrenada en 2018. La trama gira en torno a un grupo de científicos que deben detener a un megalodón.", "Alfred Hitchcock", "THE MEG 2" });

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaID",
                keyValue: 6,
                columns: new[] { "Actores", "Descripcion", "Director", "Titulo" },
                values: new object[] { "Julia Roberts", "Es una película de ciencia ficción española dirigida por Galder Gaztelu-Urrutia, lanzada en 2019. La película se centra en un centro de reclusión vertical donde los prisioneros están dispuestos en celdas apiladas, y una plataforma de comida desciende a través de los niveles, dejando a los prisioneros de los niveles superiores con menos comida.", "Ben Wheatley", "EL HOYO" });

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaID",
                keyValue: 7,
                columns: new[] { "Actores", "Descripcion", "Director" },
                values: new object[] { "Leonardo DiCaprio", "En el colorido Reino Champiñón, Mario y Luigi disfrutan de una vida tranquila como fontaneros hasta que un día, Bowser, el rey de los Koopas, lanza un malévolo plan para robar todos los champiñones mágicos del reino.", "Alfred Hitchcock" });

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaID",
                keyValue: 8,
                columns: new[] { "Actores", "Descripcion", "Director", "Titulo" },
                values: new object[] { "Meryl Streep", "Un talentoso piloto de carreras que, después de una serie de eventos inesperados, se encuentra en la oportunidad de su vida: competir en el torneo de carreras 'Gran Turismo'.", "Quentin Tarantino", "GRAN TURISMO" });

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaID",
                keyValue: 9,
                columns: new[] { "Actores", "Descripcion", "Director", "Titulo" },
                values: new object[] { "Leonardo DiCaprio", "En el colorido Reino Champiñón, Mario y Luigi disfrutan de una vida tranquila como fontaneros hasta que un día, Bowser, el rey de los Koopas, lanza un malévolo plan para robar todos los champiñones mágicos del reino.", "Ben Wheatley", "SUPERMARIO BROS" });

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaID",
                keyValue: 10,
                columns: new[] { "Actores", "Descripcion", "Director", "Titulo" },
                values: new object[] { "Meryl Streep", "Un talentoso piloto de carreras que, después de una serie de eventos inesperados, se encuentra en la oportunidad de su vida: competir en el torneo de carreras 'Gran Turismo'.", "Quentin Tarantino", "GRAN TURISMO" });
        }
    }
}
