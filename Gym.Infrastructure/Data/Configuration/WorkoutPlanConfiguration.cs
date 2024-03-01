using Gym.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Infrastructure.Data.Configuration
{
    public class WorkoutPlanConfiguration : IEntityTypeConfiguration<WorkoutPlan>
    {
        public void Configure(EntityTypeBuilder<WorkoutPlan> builder)
        {
            builder.HasData(SeedWorkoutPlan());
        }

        private List<WorkoutPlan> SeedWorkoutPlan()
        {
            List<WorkoutPlan> workoutPlans = new List<WorkoutPlan>();

            WorkoutPlan workoutPlan;

            workoutPlan = new WorkoutPlan()
            {
                Id = 1,
                CreatorId = "2a2dba3e-f9bf-4c83-83eb-fbd8af5f891c",
                Description = "first day-chest and arms, second day-back and shoulder, third day-legs, fourth day-rest",
                Name = "The best workout plan for begginar",
                WorkoutPlanCategoryId = 2,
                ImageUrl = "https://i0.wp.com/www.muscleandfitness.com/wp-content/uploads/2016/09/Bodybuilder-Working-Out-His-Upper-Body-With-Cable-Crossover-Exercise.jpg?quality=86&strip=all"
            };

            workoutPlans.Add(workoutPlan);

            return workoutPlans;
        }
    }
}
