using Microsoft.EntityFrameworkCore.Migrations;

namespace LegoBuildingInstruction.Migrations
{
    public partial class removeshortDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "BuildingInstructions");

            migrationBuilder.AlterColumn<string>(
                name: "LongDescription",
                table: "BuildingInstructions",
                type: "nvarchar(130)",
                maxLength: 130,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LongDescription",
                table: "BuildingInstructions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(130)",
                oldMaxLength: 130);

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "BuildingInstructions",
                type: "nvarchar(130)",
                maxLength: 130,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "BuildingInstructions",
                keyColumn: "Id",
                keyValue: 1,
                column: "ShortDescription",
                value: "Pick up objects!");

            migrationBuilder.UpdateData(
                table: "BuildingInstructions",
                keyColumn: "Id",
                keyValue: 2,
                column: "ShortDescription",
                value: "Pick up objects!");

            migrationBuilder.UpdateData(
                table: "BuildingInstructions",
                keyColumn: "Id",
                keyValue: 3,
                column: "ShortDescription",
                value: "Create a dinosaur from your lego bricks!");

            migrationBuilder.UpdateData(
                table: "BuildingInstructions",
                keyColumn: "Id",
                keyValue: 4,
                column: "ShortDescription",
                value: "Hit the right mole at the right moment");
        }
    }
}
