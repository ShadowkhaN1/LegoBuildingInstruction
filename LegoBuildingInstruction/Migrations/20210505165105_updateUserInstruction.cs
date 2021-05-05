using Microsoft.EntityFrameworkCore.Migrations;

namespace LegoBuildingInstruction.Migrations
{
    public partial class updateUserInstruction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BuildingInstructions_UserId",
                table: "BuildingInstructions");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingInstructions_UserId",
                table: "BuildingInstructions",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BuildingInstructions_UserId",
                table: "BuildingInstructions");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingInstructions_UserId",
                table: "BuildingInstructions",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }
    }
}
