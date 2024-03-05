using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Gym.Core.Constants.MessageConstants;
using static Gym.Infrastructure.Constants.DataConstant.FitnessCardCategory;

namespace Gym.Core.Models.FitnessCard
{
    public class FitnessCardCategoryViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MaxLengthName, MinimumLength = MinLengthName, ErrorMessage = LengthMessage)]
        public string Name { get; set; } = string.Empty;
    }
}
