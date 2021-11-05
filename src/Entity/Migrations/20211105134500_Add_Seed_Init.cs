using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity.Migrations
{
    public partial class Add_Seed_Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ShopItemCategories",
                columns: new[] { "Id", "DisplayName" },
                values: new object[] { -1, "Limonády" });

            migrationBuilder.InsertData(
                table: "ShopItemCategories",
                columns: new[] { "Id", "DisplayName" },
                values: new object[] { -2, "Pivo" });

            migrationBuilder.InsertData(
                table: "ShopItemCategories",
                columns: new[] { "Id", "DisplayName" },
                values: new object[] { -3, "Sladké" });

            migrationBuilder.InsertData(
                table: "ShopItemCategories",
                columns: new[] { "Id", "DisplayName" },
                values: new object[] { -4, "Slané" });

            migrationBuilder.InsertData(
                table: "ShopItemCategories",
                columns: new[] { "Id", "DisplayName" },
                values: new object[] { -5, "Zdravé" });

            migrationBuilder.InsertData(
                table: "ShopItems",
                columns: new[] { "Id", "CategoryId", "DisplayName", "ImageUrl", "Price" },
                values: new object[] { -1, -1, "Coca-Cola", "", 17m });

            migrationBuilder.InsertData(
                table: "ShopItems",
                columns: new[] { "Id", "CategoryId", "DisplayName", "ImageUrl", "Price" },
                values: new object[] { -2, -2, "Pilsner Urquell", "", 32m });

            migrationBuilder.InsertData(
                table: "ShopItems",
                columns: new[] { "Id", "CategoryId", "DisplayName", "ImageUrl", "Price" },
                values: new object[] { -3, -3, "3Bit", "", 13m });

            migrationBuilder.InsertData(
                table: "ShopItems",
                columns: new[] { "Id", "CategoryId", "DisplayName", "ImageUrl", "Price" },
                values: new object[] { -4, -4, "Bohemia tyčinky", "", 20m });

            migrationBuilder.InsertData(
                table: "ShopItems",
                columns: new[] { "Id", "CategoryId", "DisplayName", "ImageUrl", "Price" },
                values: new object[] { -5, -5, "Mana drink", "", 85m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "ShopItemCategories",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "ShopItemCategories",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "ShopItemCategories",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "ShopItemCategories",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "ShopItemCategories",
                keyColumn: "Id",
                keyValue: -1);
        }
    }
}
