using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity.Migrations
{
    public partial class Seed_Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: -2,
                column: "ImageUrl",
                value: "images/PilsnerUrquell.jpg");

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "DisplayName", "ImageUrl" },
                values: new object[] { "Club-Mate", "images/club-mate.jpg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: -2,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "DisplayName", "ImageUrl" },
                values: new object[] { "Coca-Cola", "" });
        }
    }
}
