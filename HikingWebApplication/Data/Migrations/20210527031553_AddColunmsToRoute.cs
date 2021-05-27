using Microsoft.EntityFrameworkCore.Migrations;

namespace HikingWebApplication.Data.Migrations
{
    public partial class AddColunmsToRoute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Budget",
                table: "Routes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "NeedExpert",
                table: "Routes",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Budget",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "NeedExpert",
                table: "Routes");
        }
    }
}
