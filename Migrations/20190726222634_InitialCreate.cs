using Microsoft.EntityFrameworkCore.Migrations;

namespace LoLStats.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "perfil",
                columns: table => new
                {
                    perfil_id = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    nome = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    fila_ranqueada = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    elo = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    divisao = table.Column<string>(type: "nvarchar(4)", nullable: true),
                    pontos_liga = table.Column<int>(nullable: false),
                    vitorias = table.Column<int>(nullable: false),
                    derrotas = table.Column<int>(nullable: false)
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "perfil");
        }
    }
}
