using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity.Migrations
{
    public partial class ShopItem_Add_Column_ImageUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ShopItems",
                newName: "ImageUrl");

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "ShopItems",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "ShopItems");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "ShopItems",
                newName: "Name");
        }
    }
}
