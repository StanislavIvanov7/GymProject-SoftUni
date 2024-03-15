using Gym.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gym.Infrastructure.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(SeedProducts());
        }

        private List<Product> SeedProducts()
        {
            List<Product> products = new List<Product>();

            Product product;

            product = new Product()
            {
                Id = 1,
                CreatorId = "2a2dba3e-f9bf-4c83-83eb-fbd8af5f891c",
                Description = "The best protein bar.High amount of proteins (18 grams).",
                Quantity = 100,
                Name = "Fit Spo Slim Bar",
                ImageUrl = "https://fitspo.zone/wp-content/uploads/2022/11/slim_choco_brownie_front.jpg",
                Price = 3.50m,
                ProductCategoryId = 1,

            };

            products.Add(product);

            return products;
        }
    }
}