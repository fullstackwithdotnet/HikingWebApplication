using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HikingWebApplication.Data.Migrations
{
    public partial class AddRouterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Place = table.Column<string>(nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(18, 3)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(18, 3)", nullable: false),
                    Elevation = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    Distance = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    DificultyLevel = table.Column<int>(nullable: false),
                    EstimateTime = table.Column<int>(nullable: false),
                    PhotoPath = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SelectedRate = table.Column<int>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Routes_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Routes_CreatedById",
                table: "Routes",
                column: "CreatedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Routes");
        }
    }
}
