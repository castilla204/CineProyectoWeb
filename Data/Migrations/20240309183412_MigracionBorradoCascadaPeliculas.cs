using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class MigracionBorradoCascadaPeliculas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sesiones_Peliculas_PeliculaID",
                table: "Sesiones");

            migrationBuilder.AddForeignKey(
                name: "FK_Sesiones_Peliculas_PeliculaID",
                table: "Sesiones",
                column: "PeliculaID",
                principalTable: "Peliculas",
                principalColumn: "PeliculaID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sesiones_Peliculas_PeliculaID",
                table: "Sesiones");

            migrationBuilder.AddForeignKey(
                name: "FK_Sesiones_Peliculas_PeliculaID",
                table: "Sesiones",
                column: "PeliculaID",
                principalTable: "Peliculas",
                principalColumn: "PeliculaID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
