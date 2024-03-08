using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class MigracionDatosPorDefecto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaID",
                keyValue: 1,
                column: "Descripcion",
                value: "En esta emocionante secuela, Jason Statham regresa como el experto buceador Jonas Taylor, enfrentándose una vez más al megalodón, el gigantesco tiburón prehistórico. La historia lleva a los personajes a nuevas y aterradoras profundidades en una trinchera inexplorada del océano, donde los secretos oscuros y peligros mortales aguardan en las sombrías aguas.");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaID",
                keyValue: 2,
                column: "Descripcion",
                value: "En un futuro distópico, 'El Hoyo' presenta una sociedad encerrada en una estructura vertical, donde los niveles determinan tu supervivencia. Los residentes luchan por su subsistencia mientras la comida desciende de los niveles superiores, dejando a los de abajo con menos y menos. La película explora temas de clase, sociedad y humanidad en un entorno inquietantemente claustrofóbico.");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaID",
                keyValue: 3,
                column: "Descripcion",
                value: "Basada en el emblemático videojuego, 'Gran Turismo' narra la historia de un joven y talentoso piloto que pasa de las carreras virtuales a las competiciones reales. Bajo la tutela de un veterano piloto, interpretado por Antonio Banderas, el protagonista enfrentará desafíos tanto en la pista como en su vida personal, en una historia llena de velocidad, pasión y superación.");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaID",
                keyValue: 4,
                column: "Descripcion",
                value: "Ambientada en el apogeo de la Primera Guerra Mundial, '1917' sigue a dos soldados británicos en una misión aparentemente imposible que podría salvar miles de vidas. Dirigida con un estilo visual impresionante que simula una toma continua, la película sumerge a los espectadores en la intensidad y desesperación del frente de batalla, destacando el heroísmo, la amistad y la humanidad en tiempos de guerra.");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaID",
                keyValue: 5,
                column: "Descripcion",
                value: "En un futuro lejano donde los planetas son gobernados por casas nobiliarias, 'Dune' sigue a Paul Atreides, cuya familia asume el control del planeta desértico Arrakis, fuente del recurso más valioso del universo. Entre conflictos políticos, religiosos y culturales, Paul debe navegar por un terreno peligroso para asegurar el futuro de su familia y su pueblo.");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaID",
                keyValue: 6,
                column: "Descripcion",
                value: "'Parásitos' es una incisiva crítica social disfrazada de comedia negra, donde dos familias de distintas clases sociales en Corea del Sur se entrelazan en un complejo juego de engaños y ambición. La película analiza la disparidad económica y las pretensiones sociales con una narrativa ingeniosa y giros inesperados, llevando a los espectadores a cuestionar las verdaderas intenciones de cada personaje.");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaID",
                keyValue: 7,
                column: "Descripcion",
                value: "La clásica franquicia de videojuegos cobra vida en 'Super Mario Bros', una aventura cinematográfica que sigue a Mario y Luigi en su misión para salvar al Reino Champiñón de la tiranía de Bowser. A través de mundos vibrantes y llenos de desafíos, los hermanos plomeros enfrentarán obstáculos y resolverán acertijos, demostrando el poder de la amistad y el coraje. Un homenaje lleno de acción y humor a la icónica serie de juegos.");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaID",
                keyValue: 8,
                column: "Descripcion",
                value: "Esta épica del crimen organizado, dirigida por el legendario Martin Scorsese, narra la vida de Frank Sheeran, un veterano de guerra que se convierte en sicario de la mafia. 'El Irlandés' explora los oscuros recovecos del crimen organizado en el siglo XX, las conexiones políticas y la desaparición del sindicalista Jimmy Hoffa. Un profundo estudio de personajes y un viaje a través de la historia americana, contado con la maestría narrativa de Scorsese.");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaID",
                keyValue: 9,
                column: "Descripcion",
                value: "'Joker' ofrece una nueva mirada al icónico villano de Gotham, explorando su origen y su transformación de Arthur Fleck, un hombre ignorado por la sociedad, en el maestro del caos. La película se sumerge en la psicología de su personaje, retratando una sociedad fracturada que ignora a los marginados y crea sus propios monstruos. Un poderoso drama psicológico que desafía las convenciones del género de superhéroes.");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaID",
                keyValue: 10,
                column: "Descripcion",
                value: "Daniel Craig regresa como James Bond en 'Sin Tiempo Para Morir', donde el espía se enfrenta a uno de sus desafíos más peligrosos. Retirado del servicio activo, Bond es arrastrado de vuelta al mundo del espionaje cuando un científico es secuestrado, llevándolo al rastro de un misterioso villano armado con una nueva y peligrosa tecnología. La película promete ser un emocionante capítulo final para el icónico personaje, lleno de acción, traición y revelaciones.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaID",
                keyValue: 1,
                column: "Descripcion",
                value: "Secuela de la película de suspenso y acción submarina enfrentando a un megalodón prehistórico.");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaID",
                keyValue: 2,
                column: "Descripcion",
                value: "Drama de ciencia ficción en un inquietante futuro distópico con un nuevo sistema carcelario.");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaID",
                keyValue: 3,
                column: "Descripcion",
                value: "Aventura de velocidad y superación, inspirada en el famoso videojuego de carreras.");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaID",
                keyValue: 4,
                column: "Descripcion",
                value: "Impresionante relato de la Primera Guerra Mundial centrado en una misión imposible de dos soldados.");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaID",
                keyValue: 5,
                column: "Descripcion",
                value: "Épica historia de ciencia ficción sobre la lucha por el recurso más valioso del universo.");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaID",
                keyValue: 6,
                column: "Descripcion",
                value: "Comedia negra que explora las tensiones de clase a través de la historia de dos familias coreanas.");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaID",
                keyValue: 7,
                column: "Descripcion",
                value: "Adaptación cinematográfica de la icónica serie de videojuegos, siguiendo las aventuras de Mario y Luigi.");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaID",
                keyValue: 8,
                column: "Descripcion",
                value: "Crónica de la vida del mafioso Frank Sheeran y su posible implicación en el caso Hoffa.");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaID",
                keyValue: 9,
                column: "Descripcion",
                value: "Estudio profundo del icónico villano de Gotham, explorando su compleja psique y origen.");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaID",
                keyValue: 10,
                column: "Descripcion",
                value: "La última misión de Daniel Craig como James Bond lo lleva a la persecución de un villano enigmático.");
        }
    }
}
