using Gym.Core.Contracts;
using Gym.Core.Models.Diet;
using Gym.Core.Models.WorkoutPlan;
using Gym.Infrastructure.Data.Common;
using Gym.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;


namespace Gym.Core.Services
{
    public class WorkoutPlanService : IWorkoutPlanService
    {
        private readonly IRepository repository;
        public WorkoutPlanService(IRepository _repository)
        {
                repository = _repository;
        }

        public async Task AddAsync(string userId, WorkoutPlanFormViewModel model)
        {
            var workoutPlan = new WorkoutPlan()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                CreatorId = userId,
                ImageUrl = model.ImageUrl,
                WorkoutPlanCategoryId = model.WorkoutPlanCategoryId,

            };

            await repository.AddAsync(workoutPlan);
            await repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllWorkoutPlanViewModel>> AllWorkoutPlansAsync()
        {
            var workoutPlans = await repository.AllAsReadOnly<WorkoutPlan>()
                .Select(x => new AllWorkoutPlanViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl,

                }).ToListAsync();

            return workoutPlans;
        }

        public async Task<bool> CategoryExistAsync(int id)
        {
            return await repository.AllAsReadOnly<WorkoutPlanCategory>()
                 .AnyAsync(x => x.Id == id);
        }

        public async  Task<DetailsWorkoutPlanViewModel> DetailsWorkoutPlansAsync(int id)
        {
            var workoutPlan = await repository.All<WorkoutPlan>()
                .Where(x=>x.Id == id)
                .Select(x=> new DetailsWorkoutPlanViewModel()
                {
                    Id= x.Id,
                    Name = x.Name,  
                    ImageUrl = x.ImageUrl,
                    Description = x.Description,
                    CreatorName = x.Creator.FirstName + " " + x.Creator.LastName,
                    CreatorEmail = x.Creator.Email,
                    WorkoutPlanCategory = x.WorkoutPlanCategory.Name

                }).FirstAsync();

            return workoutPlan;
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await repository.AllAsReadOnly<WorkoutPlan>()
                .AnyAsync(x => x.Id == id);
        }

        public async Task<WorkoutPlanFormViewModel> GetWorkoutPlanForEditAsync(int id)
        {
            var workoutPlan = await repository.AllAsReadOnly<WorkoutPlan>()
                 .Where(x => x.Id == id)
                 .Select(x => new WorkoutPlanFormViewModel()
                 {
                     Id = id,
                     Name = x.Name,
                     Description = x.Description,
                     ImageUrl= x.ImageUrl,
                     WorkoutPlanCategoryId = x.WorkoutPlanCategoryId,
                     
                 })
                 .FirstAsync();

            return workoutPlan;
        }

        public async Task<IEnumerable<WorkoutPlanCategoryViewModel>> GetWorkoutPlanCategoriesAsync()
        {
            var categories = await repository.All<WorkoutPlanCategory>()
                .Select(x => new WorkoutPlanCategoryViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToListAsync();

            return categories;
        }

        public async Task<DeleteWorkoutPlanViewModel> GetWorkoutPlanForDeleteAsync(int id)
        {

            var workoutPlan = await repository.AllAsReadOnly<WorkoutPlan>()
                .Where(x=>x.Id == id)
                .Select(x=> new DeleteWorkoutPlanViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl
                }).FirstAsync();

            return workoutPlan;
        }

        public async Task RemoveAsync(int id)
        {
            var workoutPlan = await repository.GetByIdAsync<WorkoutPlan>(id);

            if (workoutPlan != null)
            {
                repository.Delete(workoutPlan);
                await repository.SaveChangesAsync();
            }

           
        }

        public async Task EditAsync(int id, WorkoutPlanFormViewModel model)
        {
            var workoutPlan = await repository.GetByIdAsync<WorkoutPlan>(id);

            if (workoutPlan != null)
            {
                workoutPlan.Description = model.Description;
                workoutPlan.Name = model.Name;
                workoutPlan.ImageUrl = model.ImageUrl;
                workoutPlan.WorkoutPlanCategoryId = model.WorkoutPlanCategoryId;

                await repository.SaveChangesAsync();
            }
        }

        public async Task<bool> UserHasFitnessCardAsync(string userId)
        {
            var uf = await repository.AllAsReadOnly<BuyerFitnessCard>()
                 .FirstOrDefaultAsync(x => x.BuyerId == userId);

            if (uf == null)
            {
                return false;
            }

            return true;
        }
    }
}
