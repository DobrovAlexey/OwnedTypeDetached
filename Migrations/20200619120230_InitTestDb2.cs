using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OwnedTypeDetached.Migrations
{
    public partial class InitTestDb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Text",
                schema: "Test",
                table: "Test",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "Test",
                table: "Test",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Text",
                schema: "Test",
                table: "Test",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "Test",
                table: "Test",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
