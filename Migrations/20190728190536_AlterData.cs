using Microsoft.EntityFrameworkCore.Migrations;

namespace LoLStats.Migrations
{
    public partial class AlterData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "vitorias",
                table: "perfil",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(10)");

            migrationBuilder.AlterColumn<string>(
                name: "regiao",
                table: "perfil",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "divisao",
                table: "perfil",
                type: "nvarchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "derrotas",
                table: "perfil",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(10)");

            migrationBuilder.AlterColumn<int>(
                name: "pontos_liga",
                table: "perfil",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(10)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "vitorias",
                table: "perfil",
                type: "int(10)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "regiao",
                table: "perfil",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "divisao",
                table: "perfil",
                type: "nvarchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "derrotas",
                table: "perfil",
                type: "int(10)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "pontos_liga",
                table: "perfil",
                type: "int(10)",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
