using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace OwnedTypeDetached.Migrations
{
    public partial class InitTestDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Test");

            migrationBuilder.CreateTable(
                name: "Test",
                schema: "Test",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Extension_CreateDate = table.Column<DateTime>(nullable: true),
                    Extension_UpdateDate = table.Column<DateTime>(nullable: true),
                    Extension_IsDelete = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Test",
                schema: "Test");
        }
    }
}
