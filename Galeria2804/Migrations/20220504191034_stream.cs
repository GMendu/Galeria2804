using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Galeria2804.Migrations
{
    public partial class stream : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "imagemType",
                table: "Imagens",
                newName: "arquivoType");

            migrationBuilder.RenameColumn(
                name: "imagemTam",
                table: "Imagens",
                newName: "arquivoTam");

            migrationBuilder.RenameColumn(
                name: "imagemName",
                table: "Imagens",
                newName: "arquivoName");

            migrationBuilder.RenameColumn(
                name: "imagemDescricao",
                table: "Imagens",
                newName: "arquivoDescricao");

            migrationBuilder.RenameColumn(
                name: "imagemId",
                table: "Imagens",
                newName: "arquivoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "arquivoType",
                table: "Imagens",
                newName: "imagemType");

            migrationBuilder.RenameColumn(
                name: "arquivoTam",
                table: "Imagens",
                newName: "imagemTam");

            migrationBuilder.RenameColumn(
                name: "arquivoName",
                table: "Imagens",
                newName: "imagemName");

            migrationBuilder.RenameColumn(
                name: "arquivoDescricao",
                table: "Imagens",
                newName: "imagemDescricao");

            migrationBuilder.RenameColumn(
                name: "arquivoId",
                table: "Imagens",
                newName: "imagemId");
        }
    }
}
