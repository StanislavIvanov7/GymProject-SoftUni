using Gym.Core.Models.Diet;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Gym.Infrastructure.Constants.DataConstant.WorkoutPlan;
using static Gym.Core.Constants.MessageConstants;
namespace Gym.Core.Models.WorkoutPlan
{
    public class WorkoutPlanFormViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MaxLengthName, MinimumLength = MinLengthName, ErrorMessage = LengthMessage)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MaxLengthDescription, MinimumLength = MinLengthDescription, ErrorMessage = LengthMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        public int WorkoutPlanCategoryId { get; set; }


        public IEnumerable<WorkoutPlanCategoryViewModel> WorkoutPlanCategories { get; set; }
            = new List<WorkoutPlanCategoryViewModel>();


        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MaxLengthImageUrl, MinimumLength = MinLengthImageUrl, ErrorMessage = LengthMessage)]
        public string ImageUrl { get; set; } = string.Empty;
    }
}
