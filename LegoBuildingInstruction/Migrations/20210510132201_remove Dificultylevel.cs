using Microsoft.EntityFrameworkCore.Migrations;

namespace LegoBuildingInstruction.Migrations
{
    public partial class removeDificultylevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingInstructions_DifficultyLevels_DifficultyLevelId",
                table: "BuildingInstructions");

            migrationBuilder.DropTable(
                name: "DifficultyLevels");

            migrationBuilder.DropIndex(
                name: "IX_BuildingInstructions_DifficultyLevelId",
                table: "BuildingInstructions");

            migrationBuilder.DropColumn(
                name: "DifficultyLevelId",
                table: "BuildingInstructions");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "BuildingInstructions",
                type: "nvarchar(130)",
                maxLength: 130,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "BuildingInstructions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(130)",
                oldMaxLength: 130);

            migrationBuilder.AddColumn<int>(
                name: "DifficultyLevelId",
                table: "BuildingInstructions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.InsertData(
                table: "DifficultyLevels",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Easy" });

            migrationBuilder.InsertData(
                table: "DifficultyLevels",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Normal" });

            migrationBuilder.InsertData(
                table: "DifficultyLevels",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Hard" });

            migrationBuilder.UpdateData(
                table: "BuildingInstructions",
                keyColumn: "Id",
                keyValue: 1,
                column: "DifficultyLevelId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "BuildingInstructions",
                keyColumn: "Id",
                keyValue: 2,
                column: "DifficultyLevelId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "BuildingInstructions",
                keyColumn: "Id",
                keyValue: 3,
                column: "DifficultyLevelId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "BuildingInstructions",
                keyColumn: "Id",
                keyValue: 4,
                column: "DifficultyLevelId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_BuildingInstructions_DifficultyLevelId",
                table: "BuildingInstructions",
                column: "DifficultyLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingInstructions_DifficultyLevels_DifficultyLevelId",
                table: "BuildingInstructions",
                column: "DifficultyLevelId",
                principalTable: "DifficultyLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
