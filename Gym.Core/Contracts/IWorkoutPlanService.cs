using Gym.Core.Models.Diet;
using Gym.Core.Models.WorkoutPlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
