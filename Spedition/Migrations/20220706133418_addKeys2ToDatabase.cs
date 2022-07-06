using Microsoft.EntityFrameworkCore.Migrations;

namespace Spedition.Migrations
{
    public partial class addKeys2ToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "driver_surname",
                table: "Driver");

            migrationBuilder.AddColumn<int>(
                name: "driver_phone",
                table: "Driver",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "driver_phone",
                table: "Driver");

            migrationBuilder.AddColumn<string>(
                name: "driver_surname",
                table: "Driver",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
