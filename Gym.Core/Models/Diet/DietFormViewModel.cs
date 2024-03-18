using System.ComponentModel.DataAnnotations;
using static Gym.Core.Constants.MessageConstants;
using static Gym.Infrastructure.Constants.DataConstant.Diet;

namespace Gym.Core.Models.Diet
{
    public class DietFormViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MaxLengthTitle, MinimumLength = MinLengthTitle, ErrorMessage = LengthMessage)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MaxLengthDescription, MinimumLength = MinLengthDescription, ErrorMessage = LengthMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        public int DietCategoryId { get; set; }


        public IEnumerable<DietCategoryViewModel> DietCategories { get; set; }
            = new List<DietCategoryViewModel>();


        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MaxLengthImageUrl, MinimumLength = MinLengthImageUrl, ErrorMessage = LengthMessage)]
        public string ImageUrl { get; set; } = string.Empty;
    }
}
