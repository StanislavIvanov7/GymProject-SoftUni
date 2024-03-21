using Gym.Core.Models.Diet;

namespace Gym.Core.Contracts
{
    public interface IDietService
    {
        Task<IEnumerable<AllDietViewModel>> AllDietsAsync();

        Task<DetailsDietViewModel> DetailsDietAsync(int id);

        Task<IEnumerable<DietCategoryViewModel>> GetDietCategoriesAsync();

        Task AddAsync(DietFormViewModel model, string userId);

        Task<DietFormViewModel> GetDietForEditAsync(int id);

        Task<DeleteDietViewModel> GetDietForDeleteAsync(int id);

        Task EditAsync(int id, DietFormViewModel model);

        Task RemoveAsync(int id);

        Task<bool> ExistAsync(int id);

    }
}
