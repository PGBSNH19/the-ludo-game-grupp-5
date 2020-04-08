using Microsoft.EntityFrameworkCore.Migrations;

namespace TheLudoGameEngine.Migrations
{
    public partial class addedStepNBoardCounter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "InEndLap",
                table: "Tokens",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "StepsCounter",
                table: "Tokens",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InEndLap",
                table: "Tokens");

            migrationBuilder.DropColumn(
                name: "StepsCounter",
                table: "Tokens");
        }
    }
}
