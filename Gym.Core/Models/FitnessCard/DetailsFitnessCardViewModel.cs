using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Core.Models.FitnessCard
{
    public class DetailsFitnessCardViewModel
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; } = string.Empty;

        public string FitnessCardCategory { get; set; } = string.Empty;

        public string Creator { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;
    }
}
