using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gym.Infrastructure.Data.Models
{
    [Comment("Fitness card-user mapping table")]
    public class UserFitnessCard
    {
        [Required]
        [Comment("User identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        [Required]
        [Comment("Fitness card identifier")]
        public int FitnessCardId { get; set; }

        [ForeignKey(nameof(FitnessCardId))]
        public FitnessCard FitnessCard { get; set; } = null!;
    }
}
