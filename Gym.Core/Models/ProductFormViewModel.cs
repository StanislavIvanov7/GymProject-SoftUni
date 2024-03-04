using System.ComponentModel.DataAnnotations;

using static Gym.Core.Constants.MessageConstants;
using static Gym.Infrastructure.Constants.DataConstant.Product;

namespace Gym.Core.Models
{
    public class ProductFormViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MaxLengthName, MinimumLength = MinLengthName, ErrorMessage = LengthMessage)]
        public string Name { get; set; } = string.Empty;

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
        public int ProductCategoryId { get; set; }


        public IEnumerable<AllProductCategoryViewModel> ProductCategories { get; set; }
            = new List<AllProductCategoryViewModel>();


        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MaxLengthImageUrl, MinimumLength = MinLengthImageUrl, ErrorMessage = LengthMessage)]
        public string ImageUrl { get; set; } = string.Empty;


    }
}
