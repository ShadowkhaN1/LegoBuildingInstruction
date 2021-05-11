using Microsoft.EntityFrameworkCore.Migrations;

namespace LegoBuildingInstruction.Migrations
{
    public partial class FavoritesBuildingInstructionadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavoritesCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingInstructionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoritesCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoritesCategories_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FavoritesCategories_BuildingInstructions_BuildingInstructionId",
                        column: x => x.BuildingInstructionId,
                        principalTable: "BuildingInstructions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoritesCategories_BuildingInstructionId",
                table: "FavoritesCategories",
                column: "BuildingInstructionId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoritesCategories_UserId",
                table: "FavoritesCategories",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoritesCategories");
        }
    }
}
