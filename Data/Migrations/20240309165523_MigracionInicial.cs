using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Peliculas",
                columns: table => new
                {
                    PeliculaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Actores = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas", x => x.PeliculaID);
                });

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    SalaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreSala = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.SalaID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioID);
                });

            migrationBuilder.CreateTable(
                name: "Butacas",
                columns: table => new
                {
                    ButacaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Butacas", x => x.ButacaID);
                    table.ForeignKey(
                        name: "FK_Butacas_Salas_SalaID",
                        column: x => x.SalaID,
                        principalTable: "Salas",
                        principalColumn: "SalaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sesiones",
                columns: table => new
                {
                    SesionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeliculaID = table.Column<int>(type: "int", nullable: false),
                    SalaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sesiones", x => x.SesionID);
                    table.ForeignKey(
                        name: "FK_Sesiones_Peliculas_PeliculaID",
                        column: x => x.PeliculaID,
                        principalTable: "Peliculas",
                        principalColumn: "PeliculaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sesiones_Salas_SalaID",
                        column: x => x.SalaID,
                        principalTable: "Salas",
                        principalColumn: "SalaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    ReservaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SesionID = table.Column<int>(type: "int", nullable: false),
                    UsuarioID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.ReservaID);
                    table.ForeignKey(
                        name: "FK_Reservas_Sesiones_SesionID",
                        column: x => x.SesionID,
                        principalTable: "Sesiones",
                        principalColumn: "SesionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservas_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReservaButacas",
                columns: table => new
                {
                    ReservaID = table.Column<int>(type: "int", nullable: false),
                    ButacaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaButacas", x => new { x.ReservaID, x.ButacaID });
                    table.ForeignKey(
                        name: "FK_ReservaButacas_Butacas_ButacaID",
                        column: x => x.ButacaID,
                        principalTable: "Butacas",
                        principalColumn: "ButacaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReservaButacas_Reservas_ReservaID",
                        column: x => x.ReservaID,
                        principalTable: "Reservas",
                        principalColumn: "ReservaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "PeliculaID", "Actores", "Descripcion", "Director", "Imagen", "Titulo" },
                values: new object[,]
                {
                    { 1, "Jason Statham, Li Bingbing", "En esta emocionante secuela, Jason Statham regresa como el experto buceador Jonas Taylor, enfrentándose una vez más al megalodón, el gigantesco tiburón prehistórico. La historia lleva a los personajes a nuevas y aterradoras profundidades en una trinchera inexplorada del océano, donde los secretos oscuros y peligros mortales aguardan en las sombrías aguas.", "John Smith", "1.jpg", "THE MEG 2: THE TRENCH" },
                    { 2, "Iván Massagué, Antonia San Juan", "En un futuro distópico, 'El Hoyo' presenta una sociedad encerrada en una estructura vertical, donde los niveles determinan tu supervivencia. Los residentes luchan por su subsistencia mientras la comida desciende de los niveles superiores, dejando a los de abajo con menos y menos. La película explora temas de clase, sociedad y humanidad en un entorno inquietantemente claustrofóbico.", "Galder Gaztelu-Urrutia", "2.png", "EL HOYO" },
                    { 3, "Antonio Banderas, Penélope Cruz", "Basada en el emblemático videojuego, 'Gran Turismo' narra la historia de un joven y talentoso piloto que pasa de las carreras virtuales a las competiciones reales. Bajo la tutela de un veterano piloto, interpretado por Antonio Banderas, el protagonista enfrentará desafíos tanto en la pista como en su vida personal, en una historia llena de velocidad, pasión y superación.", "Carlos Ruiz", "3.png", "GRAN TURISMO" },
                    { 4, "George MacKay, Dean-Charles Chapman", "Ambientada en el apogeo de la Primera Guerra Mundial, '1917' sigue a dos soldados británicos en una misión aparentemente imposible que podría salvar miles de vidas. Dirigida con un estilo visual impresionante que simula una toma continua, la película sumerge a los espectadores en la intensidad y desesperación del frente de batalla, destacando el heroísmo, la amistad y la humanidad en tiempos de guerra.", "Sam Mendes", "4.png", "1917" },
                    { 5, "Timothée Chalamet, Zendaya", "En un futuro lejano donde los planetas son gobernados por casas nobiliarias, 'Dune' sigue a Paul Atreides, cuya familia asume el control del planeta desértico Arrakis, fuente del recurso más valioso del universo. Entre conflictos políticos, religiosos y culturales, Paul debe navegar por un terreno peligroso para asegurar el futuro de su familia y su pueblo.", "Denis Villeneuve", "5.jpg", "DUNE" },
                    { 6, "Song Kang-ho, Choi Woo-shik", "'Parásitos' es una incisiva crítica social disfrazada de comedia negra, donde dos familias de distintas clases sociales en Corea del Sur se entrelazan en un complejo juego de engaños y ambición. La película analiza la disparidad económica y las pretensiones sociales con una narrativa ingeniosa y giros inesperados, llevando a los espectadores a cuestionar las verdaderas intenciones de cada personaje.", "Bong Joon Ho", "6.png", "PARÁSITOS" },
                    { 7, "Chris Pratt, Jack Black", "La clásica franquicia de videojuegos cobra vida en 'Super Mario Bros', una aventura cinematográfica que sigue a Mario y Luigi en su misión para salvar al Reino Champiñón de la tiranía de Bowser. A través de mundos vibrantes y llenos de desafíos, los hermanos plomeros enfrentarán obstáculos y resolverán acertijos, demostrando el poder de la amistad y el coraje. Un homenaje lleno de acción y humor a la icónica serie de juegos.", "Roberto Gómez", "7.png", "SUPER MARIO BROS" },
                    { 8, "Robert De Niro, Al Pacino", "Esta épica del crimen organizado, dirigida por el legendario Martin Scorsese, narra la vida de Frank Sheeran, un veterano de guerra que se convierte en sicario de la mafia. 'El Irlandés' explora los oscuros recovecos del crimen organizado en el siglo XX, las conexiones políticas y la desaparición del sindicalista Jimmy Hoffa. Un profundo estudio de personajes y un viaje a través de la historia americana, contado con la maestría narrativa de Scorsese.", "Martin Scorsese", "8.png", "EL IRLANDÉS" },
                    { 9, "Joaquin Phoenix, Robert De Niro", "'Joker' ofrece una nueva mirada al icónico villano de Gotham, explorando su origen y su transformación de Arthur Fleck, un hombre ignorado por la sociedad, en el maestro del caos. La película se sumerge en la psicología de su personaje, retratando una sociedad fracturada que ignora a los marginados y crea sus propios monstruos. Un poderoso drama psicológico que desafía las convenciones del género de superhéroes.", "Todd Phillips", "9.png", "JOKER" },
                    { 10, "Daniel Craig, Rami Malek", "Daniel Craig regresa como James Bond en 'Sin Tiempo Para Morir', donde el espía se enfrenta a uno de sus desafíos más peligrosos. Retirado del servicio activo, Bond es arrastrado de vuelta al mundo del espionaje cuando un científico es secuestrado, llevándolo al rastro de un misterioso villano armado con una nueva y peligrosa tecnología. La película promete ser un emocionante capítulo final para el icónico personaje, lleno de acción, traición y revelaciones.", "Cary Joji Fukunaga", "10.png", "SIN TIEMPO PARA MORIR" }
                });

            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "SalaID", "NombreSala" },
                values: new object[,]
                {
                    { 1, "Sala 1" },
                    { 2, "Sala 2" },
                    { 3, "Sala 3" },
                    { 4, "Sala 4" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioID", "Contrasena", "CorreoElectronico", "Nombre", "Rol" },
                values: new object[,]
                {
                    { 1, "00e48a815525529ba9d33f8761a167588fe00c47bc82f515cf791c482ed99ecc", "a26865@svalero.com", "diego", 1 },
                    { 2, "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", "admin@gmail.com", "admin", 1 }
                });

            migrationBuilder.InsertData(
                table: "Butacas",
                columns: new[] { "ButacaID", "SalaID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 1 },
                    { 7, 1 },
                    { 8, 1 },
                    { 9, 1 },
                    { 10, 1 },
                    { 11, 1 },
                    { 12, 1 },
                    { 13, 1 },
                    { 14, 1 },
                    { 15, 1 },
                    { 16, 1 },
                    { 17, 1 },
                    { 18, 1 },
                    { 19, 1 },
                    { 20, 1 },
                    { 21, 1 },
                    { 22, 1 },
                    { 23, 1 },
                    { 24, 1 },
                    { 25, 1 },
                    { 26, 1 },
                    { 27, 1 },
                    { 28, 1 },
                    { 29, 1 },
                    { 30, 1 },
                    { 31, 1 },
                    { 32, 1 },
                    { 33, 1 },
                    { 34, 1 },
                    { 35, 1 },
                    { 36, 1 },
                    { 37, 1 },
                    { 38, 1 },
                    { 39, 1 },
                    { 40, 1 },
                    { 41, 1 },
                    { 42, 1 }
                });

            migrationBuilder.InsertData(
                table: "Butacas",
                columns: new[] { "ButacaID", "SalaID" },
                values: new object[,]
                {
                    { 43, 1 },
                    { 44, 1 },
                    { 45, 1 },
                    { 46, 1 },
                    { 47, 1 },
                    { 48, 1 },
                    { 49, 1 },
                    { 50, 1 },
                    { 51, 1 },
                    { 52, 1 },
                    { 53, 1 },
                    { 54, 1 },
                    { 55, 1 },
                    { 56, 1 },
                    { 57, 1 },
                    { 58, 1 },
                    { 59, 1 },
                    { 60, 1 },
                    { 61, 2 },
                    { 62, 2 },
                    { 63, 2 },
                    { 64, 2 },
                    { 65, 2 },
                    { 66, 2 },
                    { 67, 2 },
                    { 68, 2 },
                    { 69, 2 },
                    { 70, 2 },
                    { 71, 2 },
                    { 72, 2 },
                    { 73, 2 },
                    { 74, 2 },
                    { 75, 2 },
                    { 76, 2 },
                    { 77, 2 },
                    { 78, 2 },
                    { 79, 2 },
                    { 80, 2 },
                    { 81, 2 },
                    { 82, 2 },
                    { 83, 2 },
                    { 84, 2 }
                });

            migrationBuilder.InsertData(
                table: "Butacas",
                columns: new[] { "ButacaID", "SalaID" },
                values: new object[,]
                {
                    { 85, 2 },
                    { 86, 2 },
                    { 87, 2 },
                    { 88, 2 },
                    { 89, 2 },
                    { 90, 2 },
                    { 91, 2 },
                    { 92, 2 },
                    { 93, 2 },
                    { 94, 2 },
                    { 95, 2 },
                    { 96, 2 },
                    { 97, 2 },
                    { 98, 2 },
                    { 99, 2 },
                    { 100, 2 },
                    { 101, 2 },
                    { 102, 2 },
                    { 103, 2 },
                    { 104, 2 },
                    { 105, 2 },
                    { 106, 2 },
                    { 107, 2 },
                    { 108, 2 },
                    { 109, 2 },
                    { 110, 2 },
                    { 111, 2 },
                    { 112, 2 },
                    { 113, 2 },
                    { 114, 2 },
                    { 115, 2 },
                    { 116, 2 },
                    { 117, 2 },
                    { 118, 2 },
                    { 119, 2 },
                    { 120, 2 },
                    { 121, 3 },
                    { 122, 3 },
                    { 123, 3 },
                    { 124, 3 },
                    { 125, 3 },
                    { 126, 3 }
                });

            migrationBuilder.InsertData(
                table: "Butacas",
                columns: new[] { "ButacaID", "SalaID" },
                values: new object[,]
                {
                    { 127, 3 },
                    { 128, 3 },
                    { 129, 3 },
                    { 130, 3 },
                    { 131, 3 },
                    { 132, 3 },
                    { 133, 3 },
                    { 134, 3 },
                    { 135, 3 },
                    { 136, 3 },
                    { 137, 3 },
                    { 138, 3 },
                    { 139, 3 },
                    { 140, 3 },
                    { 141, 3 },
                    { 142, 3 },
                    { 143, 3 },
                    { 144, 3 },
                    { 145, 3 },
                    { 146, 3 },
                    { 147, 3 },
                    { 148, 3 },
                    { 149, 3 },
                    { 150, 3 },
                    { 151, 3 },
                    { 152, 3 },
                    { 153, 3 },
                    { 154, 3 },
                    { 155, 3 },
                    { 156, 3 },
                    { 157, 3 },
                    { 158, 3 },
                    { 159, 3 },
                    { 160, 3 },
                    { 161, 3 },
                    { 162, 3 },
                    { 163, 3 },
                    { 164, 3 },
                    { 165, 3 },
                    { 166, 3 },
                    { 167, 3 },
                    { 168, 3 }
                });

            migrationBuilder.InsertData(
                table: "Butacas",
                columns: new[] { "ButacaID", "SalaID" },
                values: new object[,]
                {
                    { 169, 3 },
                    { 170, 3 },
                    { 171, 3 },
                    { 172, 3 },
                    { 173, 3 },
                    { 174, 3 },
                    { 175, 3 },
                    { 176, 3 },
                    { 177, 3 },
                    { 178, 3 },
                    { 179, 3 },
                    { 180, 3 },
                    { 181, 4 },
                    { 182, 4 },
                    { 183, 4 },
                    { 184, 4 },
                    { 185, 4 },
                    { 186, 4 },
                    { 187, 4 },
                    { 188, 4 },
                    { 189, 4 },
                    { 190, 4 },
                    { 191, 4 },
                    { 192, 4 },
                    { 193, 4 },
                    { 194, 4 },
                    { 195, 4 },
                    { 196, 4 },
                    { 197, 4 },
                    { 198, 4 },
                    { 199, 4 },
                    { 200, 4 },
                    { 201, 4 },
                    { 202, 4 },
                    { 203, 4 },
                    { 204, 4 },
                    { 205, 4 },
                    { 206, 4 },
                    { 207, 4 },
                    { 208, 4 },
                    { 209, 4 },
                    { 210, 4 }
                });

            migrationBuilder.InsertData(
                table: "Butacas",
                columns: new[] { "ButacaID", "SalaID" },
                values: new object[,]
                {
                    { 211, 4 },
                    { 212, 4 },
                    { 213, 4 },
                    { 214, 4 },
                    { 215, 4 },
                    { 216, 4 },
                    { 217, 4 },
                    { 218, 4 },
                    { 219, 4 },
                    { 220, 4 },
                    { 221, 4 },
                    { 222, 4 },
                    { 223, 4 },
                    { 224, 4 },
                    { 225, 4 },
                    { 226, 4 },
                    { 227, 4 },
                    { 228, 4 },
                    { 229, 4 },
                    { 230, 4 },
                    { 231, 4 },
                    { 232, 4 },
                    { 233, 4 },
                    { 234, 4 },
                    { 235, 4 },
                    { 236, 4 },
                    { 237, 4 },
                    { 238, 4 },
                    { 239, 4 },
                    { 240, 4 }
                });

            migrationBuilder.InsertData(
                table: "Sesiones",
                columns: new[] { "SesionID", "FechaHora", "PeliculaID", "SalaID" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 29, 21, 30, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, new DateTime(2024, 3, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 3, new DateTime(2024, 3, 2, 18, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 4, new DateTime(2024, 3, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), 2, 3 },
                    { 5, new DateTime(2024, 3, 2, 16, 0, 0, 0, DateTimeKind.Unspecified), 2, 4 },
                    { 6, new DateTime(2024, 3, 1, 19, 0, 0, 0, DateTimeKind.Unspecified), 3, 1 },
                    { 7, new DateTime(2024, 3, 1, 22, 0, 0, 0, DateTimeKind.Unspecified), 3, 2 },
                    { 8, new DateTime(2024, 3, 2, 20, 0, 0, 0, DateTimeKind.Unspecified), 3, 3 },
                    { 9, new DateTime(2024, 3, 3, 17, 0, 0, 0, DateTimeKind.Unspecified), 3, 4 },
                    { 10, new DateTime(2024, 3, 2, 19, 0, 0, 0, DateTimeKind.Unspecified), 4, 1 },
                    { 11, new DateTime(2024, 3, 3, 20, 0, 0, 0, DateTimeKind.Unspecified), 4, 2 },
                    { 12, new DateTime(2024, 3, 2, 21, 0, 0, 0, DateTimeKind.Unspecified), 5, 3 }
                });

            migrationBuilder.InsertData(
                table: "Sesiones",
                columns: new[] { "SesionID", "FechaHora", "PeliculaID", "SalaID" },
                values: new object[,]
                {
                    { 13, new DateTime(2024, 3, 3, 18, 0, 0, 0, DateTimeKind.Unspecified), 5, 4 },
                    { 14, new DateTime(2024, 3, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), 6, 1 },
                    { 15, new DateTime(2024, 3, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), 6, 2 },
                    { 16, new DateTime(2024, 3, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), 7, 3 },
                    { 17, new DateTime(2024, 3, 2, 19, 0, 0, 0, DateTimeKind.Unspecified), 7, 4 },
                    { 18, new DateTime(2024, 3, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), 8, 1 },
                    { 19, new DateTime(2024, 3, 2, 19, 0, 0, 0, DateTimeKind.Unspecified), 8, 2 },
                    { 20, new DateTime(2024, 3, 3, 20, 0, 0, 0, DateTimeKind.Unspecified), 8, 3 },
                    { 21, new DateTime(2024, 3, 4, 17, 0, 0, 0, DateTimeKind.Unspecified), 8, 4 },
                    { 22, new DateTime(2024, 3, 2, 18, 0, 0, 0, DateTimeKind.Unspecified), 9, 1 },
                    { 23, new DateTime(2024, 3, 3, 19, 0, 0, 0, DateTimeKind.Unspecified), 9, 2 },
                    { 24, new DateTime(2024, 3, 4, 20, 0, 0, 0, DateTimeKind.Unspecified), 9, 3 },
                    { 25, new DateTime(2024, 3, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), 9, 4 },
                    { 26, new DateTime(2024, 3, 3, 18, 0, 0, 0, DateTimeKind.Unspecified), 10, 1 },
                    { 27, new DateTime(2024, 3, 4, 19, 0, 0, 0, DateTimeKind.Unspecified), 10, 2 },
                    { 28, new DateTime(2024, 3, 5, 20, 0, 0, 0, DateTimeKind.Unspecified), 10, 3 },
                    { 29, new DateTime(2024, 3, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), 10, 4 }
                });

            migrationBuilder.InsertData(
                table: "Reservas",
                columns: new[] { "ReservaID", "SesionID", "UsuarioID" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Reservas",
                columns: new[] { "ReservaID", "SesionID", "UsuarioID" },
                values: new object[] { 2, 2, 1 });

            migrationBuilder.InsertData(
                table: "ReservaButacas",
                columns: new[] { "ButacaID", "ReservaID" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "ReservaButacas",
                columns: new[] { "ButacaID", "ReservaID" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "ReservaButacas",
                columns: new[] { "ButacaID", "ReservaID" },
                values: new object[] { 3, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Butacas_SalaID",
                table: "Butacas",
                column: "SalaID");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaButacas_ButacaID",
                table: "ReservaButacas",
                column: "ButacaID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_SesionID",
                table: "Reservas",
                column: "SesionID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_UsuarioID",
                table: "Reservas",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Sesiones_PeliculaID",
                table: "Sesiones",
                column: "PeliculaID");

            migrationBuilder.CreateIndex(
                name: "IX_Sesiones_SalaID",
                table: "Sesiones",
                column: "SalaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservaButacas");

            migrationBuilder.DropTable(
                name: "Butacas");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Sesiones");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Peliculas");

            migrationBuilder.DropTable(
                name: "Salas");
        }
    }
}
