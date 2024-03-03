using Gym.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gym.Infrastructure.Data.Configuration
{
    public class WorkoutPlanCategoryConfiguration : IEntityTypeConfiguration<WorkoutPlanCategory>
    {
        public void Configure(EntityTypeBuilder<WorkoutPlanCategory> builder)
        {
            builder.HasData(SeedCategories());
        }

        private List<WorkoutPlanCategory> SeedCategories()
        {
            List<WorkoutPlanCategory> categories = new List<WorkoutPlanCategory>();

            WorkoutPlanCategory category;

            category = new WorkoutPlanCategory()
            {
                Id = 1,
                Name = "Amateur"
            };
            categories.Add(category);

            category = new WorkoutPlanCategory()
            {
                Id = 2,
                Name = "Beginner"
            };
            categories.Add(category);

            category = new WorkoutPlanCategory()
            {
                Id = 3,
                Name = "Advanced"
            };
            categories.Add(category);

            category = new WorkoutPlanCategory()
            {
                Id = 4,
                Name = "Professional"
            };
            categories.Add(category);

            return categories;
        }
    }
}