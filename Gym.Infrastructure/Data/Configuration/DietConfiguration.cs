using Gym.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gym.Infrastructure.Data.Configuration
{
    public class DietConfiguration : IEntityTypeConfiguration<Diet>
    {
        public void Configure(EntityTypeBuilder<Diet> builder)
        {
            builder.HasData(SeedDiets());
        }

        private List<Diet> SeedDiets()
        {
            List<Diet> diets = new List<Diet>();

            Diet diet;

            diet = new Diet()
            {
                Id = 1,
                Title = "The best diet for weight loss",
                Description = "Breakfast: 1 boiled egg, 1 slice whole grain toast, 1/2 grapefruit, green tea. Snack: 1 small apple, 10 almonds. Lunch: Grilled chicken, mixed greens. Snack: Greek yogurt with berries. Dinner: Baked salmon, quinoa, asparagus.",
                CreatorId = "2a2dba3e-f9bf-4c83-83eb-fbd8af5f891c",
                DietCategoryId = 1,
                ImageUrl = "https://www.fitterfly.com/blog/wp-content/uploads/2022/12/Step-by-Step-Diet-Plan-for-Weight-Loss-copy_11zon.webp"

            };

            diets.Add(diet);

            return diets;
        }
    }
}