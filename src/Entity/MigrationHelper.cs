using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Entity
{
    public static class MigrationHelper
    {
        public static void Migrate(this IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                if (scope == null) throw new ArgumentNullException(nameof(scope));

                using var dbContext = scope.ServiceProvider.GetRequiredService<ShopikDbContext>();
                dbContext.Database.Migrate();
            }

        }
    }
}
