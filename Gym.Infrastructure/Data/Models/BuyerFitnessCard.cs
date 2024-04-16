using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gym.Infrastructure.Data.Models
{
    [Comment("Buyer Fitness Card Mapping Table")]
    public class BuyerFitnessCard
    {

        [Required]
        [Comment("Buyer identifier")]
        public string BuyerId { get; set; } = string.Empty;

        [ForeignKey(nameof(BuyerId))]
        public ApplicationUser Buyer { get; set; } = null!;

        [Required]
        [Comment("Fitness card identifier")]
        public int FitnessCardId { get; set; }

        [ForeignKey(nameof(FitnessCardId))]
        public FitnessCard FitnessCard { get; set; } = null!;

        [Required]
        [Comment("Fitness card quantity")]
        public int Quantity { get; set; }
    }
}
