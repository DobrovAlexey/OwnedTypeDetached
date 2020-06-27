using Microsoft.EntityFrameworkCore.Migrations;

namespace OwnedTypeDetached.Migrations
{
    public partial class InitTestDb3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Extension_EntityState",
                schema: "Test",
                table: "Test",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Extension_EntityState",
                schema: "Test",
                table: "Test");
        }
    }
}
