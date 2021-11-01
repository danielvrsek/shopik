using Entity;
using Entity.Shop;
using Microsoft.EntityFrameworkCore;
using Shopik.Shared.Shop;
using Shopik.Shared.Shop.Dto;

namespace Facades.Shop
{
    internal class ShopItemFacade : IShopItemFacade
    {
        private readonly ShopikDbContext _dbContext;

        public ShopItemFacade(ShopikDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ShopItemViewModel> CreateAsync(ShopItemCreateModel createModel)
        {
            ShopItem shopItem = new ShopItem
            {
                Name = createModel.Name
            };

            _dbContext.ShopItems.Add(shopItem);

            await _dbContext.SaveChangesAsync();

            return new ShopItemViewModel
            {
                Id = shopItem.Id,
                Name = shopItem.Name
            };
        }

        public Task<List<ShopItemViewModel>> GetAllAsync()
        {
            return _dbContext.ShopItems.Select(x => new ShopItemViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
        }

        public Task<ShopItemViewModel> GetByIdAsync(int id)
        {
            return _dbContext.ShopItems.Select(x => new ShopItemViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).SingleAsync(x => x.Id == id);
        }
    }
}
