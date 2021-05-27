using Microsoft.EntityFrameworkCore.Migrations;

namespace HikingWebApplication.Data.Migrations
{
    public partial class AddInterestColunmToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Interests",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Interests",
                table: "AspNetUsers");
        }
    }
}
