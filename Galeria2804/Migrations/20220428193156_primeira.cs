using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Galeria2804.Migrations
{
    public partial class primeira : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Imagens",
                columns: table => new
                {
                    imagemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imagemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imagemTam = table.Column<int>(type: "int", nullable: false),
                    imagemType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imagemDescricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagens", x => x.imagemId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Imagens");
        }
    }
}
