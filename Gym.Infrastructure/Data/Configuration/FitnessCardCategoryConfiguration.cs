using Gym.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gym.Infrastructure.Data.Configuration
{
    public class FitnessCardCategoryConfiguration : IEntityTypeConfiguration<FitnessCardCategory>
    {
        public void Configure(EntityTypeBuilder<FitnessCardCategory> builder)
        {
            builder.HasData(SeedFitnesCardCategory());
        }

        private List<FitnessCardCategory> SeedFitnesCardCategory()
        {
            List<FitnessCardCategory> categories = new List<FitnessCardCategory>();

            FitnessCardCategory category;

            category = new FitnessCardCategory()
            {
                Id = 1,
                Name = "Group training",
            };
            categories.Add(category);

            category = new FitnessCardCategory()
            {
                Id= 2,
                Name = "Individual training",
            };
            categories.Add(category);

            category = new FitnessCardCategory()
            {
                Id = 3,
                Name = "Until 4pm. for men",
            };
            categories.Add(category);

            category = new FitnessCardCategory()
            {
                Id = 4,
                Name = "Until 4pm. for girls"
            };
            categories.Add(category);

            category = new FitnessCardCategory()
            {
                Id = 5,
                Name = "Unlimited access for men"
            };
            categories.Add(category);

            category = new FitnessCardCategory()
            {
                Id = 6,
                Name = "Unlimited access for girls"
            };
            categories.Add(category);
            
            return categories;
        }
    }
}
