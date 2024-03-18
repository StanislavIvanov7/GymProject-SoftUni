using System.ComponentModel.DataAnnotations;
using static Gym.Core.Constants.MessageConstants;
using static Gym.Infrastructure.Constants.DataConstant.FitnessCard;

namespace Gym.Core.Models.FitnessCard
{
    public class FitnessCardFormViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(decimal),
             MinLengthPrice,
             MaxLengthPrice,
             ConvertValueInInvariantCulture = true,
             ErrorMessage = "Price per month must be a positive number and less than {2} leva")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MaxLengthDescription, MinimumLength = MinLengthDescription, ErrorMessage = LengthMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        public int FitnessCardCategoryId { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MaxLengthName, MinimumLength = MinLengthName, ErrorMessage = LengthMessage)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(int),MinLengthDuration,MaxLengthDuration,ErrorMessage = "Duration must be a number between {1} and {2}")]
        public int DurationInMonths { get; set; }


        public IEnumerable<FitnessCardCategoryViewModel> FitnessCardCategories { get; set; }
            = new List<FitnessCardCategoryViewModel>();


        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MaxLengthImageUrl, MinimumLength = MinLengthImageUrl, ErrorMessage = LengthMessage)]
        public string ImageUrl { get; set; } = string.Empty;
    }
}
