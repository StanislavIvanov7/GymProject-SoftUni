using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Infrastructure.Data.Models
{
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
