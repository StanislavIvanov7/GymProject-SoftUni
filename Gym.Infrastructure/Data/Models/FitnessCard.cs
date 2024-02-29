using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Gym.Infrastructure.Constants.DataConstant.FitnessCard;

namespace Gym.Infrastructure.Data.Models
{
    [Comment("Fitness card table")]
    public class FitnessCard
    {
        [Key]
        [Comment("Fitness card identifier")]
        public int Id { get; set; }


        [Required]
        [Comment("Fitness card category identifier")]
        public int FitnessCardCategoryId { get; set; }


        [ForeignKey(nameof(FitnessCardCategoryId))]
        public FitnessCardCategory FitnessCardCategory { get; set; } = null!;

        [Required]
        [Comment("Fitness card price")]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(MaxLengthDescription)]
        [Comment("Fitness card description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [MaxLength(MaxLengthImageUrl)]
        [Comment("Fitness card image url")]
        public string ImageUrl { get; set; } = string.Empty;


        [Required]
        [Comment("Fitness card creator identifier")]
        public string CreatorId { get; set; } = string.Empty;

        [ForeignKey(nameof(CreatorId))]
        public IdentityUser Creator { get; set; } = null!;

        public IEnumerable<UserFitnessCard> UserFitnessCards { get; set; } = new List<UserFitnessCard>();
    }
}
