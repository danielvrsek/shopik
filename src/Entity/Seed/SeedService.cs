using Microsoft.EntityFrameworkCore;

namespace Entity.Seed
{
    public static class SeedService
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedShopItemCategory();
            modelBuilder.SeedShopItem();
        }
    }
}
