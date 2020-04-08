using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheLudoGameEngine.Migrations
{
    public partial class addedSmallDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastSaved",
                table: "Games",
                type: "SMALLDATETIME",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastSaved",
                table: "Games",
                type: "DATETIME",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME");
        }
    }
}
