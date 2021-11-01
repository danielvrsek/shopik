using Shopik.Shared.Shop.Dto;

namespace Shopik.Shared.Shop
{
    public interface IShopItemFacade
    {
        Task<ShopItemViewModel> CreateAsync(ShopItemCreateModel createModel);

        Task<List<ShopItemViewModel>> GetAllAsync();

        Task<ShopItemViewModel> GetByIdAsync(int id);
    }
}
