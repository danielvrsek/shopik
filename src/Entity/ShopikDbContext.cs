using Entity.Seed;
using Entity.Shop;
using Microsoft.EntityFrameworkCore;

namespace Entity
{
    public class ShopikDbContext : DbContext
    {
        public DbSet<ShopItem> ShopItems { get; set; }
        public DbSet<ShopItemCategory> ShopItemCategories { get; set; }

        private string dbPath;

        public ShopikDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            dbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}shopik.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source=\"{dbPath}\"");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShopItem>().HasOne(x => x.Category).WithMany().HasForeignKey(x => x.CategoryId);
            SeedService.Seed(modelBuilder);
        }
    }
}
