using Microsoft.EntityFrameworkCore.Migrations;

namespace Spedition.Migrations
{
    public partial class addDrivers2ToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Driver_Driver_Driverid_driver",
                table: "Driver");

            migrationBuilder.DropForeignKey(
                name: "FK_Spedition_Driver_DriverId",
                table: "Spedition");

            migrationBuilder.DropIndex(
                name: "IX_Spedition_DriverId",
                table: "Spedition");

            migrationBuilder.RenameColumn(
                name: "Driverid_driver",
                table: "Driver",
                newName: "Speditionsid_spedition");

            migrationBuilder.RenameIndex(
                name: "IX_Driver_Driverid_driver",
                table: "Driver",
                newName: "IX_Driver_Speditionsid_spedition");

            migrationBuilder.AddForeignKey(
                name: "FK_Driver_Spedition_Speditionsid_spedition",
                table: "Driver",
                column: "Speditionsid_spedition",
                principalTable: "Spedition",
                principalColumn: "id_spedition",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Driver_Spedition_Speditionsid_spedition",
                table: "Driver");

            migrationBuilder.RenameColumn(
                name: "Speditionsid_spedition",
                table: "Driver",
                newName: "Driverid_driver");

            migrationBuilder.RenameIndex(
                name: "IX_Driver_Speditionsid_spedition",
                table: "Driver",
                newName: "IX_Driver_Driverid_driver");

            migrationBuilder.CreateIndex(
                name: "IX_Spedition_DriverId",
                table: "Spedition",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Driver_Driver_Driverid_driver",
                table: "Driver",
                column: "Driverid_driver",
                principalTable: "Driver",
                principalColumn: "id_driver",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Spedition_Driver_DriverId",
                table: "Spedition",
                column: "DriverId",
                principalTable: "Driver",
                principalColumn: "id_driver",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
