using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LegoBuildingInstruction.Migrations
{
    public partial class buildinginstructionchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "BuildingInstructions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "BuildingInstructions",
                keyColumn: "Id",
                keyValue: 2,
                column: "VideoUrl",
                value: "https://www.youtube.com/embed/lRVrWwEMntQ");

            migrationBuilder.UpdateData(
                table: "BuildingInstructions",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageThumbnailUrl",
                value: "~/Images/HitTheMole.PNG");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "BuildingInstructions");

            migrationBuilder.UpdateData(
                table: "BuildingInstructions",
                keyColumn: "Id",
                keyValue: 2,
                column: "VideoUrl",
                value: "~/Video/ColorSegregationVideo.mp4");

            migrationBuilder.UpdateData(
                table: "BuildingInstructions",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageThumbnailUrl",
                value: "~/Images/DinosaurImageSmall.png");
        }
    }
}
