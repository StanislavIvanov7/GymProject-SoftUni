using System.ComponentModel.DataAnnotations;
using static Gym.Core.Constants.MessageConstants;
using static Gym.Infrastructure.Constants.DataConstant.DietCategory;

namespace Gym.Core.Models.Diet
{
    public class DietCategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MaxLengthName, MinimumLength = MinLengthName, ErrorMessage = LengthMessage)]
        public string Name { get; set; } = string.Empty;
    }
}
