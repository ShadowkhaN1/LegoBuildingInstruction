using Microsoft.EntityFrameworkCore.Migrations;

namespace LegoBuildingInstruction.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "DifficultyLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DifficultyLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BuildingInstructions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LongDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PdfInstructionUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageThumbnailUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Pages = table.Column<int>(type: "int", nullable: false),
                    Set = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgramUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    DifficultyLevelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingInstructions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildingInstructions_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildingInstructions_DifficultyLevels_DifficultyLevelId",
                        column: x => x.DifficultyLevelId,
                        principalTable: "DifficultyLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Mindstorms" },
                    { 2, "WeDo" },
                    { 3, "Power Function" }
                });

            migrationBuilder.InsertData(
                table: "DifficultyLevels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Easy" },
                    { 2, "Normal" },
                    { 3, "Hard" }
                });

            migrationBuilder.InsertData(
                table: "BuildingInstructions",
                columns: new[] { "Id", "CategoryId", "DifficultyLevelId", "ImageThumbnailUrl", "ImageUrl", "LongDescription", "Name", "Pages", "PdfInstructionUrl", "ProgramUrl", "Rating", "Set", "ShortDescription", "VideoUrl" },
                values: new object[] { 2, 1, 1, "~/Images/ColorSegregationSmall.png", "~/Images/ColorSegregation.png", "Robot picking up items. The robot detects the object itself using the color sensor.", "Color Segregation", 24, null, null, 0, "45544", "Pick up objects!", "~/Video/ColorSegregationVideo.mp4" });

            migrationBuilder.InsertData(
                table: "BuildingInstructions",
                columns: new[] { "Id", "CategoryId", "DifficultyLevelId", "ImageThumbnailUrl", "ImageUrl", "LongDescription", "Name", "Pages", "PdfInstructionUrl", "ProgramUrl", "Rating", "Set", "ShortDescription", "VideoUrl" },
                values: new object[] { 1, 1, 2, "~/Images/LifterSmall.png", "~/Images/Lifter.png", "Robot picking up items. The robot detects the object itself using the color sensor.", "Lifter", 52, null, null, 0, "45544 + 45560", "Pick up objects!", "~/Video/LifterVideo.mp4" });

            migrationBuilder.CreateIndex(
                name: "IX_BuildingInstructions_CategoryId",
                table: "BuildingInstructions",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingInstructions_DifficultyLevelId",
                table: "BuildingInstructions",
                column: "DifficultyLevelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuildingInstructions");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "DifficultyLevels");
        }
    }
}
