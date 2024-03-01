using Gym.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gym.Infrastructure.Data.Configuration
{
    public class DietCategoryConfiguration : IEntityTypeConfiguration<DietCategory>
    {
        public void Configure(EntityTypeBuilder<DietCategory> builder)
        {
            builder.HasData(SeedCategories());
        }

        private List<DietCategory> SeedCategories()
        {
            List<DietCategory> categories = new List<DietCategory>();

            DietCategory category;

            category = new DietCategory()
            {
                Id = 1,
                Name = "Weight loss"
            };
            categories.Add(category);

            category = new DietCategory()
            {
                Id = 2,
                Name = "Weight gain"
            };
            categories.Add(category);

            category = new DietCategory()
            {
                Id = 3,
                Name = "Weight maintenance"
            };
            categories.Add(category);

            return categories;
        }
    }
}