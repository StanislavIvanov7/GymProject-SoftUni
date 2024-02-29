using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static Gym.Infrastructure.Constants.DataConstant.FitnessCardCategory;
namespace Gym.Infrastructure.Data.Models
{
    [Comment("Fitnes card category table")]
    public class FitnessCardCategory
    {
        [Key]
        [Comment("Fitness card category identifier")]
        public int Id { get; set; }

        [Required]
        [StringLength(MaxLengthName)]
        [Comment("Fitness card category name")]
        public string Name { get; set; } = string.Empty;

        public ICollection<FitnessCard> FitnesCards { get; set; } = new List<FitnessCard>();
    }
}