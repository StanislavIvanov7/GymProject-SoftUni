using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Gym.Infrastructure.Constants.DataConstant.Diet;

namespace Gym.Infrastructure.Data.Models
{
    [Comment("Diet table")]
    public class Diet
    {
        [Key]
        [Comment("Diet identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxLengthTitle)]
        [Comment("Diet title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(MaxLengthDescription)]
        [Comment("Diet description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [MaxLength(MaxLengthImageUrl)]
        [Comment("Diet image url")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Comment("Diet category identifier")]
        public int DietCategoryId { get; set; }

        [ForeignKey(nameof(DietCategoryId))] 
        public DietCategory DietCategory { get; set; } = null!;

        [Required]
        [Comment("Diet creator identifier")]
        public string CreatorId { get; set; } = string.Empty;

        [ForeignKey(nameof(CreatorId))]
        public IdentityUser Creator { get; set; } = null!;
    }
}
