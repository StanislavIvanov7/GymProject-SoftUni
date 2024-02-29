using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static Gym.Infrastructure.Constants.DataConstant.FoodItemCategory;
namespace Gym.Infrastructure.Data.Models
{
    [Comment("Food item category table")]
    public class FoodItemCategory
    {
        [Key]
        [Comment("Food item category identifier")]
        public int Id { get; set; }

        [Required]
        [StringLength(MaxLengthName)]
        [Comment("Food item category name")]
        public string Name { get; set; } = string.Empty;


        public ICollection<FoodItem> FoodsItems { get; set; } = new List<FoodItem>();
    }
}