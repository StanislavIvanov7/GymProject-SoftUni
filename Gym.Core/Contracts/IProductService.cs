using Gym.Core.Models;
using Gym.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Core.Contracts
{
    public interface IProductService
    {
       Task<IEnumerable<AllProductViewModel>> AllProductsAsync();

        Task AddAsync(ProductFormViewModel model,string userId);

        Task<ProductFormViewModel> GetByIdAsync(int id);

        Task<IEnumerable<AllProductCategoryViewModel>> GetProductCategoryAsync();
    }
}
