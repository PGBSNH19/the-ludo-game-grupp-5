using Microsoft.EntityFrameworkCore.Migrations;

namespace TheLudoGameEngine.Migrations
{
    public partial class newUpdateOnColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StepsCounter",
                table: "Tokens");

            migrationBuilder.AddColumn<int>(
                name: "StepCounter",
                table: "Tokens",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StepCounter",
                table: "Tokens");

            migrationBuilder.AddColumn<int>(
                name: "StepsCounter",
                table: "Tokens",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
