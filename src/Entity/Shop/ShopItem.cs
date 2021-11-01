using System.ComponentModel.DataAnnotations;

namespace Entity.Shop
{
    public class ShopItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string? Name { get; set; }
    }
}
