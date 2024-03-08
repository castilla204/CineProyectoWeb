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
                    Estado = table.Column<int>(type: "int", nullable: false),
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
                columns: new[] { "ButacaID", "Estado", "SalaID" },
                values: new object[,]
                {
                    { 1, 0, 1 },
                    { 2, 1, 1 },
                    { 3, 2, 1 }
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
