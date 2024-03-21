using Gym.Core.Models.WorkoutPlan;

namespace Gym.Core.Contracts
{
    public interface IWorkoutPlanService
    {
        Task<IEnumerable<AllWorkoutPlanViewModel>> AllWorkoutPlansAsync();

        Task<DetailsWorkoutPlanViewModel> DetailsWorkoutPlansAsync(int id);

        Task<IEnumerable<WorkoutPlanCategoryViewModel>> GetWorkoutPlanCategoriesAsync();

        Task AddAsync(string userId ,WorkoutPlanFormViewModel model);

        Task<DeleteWorkoutPlanViewModel> GetWorkoutPlanForDeleteAsync(int id);

        Task RemoveAsync(int id);

        Task<bool> ExistAsync(int id);

        Task<bool> CategoryExistAsync(int id);
    }
}
