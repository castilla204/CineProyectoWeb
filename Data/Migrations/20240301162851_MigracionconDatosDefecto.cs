using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class MigracionconDatosDefecto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "SalaID", "NombreSala" },
                values: new object[,]
                {
                    { 3, "Sala 3" },
                    { 4, "Sala 4" }
                });

            migrationBuilder.UpdateData(
                table: "Sesiones",
                keyColumn: "SesionID",
                keyValue: 2,
                columns: new[] { "FechaHora", "PeliculaID", "SalaID" },
                values: new object[] { new DateTime(2024, 3, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 });

            migrationBuilder.InsertData(
                table: "Sesiones",
                columns: new[] { "SesionID", "FechaHora", "PeliculaID", "SalaID" },
                values: new object[,]
                {
                    { 3, new DateTime(2024, 3, 2, 18, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 6, new DateTime(2024, 3, 1, 19, 0, 0, 0, DateTimeKind.Unspecified), 3, 1 },
                    { 7, new DateTime(2024, 3, 1, 22, 0, 0, 0, DateTimeKind.Unspecified), 3, 2 },
                    { 10, new DateTime(2024, 3, 2, 19, 0, 0, 0, DateTimeKind.Unspecified), 4, 1 },
                    { 11, new DateTime(2024, 3, 3, 20, 0, 0, 0, DateTimeKind.Unspecified), 4, 2 },
                    { 14, new DateTime(2024, 3, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), 6, 1 },
                    { 15, new DateTime(2024, 3, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), 6, 2 },
                    { 18, new DateTime(2024, 3, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), 8, 1 },
                    { 19, new DateTime(2024, 3, 2, 19, 0, 0, 0, DateTimeKind.Unspecified), 8, 2 },
                    { 22, new DateTime(2024, 3, 2, 18, 0, 0, 0, DateTimeKind.Unspecified), 9, 1 },
                    { 23, new DateTime(2024, 3, 3, 19, 0, 0, 0, DateTimeKind.Unspecified), 9, 2 },
                    { 26, new DateTime(2024, 3, 3, 18, 0, 0, 0, DateTimeKind.Unspecified), 10, 1 },
                    { 27, new DateTime(2024, 3, 4, 19, 0, 0, 0, DateTimeKind.Unspecified), 10, 2 }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioID", "Contrasena", "CorreoElectronico", "Nombre", "Rol" },
                values: new object[] { 2, "admin", "admin@gmail.com", "admin", 1 });

            migrationBuilder.InsertData(
                table: "Butacas",
                columns: new[] { "ButacaID", "SalaID" },
                values: new object[,]
                {
                    { 121, 3 },
                    { 122, 3 },
                    { 123, 3 },
                    { 124, 3 },
                    { 125, 3 },
                    { 126, 3 },
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
                    { 162, 3 }
                });

            migrationBuilder.InsertData(
                table: "Butacas",
                columns: new[] { "ButacaID", "SalaID" },
                values: new object[,]
                {
                    { 163, 3 },
                    { 164, 3 },
                    { 165, 3 },
                    { 166, 3 },
                    { 167, 3 },
                    { 168, 3 },
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
                    { 204, 4 }
                });

            migrationBuilder.InsertData(
                table: "Butacas",
                columns: new[] { "ButacaID", "SalaID" },
                values: new object[,]
                {
                    { 205, 4 },
                    { 206, 4 },
                    { 207, 4 },
                    { 208, 4 },
                    { 209, 4 },
                    { 210, 4 },
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
                    { 4, new DateTime(2024, 3, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), 2, 3 },
                    { 5, new DateTime(2024, 3, 2, 16, 0, 0, 0, DateTimeKind.Unspecified), 2, 4 },
                    { 8, new DateTime(2024, 3, 2, 20, 0, 0, 0, DateTimeKind.Unspecified), 3, 3 },
                    { 9, new DateTime(2024, 3, 3, 17, 0, 0, 0, DateTimeKind.Unspecified), 3, 4 },
                    { 12, new DateTime(2024, 3, 2, 21, 0, 0, 0, DateTimeKind.Unspecified), 5, 3 },
                    { 13, new DateTime(2024, 3, 3, 18, 0, 0, 0, DateTimeKind.Unspecified), 5, 4 }
                });

            migrationBuilder.InsertData(
                table: "Sesiones",
                columns: new[] { "SesionID", "FechaHora", "PeliculaID", "SalaID" },
                values: new object[,]
                {
                    { 16, new DateTime(2024, 3, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), 7, 3 },
                    { 17, new DateTime(2024, 3, 2, 19, 0, 0, 0, DateTimeKind.Unspecified), 7, 4 },
                    { 20, new DateTime(2024, 3, 3, 20, 0, 0, 0, DateTimeKind.Unspecified), 8, 3 },
                    { 21, new DateTime(2024, 3, 4, 17, 0, 0, 0, DateTimeKind.Unspecified), 8, 4 },
                    { 24, new DateTime(2024, 3, 4, 20, 0, 0, 0, DateTimeKind.Unspecified), 9, 3 },
                    { 25, new DateTime(2024, 3, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), 9, 4 },
                    { 28, new DateTime(2024, 3, 5, 20, 0, 0, 0, DateTimeKind.Unspecified), 10, 3 },
                    { 29, new DateTime(2024, 3, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), 10, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 228);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 234);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 235);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 236);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 237);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 238);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 239);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "ButacaID",
                keyValue: 240);

            migrationBuilder.DeleteData(
                table: "Sesiones",
                keyColumn: "SesionID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sesiones",
                keyColumn: "SesionID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sesiones",
                keyColumn: "SesionID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Sesiones",
                keyColumn: "SesionID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Sesiones",
                keyColumn: "SesionID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Sesiones",
                keyColumn: "SesionID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Sesiones",
                keyColumn: "SesionID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Sesiones",
                keyColumn: "SesionID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Sesiones",
                keyColumn: "SesionID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Sesiones",
                keyColumn: "SesionID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Sesiones",
                keyColumn: "SesionID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Sesiones",
                keyColumn: "SesionID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Sesiones",
                keyColumn: "SesionID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Sesiones",
                keyColumn: "SesionID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Sesiones",
                keyColumn: "SesionID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Sesiones",
                keyColumn: "SesionID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Sesiones",
                keyColumn: "SesionID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Sesiones",
                keyColumn: "SesionID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Sesiones",
                keyColumn: "SesionID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Sesiones",
                keyColumn: "SesionID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Sesiones",
                keyColumn: "SesionID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Sesiones",
                keyColumn: "SesionID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Sesiones",
                keyColumn: "SesionID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Sesiones",
                keyColumn: "SesionID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Sesiones",
                keyColumn: "SesionID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Sesiones",
                keyColumn: "SesionID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Sesiones",
                keyColumn: "SesionID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Salas",
                keyColumn: "SalaID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Salas",
                keyColumn: "SalaID",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Sesiones",
                keyColumn: "SesionID",
                keyValue: 2,
                columns: new[] { "FechaHora", "PeliculaID", "SalaID" },
                values: new object[] { new DateTime(2024, 2, 28, 19, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 });
        }
    }
}
