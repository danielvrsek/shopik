using Shopik.Shared.Shop.Dto;

namespace Shopik.Shared.Shop
{
    public interface IShopItemFacade
    {
        Task<ShopItemViewModel> CreateAsync(ShopItemCreateModel createModel);

        Task<List<ShopItemViewModel>> GetAllAsync();

        Task<ShopItemViewModel> GetByIdAsync(int id);

        Task<ShopItemViewModel> UpdateAsync(int id, ShopItemEditModel editModel);
    }
}
