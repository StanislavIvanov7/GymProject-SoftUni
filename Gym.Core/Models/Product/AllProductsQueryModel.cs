using Gym.Core.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace Gym.Core.Models.Product
{
    public class AllProductsQueryModel
    {
        public int ProductsPerPage { get; } = 3;

        public string Category { get; init; } = null!;

        [Display(Name = "Search by text")]
        public string SearchTerm { get; init; } = null!;

        public ProductSorting Sorting { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalProductsCount { get; set; }

        public IEnumerable<string> Categories { get; set; } = null!;

        public IEnumerable<AllProductViewModel> Products { get; set; } = new List<AllProductViewModel>();
    }
}
