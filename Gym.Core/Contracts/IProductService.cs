using Gym.Core.Enumerations;
using Gym.Core.Models;
using Gym.Core.Models.FitnessCard;
using Gym.Infrastructure.Data.Models;

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

        Task<IEnumerable<AllProductViewModel>> AllProductsInCartAsync(string userId);

        Task AddToCartAsync(int id,string userId);

        Task<UserProduct?> GetProductInCartAsync(string userId,int id);

        Task RemoveFromCartAsync(int id,string userId);

        Task<bool> CategoryExistAsync(int id);

        Task<bool> ExistAsync(int id);

        Task BuyAsync(int id, string userId);

        Task<bool> IsInUserCart(int id, string userId);

        Task<IEnumerable<AllProductViewModel>> AllPurchasedProductsAsync(string userId);

        Task<bool> CanBuyAsync(int id);


    }
}
