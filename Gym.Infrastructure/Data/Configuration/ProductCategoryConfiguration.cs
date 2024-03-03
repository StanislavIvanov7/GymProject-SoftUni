using Gym.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gym.Infrastructure.Data.Configuration
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasData(SeedCategories());
        }

        private List<ProductCategory> SeedCategories()
        {
            List<ProductCategory> categories = new List<ProductCategory>();

            ProductCategory category;

            category = new ProductCategory()
            {
                Id = 1,
                Name = "Protein bars"
            };
            categories.Add(category);

            category = new ProductCategory()
            {
                Id = 2,
                Name = "Fitness supplements"
            };
            categories.Add(category);

            category = new ProductCategory()
            {
                Id = 3,
                Name = "Fruits"
            };
            categories.Add(category);

            return categories;
        }
    }
}