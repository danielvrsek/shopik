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
            if (createModel.CategoryId == null)
            {
                throw new ArgumentException("Category must be specified.");
            }

            ShopItem shopItem = new ShopItem
            {
                DisplayName = createModel.DisplayName,
                ImageUrl = createModel.ImageUrl,
                Price = createModel.Price,
                CategoryId = (int)createModel.CategoryId
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
            var entity = await _dbContext.ShopItems.Include(x => x.Category).SingleAsync(x => x.Id == id);
            entity.DisplayName = editModel.DisplayName;
            entity.ImageUrl = editModel.ImageUrl;
            entity.CategoryId = editModel.CategoryId ?? entity.CategoryId;   
            entity.Price = editModel.Price; 

            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();

            return MapToViewModel(entity);
        }

        ShopItemViewModel MapToViewModel(ShopItem shopItem)
        {
            if (shopItem.Category == null)
            {
                throw new ArgumentException("Entity does not contain required referenced entities.");
            }

            return new ShopItemViewModel
            {
                Id = shopItem.Id,
                DisplayName = shopItem.DisplayName,
                ImageUrl = shopItem.ImageUrl,
                Price = shopItem.Price,
                CategoryDisplayName = shopItem.Category.DisplayName
            };
        }

        IQueryable<ShopItemViewModel> GetShopItemViewModelsQueryable()
        {
            return _dbContext.ShopItems.Select(x => new ShopItemViewModel
            {
                Id = x.Id,
                DisplayName = x.DisplayName,
                ImageUrl = x.ImageUrl,
                Price = x.Price,
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                CategoryDisplayName = x.Category.DisplayName
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            });
        }
    }
}
