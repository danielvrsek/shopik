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
    }
}
