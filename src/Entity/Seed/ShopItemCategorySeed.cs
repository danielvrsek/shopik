using Entity.Shop;
using Entity.Tools;
using Microsoft.EntityFrameworkCore;

namespace Entity.Seed
{
    internal static class ShopItemCategorySeed
    {
        static IdentityGenerator identityGenerator = new IdentityGenerator();

        internal static ShopItemCategory Lemonades = new ShopItemCategory
        {
            Id = identityGenerator.GetNextId(),
            DisplayName = "Limonády"
        };

        internal static ShopItemCategory Beers = new ShopItemCategory
        {
            Id = identityGenerator.GetNextId(),
            DisplayName = "Pivo"
        };

        internal static ShopItemCategory Sweets = new ShopItemCategory
        {
            Id = identityGenerator.GetNextId(),
            DisplayName = "Sladké"
        };

        internal static ShopItemCategory Salty = new ShopItemCategory
        {
            Id = identityGenerator.GetNextId(),
            DisplayName = "Slané"
        };

        internal static ShopItemCategory Healthy = new ShopItemCategory
        {
            Id = identityGenerator.GetNextId(),
            DisplayName = "Zdravé"
        };

        internal static ShopItemCategory[] Entities = new[]
        {
            Lemonades,
            Beers,
            Sweets,
            Salty,
            Healthy
        };

        public static void SeedShopItemCategory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShopItemCategory>().HasData(Entities);
        }
    }
}
 