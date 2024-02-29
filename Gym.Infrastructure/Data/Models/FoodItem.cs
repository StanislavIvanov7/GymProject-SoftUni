using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Gym.Infrastructure.Constants.DataConstant.FoodItem;
namespace Gym.Infrastructure.Data.Models
{
    [Comment("Food item table")]
    public class FoodItem
    {
        [Key]
        [Comment("Food item identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxLengthName)]
        [Comment("Food item name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Comment("Food item price")]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(MaxLengthDescription)]
        [Comment("Food item description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Food item category identifier")]
        public int FoodItemCategoryId { get; set; }

        [ForeignKey(nameof(FoodItemCategoryId))]
        [Required]
        public FoodItemCategory FoodItemCategory { get; set; } = null!;

        [Required]
        [Comment("Food item creator identifier")]
        public string CreatorId { get; set; } = string.Empty;

        [ForeignKey(nameof(CreatorId))]
        public IdentityUser Creator { get; set; } = null!;

        [Required]
        [MaxLength(MaxLengthImageUrl)]
        [Comment("Food item image url")]
        public string ImageUrl { get; set; } = string.Empty;

        public IEnumerable<UserFoodItem> UserFoodItems { get; set; } = new List<UserFoodItem>();

    }
}
