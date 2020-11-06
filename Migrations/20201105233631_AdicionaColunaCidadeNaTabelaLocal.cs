using Microsoft.EntityFrameworkCore.Migrations;

namespace AeroAPI.Migrations
{
    public partial class AdicionaColunaCidadeNaTabelaLocal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Locais",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Locais");
        }
    }
}
