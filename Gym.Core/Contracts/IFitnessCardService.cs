using Gym.Infrastructure.Data.Models;

namespace Gym.Core.Models.FitnessCard
{
    public interface IFitnessCardService
    {
        Task<IEnumerable<AllFitnessCardViewModel>> AllFitnessCardAsync();

        Task<IEnumerable<FitnessCardCategoryViewModel>> GetFitnessCardCategoryAsync();

        Task AddAsync(FitnessCardFormViewModel model, string userId);

        Task<DetailsFitnessCardViewModel> DetailsFitnessCardAsync(int id);

        Task<FitnessCardFormViewModel> GetFitnessCardForEditAsync(int id);

        Task<DeleteFitnessCardViewModel> GetFitnessCardForDeleteAsync(int id);

        Task EditAsync(int id, FitnessCardFormViewModel model);

        Task RemoveAsync(int id);

        Task<IEnumerable<AllFitnessCardViewModel>> AllFitnessCardInCartAsync(string userId);

        Task AddToCartAsync(int id, string userId);

        Task<UserFitnessCard?> GetFitnessCardInCartAsync(string userId,int id);

        Task RemoveFromCartAsync(int id, string userId);

        Task<bool> CategoryExistAsync(int id);

        Task<bool> ExistAsync(int id);

        Task<bool> ExistInCartAsync(int id);
    }
}
