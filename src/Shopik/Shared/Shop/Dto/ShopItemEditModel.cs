namespace Shopik.Shared.Shop.Dto
{
    public class ShopItemEditModel
    {
        public string? DisplayName { get; set; }

        public string? ImageUrl { get; set; }

        public decimal Price { get; set; }

        public int? CategoryId { get; set; }
    }
}
