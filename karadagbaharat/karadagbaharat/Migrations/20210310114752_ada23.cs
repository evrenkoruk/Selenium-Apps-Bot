using Microsoft.EntityFrameworkCore.Migrations;

namespace karadagbaharat.Migrations
{
    public partial class ada23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BarcodeID",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Barcode",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Barcodee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    Source = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barcode", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_BarcodeID",
                table: "Products",
                column: "BarcodeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Barcode_BarcodeID",
                table: "Products",
                column: "BarcodeID",
                principalTable: "Barcode",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Barcode_BarcodeID",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Barcode");

            migrationBuilder.DropIndex(
                name: "IX_Products_BarcodeID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BarcodeID",
                table: "Products");
        }
    }
}
