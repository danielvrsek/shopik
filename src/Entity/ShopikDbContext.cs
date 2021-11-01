using Entity.Shop;
using Microsoft.EntityFrameworkCore;

namespace Entity
{
    public class ShopikDbContext : DbContext
    {
        public DbSet<ShopItem> ShopItems { get; set; }

        public ShopikDbContext(DbContextOptions<ShopikDbContext> options) : base(options)
        {
        }
    }
}
