namespace Shopik.Shared.Shop.Dto
{
    public class ShopItemViewModel
    {
        public int Id { get; set; }

        public string? DisplayName { get; set; }

        public string? ImageUrl { get; set; }

        public decimal Price { get; set; }

        public string? CategoryDisplayName { get; set; }
    }
}
