using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Core.Models
{
    public class ProductQueryViewModel
    {
        public int TotalProductsCount { get; set; }

        public IEnumerable<AllProductViewModel> Products { get; set; } = new List<AllProductViewModel>();
    }
}
