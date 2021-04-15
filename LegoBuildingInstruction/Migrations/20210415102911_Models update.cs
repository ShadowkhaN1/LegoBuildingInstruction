using Microsoft.EntityFrameworkCore.Migrations;

namespace LegoBuildingInstruction.Migrations
{
    public partial class Modelsupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Rating",
                table: "BuildingInstructions",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfPeopleRating",
                table: "BuildingInstructions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "BuildingInstructions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NumberOfPeopleRating", "Rating" },
                values: new object[] { 2, 4.5f });

            migrationBuilder.UpdateData(
                table: "BuildingInstructions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NumberOfPeopleRating", "Rating" },
                values: new object[] { 3, 5f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfPeopleRating",
                table: "BuildingInstructions");

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "BuildingInstructions",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.UpdateData(
                table: "BuildingInstructions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Rating",
                value: 0);

            migrationBuilder.UpdateData(
                table: "BuildingInstructions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Rating",
                value: 0);
        }
    }
}
