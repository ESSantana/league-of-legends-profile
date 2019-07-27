using Microsoft.EntityFrameworkCore.Migrations;

namespace LoLStats.Migrations
{
    public partial class FinalDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "regiao",
                table: "perfil",
                type: "nvarchar(30)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "regiao",
                table: "perfil");
        }
    }
}
