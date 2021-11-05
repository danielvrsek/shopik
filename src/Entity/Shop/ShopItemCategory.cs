using System.ComponentModel.DataAnnotations;

namespace Entity.Shop
{
    public class ShopItemCategory
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string? DisplayName { get; set; }
    }
}
