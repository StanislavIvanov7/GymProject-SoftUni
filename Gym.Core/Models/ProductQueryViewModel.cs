namespace Gym.Core.Models
{
    public class ProductQueryViewModel
    {
        public int TotalProductsCount { get; set; }

        public IEnumerable<AllProductViewModel> Products { get; set; } = new List<AllProductViewModel>();
    }
}
