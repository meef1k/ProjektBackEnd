using Microsoft.EntityFrameworkCore.Migrations;

namespace Spedition.Migrations
{
    public partial class addDrivers3ToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Spedition_Trailer_TrailerId",
                table: "Spedition");

            migrationBuilder.DropForeignKey(
                name: "FK_Spedition_Truck_TruckId",
                table: "Spedition");

            migrationBuilder.DropForeignKey(
                name: "FK_Trailer_Trailer_Trailerid_trailer",
                table: "Trailer");

            migrationBuilder.DropForeignKey(
                name: "FK_Truck_Truck_Truckid_truck",
                table: "Truck");

            migrationBuilder.DropIndex(
                name: "IX_Spedition_TrailerId",
                table: "Spedition");

            migrationBuilder.DropIndex(
                name: "IX_Spedition_TruckId",
                table: "Spedition");

            migrationBuilder.RenameColumn(
                name: "Truckid_truck",
                table: "Truck",
                newName: "Speditionsid_spedition");

            migrationBuilder.RenameIndex(
                name: "IX_Truck_Truckid_truck",
                table: "Truck",
                newName: "IX_Truck_Speditionsid_spedition");

            migrationBuilder.RenameColumn(
                name: "Trailerid_trailer",
                table: "Trailer",
                newName: "Speditionsid_spedition");

            migrationBuilder.RenameIndex(
                name: "IX_Trailer_Trailerid_trailer",
                table: "Trailer",
                newName: "IX_Trailer_Speditionsid_spedition");

            migrationBuilder.AddForeignKey(
                name: "FK_Trailer_Spedition_Speditionsid_spedition",
                table: "Trailer",
                column: "Speditionsid_spedition",
                principalTable: "Spedition",
                principalColumn: "id_spedition",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Truck_Spedition_Speditionsid_spedition",
                table: "Truck",
                column: "Speditionsid_spedition",
                principalTable: "Spedition",
                principalColumn: "id_spedition",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trailer_Spedition_Speditionsid_spedition",
                table: "Trailer");

            migrationBuilder.DropForeignKey(
                name: "FK_Truck_Spedition_Speditionsid_spedition",
                table: "Truck");

            migrationBuilder.RenameColumn(
                name: "Speditionsid_spedition",
                table: "Truck",
                newName: "Truckid_truck");

            migrationBuilder.RenameIndex(
                name: "IX_Truck_Speditionsid_spedition",
                table: "Truck",
                newName: "IX_Truck_Truckid_truck");

            migrationBuilder.RenameColumn(
                name: "Speditionsid_spedition",
                table: "Trailer",
                newName: "Trailerid_trailer");

            migrationBuilder.RenameIndex(
                name: "IX_Trailer_Speditionsid_spedition",
                table: "Trailer",
                newName: "IX_Trailer_Trailerid_trailer");

            migrationBuilder.CreateIndex(
                name: "IX_Spedition_TrailerId",
                table: "Spedition",
                column: "TrailerId");

            migrationBuilder.CreateIndex(
                name: "IX_Spedition_TruckId",
                table: "Spedition",
                column: "TruckId");

            migrationBuilder.AddForeignKey(
                name: "FK_Spedition_Trailer_TrailerId",
                table: "Spedition",
                column: "TrailerId",
                principalTable: "Trailer",
                principalColumn: "id_trailer",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Spedition_Truck_TruckId",
                table: "Spedition",
                column: "TruckId",
                principalTable: "Truck",
                principalColumn: "id_truck",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trailer_Trailer_Trailerid_trailer",
                table: "Trailer",
                column: "Trailerid_trailer",
                principalTable: "Trailer",
                principalColumn: "id_trailer",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Truck_Truck_Truckid_truck",
                table: "Truck",
                column: "Truckid_truck",
                principalTable: "Truck",
                principalColumn: "id_truck",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
