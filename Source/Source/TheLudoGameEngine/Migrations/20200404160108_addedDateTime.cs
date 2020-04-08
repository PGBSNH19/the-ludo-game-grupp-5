using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheLudoGameEngine.Migrations
{
    public partial class addedDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GameName",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastSaved",
                table: "Games",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameName",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "LastSaved",
                table: "Games");
        }
    }
}
