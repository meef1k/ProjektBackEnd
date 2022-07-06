using Microsoft.EntityFrameworkCore.Migrations;

namespace Spedition.Migrations
{
    public partial class addKeys3ToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "driver_phone",
                table: "Driver");

            migrationBuilder.AddColumn<string>(
                name: "driver_number",
                table: "Driver",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "driver_number",
                table: "Driver");

            migrationBuilder.AddColumn<int>(
                name: "driver_phone",
                table: "Driver",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
