using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Gym.Infrastructure.Constants.DataConstant.Product;
namespace Gym.Infrastructure.Data.Models
{
    [Comment("Product table")]
    public class Product
    {
        [Key]
        [Comment("Product identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxLengthName)]
        [Comment("Product name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Comment("Product price")]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(MaxLengthDescription)]
        [Comment("Product description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Product category identifier")]
        public int ProductCategoryId { get; set; }

        [ForeignKey(nameof(ProductCategoryId))]
        [Required]
        public ProductCategory ProductCategory { get; set; } = null!;

        [Required]
        [Comment("Product creator identifier")]
        public string CreatorId { get; set; } = string.Empty;

        [ForeignKey(nameof(CreatorId))]
        public IdentityUser Creator { get; set; } = null!;

        [Required]
        [MaxLength(MaxLengthImageUrl)]
        [Comment("Product image url")]
        public string ImageUrl { get; set; } = string.Empty;

        public IEnumerable<UserProduct> UserProducts { get; set; } = new List<UserProduct>();

    }
}
