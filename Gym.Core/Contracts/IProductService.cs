using Gym.Core.Enumerations;
using Gym.Core.Models;

namespace Gym.Core.Contracts
{
    public interface IProductService
    {
        Task<ProductQueryViewModel> AllProductsAsync(
            string? category,
            string? searchTerm,
            ProductSorting sorting = ProductSorting.Newest,
            int currentPage = 1,
            int housesPerPage = 1);

        Task<IEnumerable<string>> AllCategoriesNamesAsync();

        Task AddAsync(ProductFormViewModel model,string userId);

        Task<ProductFormViewModel> GetProductForEditAsync(int id);

        Task<IEnumerable<AllProductCategoryViewModel>> GetProductCategoryAsync();

        Task EditAsync(int id,ProductFormViewModel model);

        Task<DetailsProductViewModel> DetailsProductAsync(int id);

        Task<DeleteProductViewModel> GetProductForDeleteAsync(int id);

        Task RemoveAsync(int id);
        

    }
}
