using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static Gym.Infrastructure.Constants.DataConstant.WorkoutPlanCategory;

namespace Gym.Infrastructure.Data.Models
{
    [Comment("Workout plan category table")]
    public class WorkoutPlanCategory
    {
        [Key]
        [Comment("Workout plan category identifier")]
        public int Id { get; set; }

        [Required]
        [StringLength(MaxLengthName)]
        [Comment("Workout plan category name")]
        public string Name { get; set; } = string.Empty;


        public ICollection<WorkoutPlan> FitnesPrograms { get; set; } = new List<WorkoutPlan>();
    }
}