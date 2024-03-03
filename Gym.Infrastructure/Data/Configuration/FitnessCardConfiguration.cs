using Gym.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gym.Infrastructure.Data.Configuration
{
    public class FitnessCardConfiguration : IEntityTypeConfiguration<FitnessCard>
    {
        public void Configure(EntityTypeBuilder<FitnessCard> builder)
        {
            builder.HasData(SeedFitnessCards());
        }

        private List<FitnessCard> SeedFitnessCards()
        {
            List<FitnessCard> fitnessCards = new List<FitnessCard>();

            FitnessCard fitnessCard;

            fitnessCard = new FitnessCard()
            {
                Id = 1,
                FitnessCardCategoryId = 3,
                Description = "You have access to the gym every day before 4pm. The duration of this card is 1 month.",
                Price = 40,
                CreatorId = "2a2dba3e-f9bf-4c83-83eb-fbd8af5f891c",
                ImageUrl = "https://png.pngtree.com/template/20211021/ourmid/pngtree-personal-fitness-trainer-black-business-card-image_708208.png"
                
            };

            fitnessCards.Add(fitnessCard);

            return fitnessCards;
        }
    }
}
