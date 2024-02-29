using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Gym.Infrastructure.Constants.DataConstant.WorkoutPlan;

namespace Gym.Infrastructure.Data.Models
{
    [Comment("Workout plan table")]
    public class WorkoutPlan
    {
        [Key]
        [Comment("Workout plan identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxLengthName)]
        [Comment("Workout plan name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(MaxLengthImageUrl)]
        [Comment("Workout plan image url")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [MaxLength(MaxLengthDescription)]
        [Comment("Workout plan description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Workout plan category identifier")]
        public int WorkoutPlanCategoryId { get; set; }

        [ForeignKey(nameof(WorkoutPlanCategoryId))]
        public WorkoutPlanCategory FitnessProgramCategory { get; set; } = null!;

        [Required]
        [Comment("Workout plan creator identifier")]
        public string CreatorId { get; set; } = string.Empty;

        [ForeignKey(nameof(CreatorId))]
        public IdentityUser Creator { get; set; } = null!;
    }
}
