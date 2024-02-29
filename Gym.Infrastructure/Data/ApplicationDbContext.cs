using Gym.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gym.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserFoodItem>()
                .HasKey(x => new { x.UserId, x.FoodItemId });

            builder.Entity<UserFoodItem>()
                .HasOne(x=>x.FoodItem)
                .WithMany(x=>x.UserFoodItems)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UserFitnessCard>()
                .HasKey(x=> new { x.FitnessCardId, x.UserId });


            builder.Entity<UserFitnessCard>()
                .HasOne(x => x.FitnessCard)
                .WithMany(x => x.UserFitnessCards)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }

        public DbSet<FoodItem> FoodItems { get; set; } = null!;
        public DbSet<FoodItemCategory> FoodItemCategories { get; set; } = null!;
        public DbSet<UserFoodItem> UsersFoodItems { get; set; } = null!;

        public DbSet<FitnessCard> FitnessCards { get; set; } = null!;
        public DbSet<FitnessCardCategory> FitnessCardCategories { get; set; } = null!;
        public DbSet<UserFitnessCard> UsersFitnessCards { get; set; } = null!;

    }
}