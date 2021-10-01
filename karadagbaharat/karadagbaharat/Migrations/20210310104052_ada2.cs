using Microsoft.EntityFrameworkCore.Migrations;

namespace karadagbaharat.Migrations
{
    public partial class ada2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaterialCode",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaterialCode",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
