using System.ComponentModel.DataAnnotations;

using static Gym.Core.Constants.MessageConstants;
using static Gym.Infrastructure.Constants.DataConstant.ProductCategory;

namespace Gym.Core.Models.Product
{
    public class AllProductCategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MaxLengthName, MinimumLength = MinLengthName, ErrorMessage = LengthMessage)]
        public string Name { get; set; } = string.Empty;
    }
}
