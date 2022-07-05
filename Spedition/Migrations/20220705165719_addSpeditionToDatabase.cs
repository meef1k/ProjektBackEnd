using Microsoft.EntityFrameworkCore.Migrations;

namespace Spedition.Migrations
{
    public partial class addSpeditionToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Spedition",
                columns: table => new
                {
                    id_spedition = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    start_place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    end_place = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spedition", x => x.id_spedition);
                    table.ForeignKey(
                        name: "FK_Spedition_Package_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Package",
                        principalColumn: "id_package",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Spedition_PackageId",
                table: "Spedition",
                column: "PackageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spedition");
        }
    }
}
