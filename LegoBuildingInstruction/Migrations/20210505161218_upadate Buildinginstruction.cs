using Microsoft.EntityFrameworkCore.Migrations;

namespace LegoBuildingInstruction.Migrations
{
    public partial class upadateBuildinginstruction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "BuildingInstructions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BuildingInstructions_UserId",
                table: "BuildingInstructions",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingInstructions_AspNetUsers_UserId",
                table: "BuildingInstructions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingInstructions_AspNetUsers_UserId",
                table: "BuildingInstructions");

            migrationBuilder.DropIndex(
                name: "IX_BuildingInstructions_UserId",
                table: "BuildingInstructions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BuildingInstructions");
        }
    }
}
