using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheLudoGameEngine.Migrations
{
    public partial class dateTimeTupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AtEndLine",
                table: "Tokens");

            migrationBuilder.DropColumn(
                name: "EndLinePosition",
                table: "Tokens");

            migrationBuilder.AddColumn<bool>(
                name: "InNest",
                table: "Tokens",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TokenColor",
                table: "Tokens",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TokenNumber",
                table: "Tokens",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Winner",
                table: "Players",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "GameName",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastSaved",
                table: "Games",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValueSql: "SYSDATETIME()");

            migrationBuilder.AddColumn<int>(
                name: "PlayerTurn",
                table: "Games",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Round",
                table: "Games",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InNest",
                table: "Tokens");

            migrationBuilder.DropColumn(
                name: "TokenColor",
                table: "Tokens");

            migrationBuilder.DropColumn(
                name: "TokenNumber",
                table: "Tokens");

            migrationBuilder.DropColumn(
                name: "Winner",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "GameName",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "LastSaved",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "PlayerTurn",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Round",
                table: "Games");

            migrationBuilder.AddColumn<bool>(
                name: "AtEndLine",
                table: "Tokens",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "EndLinePosition",
                table: "Tokens",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
