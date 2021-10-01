using Microsoft.EntityFrameworkCore.Migrations;

namespace pınarkuruyemis.Migrations
{
    public partial class first2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShopPHPID",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "ShopPHPState",
                table: "Files");

            migrationBuilder.RenameColumn(
                name: "ShopPHPName",
                table: "Files",
                newName: "FileName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "Files",
                newName: "ShopPHPName");

            migrationBuilder.AddColumn<string>(
                name: "ShopPHPID",
                table: "Files",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ShopPHPState",
                table: "Files",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
