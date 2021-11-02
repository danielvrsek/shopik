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
                DisplayName = createModel.DisplayName,
                ImageUrl = createModel.ImageUrl
            };

            _dbContext.ShopItems.Add(shopItem);

            await _dbContext.SaveChangesAsync();

            return MapToViewModel(shopItem);
        }

        public Task<List<ShopItemViewModel>> GetAllAsync()
        {
            return GetShopItemViewModelsQueryable().ToListAsync();
        }

        public Task<ShopItemViewModel> GetByIdAsync(int id)
        {
            return GetShopItemViewModelsQueryable().SingleAsync(x => x.Id == id);
        }

        public async Task<ShopItemViewModel> UpdateAsync(int id, ShopItemEditModel editModel)
        {
            var entity = await _dbContext.ShopItems.FindAsync(id);
            entity.DisplayName = editModel.DisplayName;
            entity.ImageUrl = editModel.ImageUrl;

            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();

            return MapToViewModel(entity);
        }

        ShopItemViewModel MapToViewModel(ShopItem shopItem)
        {
            return new ShopItemViewModel
            {
                Id = shopItem.Id,
                DisplayName = shopItem.DisplayName,
                ImageUrl = shopItem.ImageUrl
            };
        }

        IQueryable<ShopItemViewModel> GetShopItemViewModelsQueryable()
        {
            return _dbContext.ShopItems.Select(x => new ShopItemViewModel
            {
                Id = x.Id,
                DisplayName = x.DisplayName,
                ImageUrl = x.ImageUrl
            });
        }
    }
}
