using System.ComponentModel.DataAnnotations;

namespace Entity.Shop
{
    public class ShopItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string? DisplayName { get; set; }

        [Required]
        [MaxLength(200)]
        public string? ImageUrl { get; set; }

        public decimal Price { get; set; }

        public ShopItemCategory? Category { get; set; }
        public int CategoryId { get; set; }
    }
}
