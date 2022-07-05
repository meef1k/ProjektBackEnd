using Microsoft.EntityFrameworkCore.Migrations;

namespace Spedition.Migrations
{
    public partial class addPackageToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trailer",
                columns: table => new
                {
                    id_trailer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    trailer_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    trailer_manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    trailer_model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    trailer_plate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trailer", x => x.id_trailer);
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
                    truck_plate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Truck", x => x.id_truck);
                });

            migrationBuilder.CreateTable(
                name: "Package",
                columns: table => new
                {
                    id_package = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_truck = table.Column<int>(type: "int", nullable: false),
                    id_trailer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.id_package);
                    table.ForeignKey(
                        name: "FK_Package_Trailer_id_trailer",
                        column: x => x.id_trailer,
                        principalTable: "Trailer",
                        principalColumn: "id_trailer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Package_Truck_id_truck",
                        column: x => x.id_truck,
                        principalTable: "Truck",
                        principalColumn: "id_truck",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Package_id_trailer",
                table: "Package",
                column: "id_trailer",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Package_id_truck",
                table: "Package",
                column: "id_truck",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Package");

            migrationBuilder.DropTable(
                name: "Trailer");

            migrationBuilder.DropTable(
                name: "Truck");
        }
    }
}
