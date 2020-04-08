using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheLudoGameEngine.Migrations
{
    public partial class _dateTimeUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastSaved",
                table: "Games",
                type: "DATETIME",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATE");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastSaved",
                table: "Games",
                type: "DATE",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME");
        }
    }
}
