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
    }
}
