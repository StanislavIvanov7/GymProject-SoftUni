using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gym.Infrastructure.Data.Models
{
    [Comment("Users and food items mapping table")]
    public class UserFoodItem
    {
        [Required]
        [Comment("User identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        [Required]
        [Comment("Food item identifier")]
        public int FoodItemId { get; set; }

        [ForeignKey(nameof(FoodItemId))]
        public FoodItem FoodItem { get; set; } = null!;
    }
}
