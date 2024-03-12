using Gym.Core.Models;
using Gym.Core.Models.WorkoutPlan;
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

        Task<ProductFormViewModel> GetProductForEditAsync(int id);

        Task<IEnumerable<AllProductCategoryViewModel>> GetProductCategoryAsync();

        Task EditAsync(int id,ProductFormViewModel model);

        Task<DetailsProductViewModel> DetailsProductAsync(int id);

        Task<DeleteProductViewModel> GetProductForDeleteAsync(int id);

        Task RemoveAsync(int id);
        

    }
}
