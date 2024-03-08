using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class MigracionOptimizada : Migration
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
                    ButacaID = table.Column<int>(type: "int", nullable: false),
                    UsuarioID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.ReservaID);
                    table.ForeignKey(
                        name: "FK_Reservas_Butacas_ButacaID",
                        column: x => x.ButacaID,
                        principalTable: "Butacas",
                        principalColumn: "ButacaID",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "PeliculaID", "Actores", "Descripcion", "Director", "Imagen", "Titulo" },
                values: new object[,]
                {
                    { 1, "Philipe Marcus", "Es una película de acción y ciencia ficción dirigida por Jon Turteltaub y estrenada en 2018. La trama gira en torno a un grupo de científicos que deben detener a un megalodón.", "Jon Turtle", "1.jpg", "THE MEG 2" },
                    { 2, "Martin Scorsese", "Es una película de ciencia ficción española dirigida por Galder Gaztelu-Urrutia, lanzada en 2019. La película se centra en un centro de reclusión vertical donde los prisioneros están dispuestos en celdas apiladas, y una plataforma de comida desciende a través de los niveles, dejando a los prisioneros de los niveles superiores con menos comida.", "Galder Gaztelu-Urrutia", "2.png", "EL HOYO" },
                    { 3, "Leonardo DiCaprio", "En el colorido Reino Champiñón, Mario y Luigi disfrutan de una vida tranquila como fontaneros hasta que un día, Bowser, el rey de los Koopas, lanza un malévolo plan para robar todos los champiñones mágicos del reino.", "Martin Scorsese", "3.png", "SUPER MARIO BROS" },
                    { 4, "Meryl Streep", "Un talentoso piloto de carreras que, después de una serie de eventos inesperados, se encuentra en la oportunidad de su vida: competir en el torneo de carreras 'Gran Turismo'.", "Quentin Tarantino", "4.png", "GRAN TURISMO" },
                    { 5, "Philipe Marcus", "Es una película de acción y ciencia ficción dirigida por Jon Turteltaub y estrenada en 2018. La trama gira en torno a un grupo de científicos que deben detener a un megalodón.", "Alfred Hitchcock", "5.jpg", "THE MEG 2" },
                    { 6, "Julia Roberts", "Es una película de ciencia ficción española dirigida por Galder Gaztelu-Urrutia, lanzada en 2019. La película se centra en un centro de reclusión vertical donde los prisioneros están dispuestos en celdas apiladas, y una plataforma de comida desciende a través de los niveles, dejando a los prisioneros de los niveles superiores con menos comida.", "Ben Wheatley", "6.png", "EL HOYO" },
                    { 7, "Leonardo DiCaprio", "En el colorido Reino Champiñón, Mario y Luigi disfrutan de una vida tranquila como fontaneros hasta que un día, Bowser, el rey de los Koopas, lanza un malévolo plan para robar todos los champiñones mágicos del reino.", "Alfred Hitchcock", "7.png", "SUPER MARIO BROS" },
                    { 8, "Meryl Streep", "Un talentoso piloto de carreras que, después de una serie de eventos inesperados, se encuentra en la oportunidad de su vida: competir en el torneo de carreras 'Gran Turismo'.", "Quentin Tarantino", "8.png", "GRAN TURISMO" },
                    { 9, "Leonardo DiCaprio", "En el colorido Reino Champiñón, Mario y Luigi disfrutan de una vida tranquila como fontaneros hasta que un día, Bowser, el rey de los Koopas, lanza un malévolo plan para robar todos los champiñones mágicos del reino.", "Ben Wheatley", "9.png", "SUPERMARIO BROS" },
                    { 10, "Meryl Streep", "Un talentoso piloto de carreras que, después de una serie de eventos inesperados, se encuentra en la oportunidad de su vida: competir en el torneo de carreras 'Gran Turismo'.", "Quentin Tarantino", "10.png", "GRAN TURISMO" }
                });

            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "SalaID", "NombreSala" },
                values: new object[,]
                {
                    { 1, "Sala 1" },
                    { 2, "Sala 2" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioID", "Contrasena", "CorreoElectronico", "Nombre", "Rol" },
                values: new object[] { 1, "1234", "Alonsoalvira@gmail.com", "Juan", 1 });

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
                    { 120, 2 }
                });

            migrationBuilder.InsertData(
                table: "Sesiones",
                columns: new[] { "SesionID", "FechaHora", "PeliculaID", "SalaID" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 29, 21, 30, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, new DateTime(2024, 2, 28, 19, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Reservas",
                columns: new[] { "ReservaID", "ButacaID", "SesionID", "UsuarioID" },
                values: new object[] { 1, 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Reservas",
                columns: new[] { "ReservaID", "ButacaID", "SesionID", "UsuarioID" },
                values: new object[] { 2, 2, 2, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Butacas_SalaID",
                table: "Butacas",
                column: "SalaID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_ButacaID",
                table: "Reservas",
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
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Butacas");

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
