using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmeAPI.Migrations
{
    public partial class InserindocolunadeclassificacaoEtaria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassificacaoEtaria",
                table: "Filmes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassificacaoEtaria",
                table: "Filmes");
        }
    }
}
