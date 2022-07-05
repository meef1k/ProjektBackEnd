using Microsoft.EntityFrameworkCore.Migrations;

namespace Spedition.Migrations
{
    public partial class addDriversToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Driver",
                columns: table => new
                {
                    id_driver = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Driverid_driver = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver", x => x.id_driver);
                    table.ForeignKey(
                        name: "FK_Driver_Driver_Driverid_driver",
                        column: x => x.Driverid_driver,
                        principalTable: "Driver",
                        principalColumn: "id_driver",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trailer",
                columns: table => new
                {
                    id_trailer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    trailer_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    trailer_manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    trailer_model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    trailer_plate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trailerid_trailer = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trailer", x => x.id_trailer);
                    table.ForeignKey(
                        name: "FK_Trailer_Trailer_Trailerid_trailer",
                        column: x => x.Trailerid_trailer,
                        principalTable: "Trailer",
                        principalColumn: "id_trailer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Truck",
                columns: table => new
                {
                    id_truck = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    truck_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    truck_manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    truck_model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    truck_plate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Truckid_truck = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Truck", x => x.id_truck);
                    table.ForeignKey(
                        name: "FK_Truck_Truck_Truckid_truck",
                        column: x => x.Truckid_truck,
                        principalTable: "Truck",
                        principalColumn: "id_truck",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Spedition",
                columns: table => new
                {
                    id_spedition = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    start_place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    end_place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TruckId = table.Column<int>(type: "int", nullable: false),
                    TrailerId = table.Column<int>(type: "int", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spedition", x => x.id_spedition);
                    table.ForeignKey(
                        name: "FK_Spedition_Driver_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Driver",
                        principalColumn: "id_driver",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Spedition_Trailer_TrailerId",
                        column: x => x.TrailerId,
                        principalTable: "Trailer",
                        principalColumn: "id_trailer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Spedition_Truck_TruckId",
                        column: x => x.TruckId,
                        principalTable: "Truck",
                        principalColumn: "id_truck",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Driver_Driverid_driver",
                table: "Driver",
                column: "Driverid_driver");

            migrationBuilder.CreateIndex(
                name: "IX_Spedition_DriverId",
                table: "Spedition",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Spedition_TrailerId",
                table: "Spedition",
                column: "TrailerId");

            migrationBuilder.CreateIndex(
                name: "IX_Spedition_TruckId",
                table: "Spedition",
                column: "TruckId");

            migrationBuilder.CreateIndex(
                name: "IX_Trailer_Trailerid_trailer",
                table: "Trailer",
                column: "Trailerid_trailer");

            migrationBuilder.CreateIndex(
                name: "IX_Truck_Truckid_truck",
                table: "Truck",
                column: "Truckid_truck");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spedition");

            migrationBuilder.DropTable(
                name: "Driver");

            migrationBuilder.DropTable(
                name: "Trailer");

            migrationBuilder.DropTable(
                name: "Truck");
        }
    }
}
