using Entity.Shop;
using Entity.Tools;
using Microsoft.EntityFrameworkCore;

namespace Entity.Seed
{
    internal static class ShopItemSeed
    {
        static IdentityGenerator identityGenerator = new IdentityGenerator();

        internal static ShopItem[] Entities = new[]
        {
            new ShopItem
            {
                Id = identityGenerator.GetNextId(),
                DisplayName = "Club-Mate",
                Price = 17,
                ImageUrl = "images/club-mate.jpg",
                CategoryId = ShopItemCategorySeed.Lemonades.Id
            },
            new ShopItem
            {
                Id = identityGenerator.GetNextId(),
                DisplayName = "Pilsner Urquell",
                Price = 32,
                ImageUrl = "images/PilsnerUrquell.jpg",
                CategoryId = ShopItemCategorySeed.Beers.Id
            },
            new ShopItem
            {
                Id = identityGenerator.GetNextId(),
                DisplayName = "3Bit",
                Price = 13,
                ImageUrl = "",
                CategoryId = ShopItemCategorySeed.Sweets.Id
            },
            new ShopItem
            {
                Id = identityGenerator.GetNextId(),
                DisplayName = "Bohemia tyčinky",
                Price = 20,
                ImageUrl = "",
                CategoryId = ShopItemCategorySeed.Salty.Id
            },
            new ShopItem
            {
                Id = identityGenerator.GetNextId(),
                DisplayName = "Mana drink",
                Price = 85,
                ImageUrl = "",
                CategoryId = ShopItemCategorySeed.Healthy.Id
            }
        };

        public static void SeedShopItem(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShopItem>().HasData(Entities);
        }
    }
}
