using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static Gym.Infrastructure.Constants.DataConstant.ProductCategory;
namespace Gym.Infrastructure.Data.Models
{
    [Comment("Product category table")]
    public class ProductCategory
    {
        [Key]
        [Comment("Product category identifier")]
        public int Id { get; set; }

        [Required]
        [StringLength(MaxLengthName)]
        [Comment("Product category name")]
        public string Name { get; set; } = string.Empty;


        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}