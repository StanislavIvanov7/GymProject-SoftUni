using Gym.Core.Contracts;
using Gym.Core.Models.WorkoutPlan;
using Gym.Infrastructure.Data.Common;
using Gym.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Core.Services
{
    public class WorkoutPlanService : IWorkoutPlanService
    {
        private readonly IRepository repository;
        public WorkoutPlanService(IRepository _repository)
        {
                repository = _repository;
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

        public async  Task<DetailsWorkoutPlanViewModel> DetailsWorkoutPlansAsync(int id)
        {
            var workoutPlan = await repository.All<WorkoutPlan>().Where(x=>x.Id == id)
                .Select(x=> new DetailsWorkoutPlanViewModel()
                {
                    Id= x.Id,
                    Name = x.Name,  
                    ImageUrl = x.ImageUrl,
                    Description = x.Description,
                    Creator = x.Creator.UserName ,
                    WorkoutPlanCategory = x.FitnessProgramCategory.Name

                }).FirstOrDefaultAsync();

            if(workoutPlan == null)
            {
                throw new ArgumentException("Invalid workout plan");
            }

            return workoutPlan;
        }
    }
}
