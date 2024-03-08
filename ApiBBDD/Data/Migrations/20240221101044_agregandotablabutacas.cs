using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class agregandotablabutacas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Butacas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Butacas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Butacas",
                columns: new[] { "Id", "Estado" },
                values: new object[] { 1, 0 });

            migrationBuilder.InsertData(
                table: "Butacas",
                columns: new[] { "Id", "Estado" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "Butacas",
                columns: new[] { "Id", "Estado" },
                values: new object[] { 3, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Butacas");
        }
    }
}
