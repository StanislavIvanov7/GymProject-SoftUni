using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Gym.Infrastructure.Constants.DataConstant.WorkoutPlanCategory;
using static Gym.Core.Constants.MessageConstants;

namespace Gym.Core.Models.WorkoutPlan
{
    public class WorkoutPlanCategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MaxLengthName, MinimumLength = MinLengthName, ErrorMessage = LengthMessage)]
        public string Name { get; set; } = string.Empty;
    }
}
