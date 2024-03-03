using Gym.Infrastructure.Data.Configuration;
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
            builder.Entity<UserProduct>()
                .HasKey(x => new { x.UserId, x.ProductId });

            builder.Entity<UserProduct>()
                .HasOne(x=>x.Product)
                .WithMany(x=>x.UserProducts)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UserFitnessCard>()
                .HasKey(x=> new { x.FitnessCardId, x.UserId });


            builder.Entity<UserFitnessCard>()
                .HasOne(x => x.FitnessCard)
                .WithMany(x => x.UserFitnessCards)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ApplyConfiguration(new DietCategoryConfiguration());
            builder.ApplyConfiguration(new DietConfiguration());
            builder.ApplyConfiguration(new WorkoutPlanCategoryConfiguration());
            builder.ApplyConfiguration(new WorkoutPlanConfiguration());
            builder.ApplyConfiguration(new ProductCategoryConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new FitnessCardCategoryConfiguration());
            builder.ApplyConfiguration(new FitnessCardConfiguration());

            base.OnModelCreating(builder);
        }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<ProductCategory> ProductCategories { get; set; } = null!;
        public DbSet<UserProduct> UsersProducts { get; set; } = null!;

        public DbSet<FitnessCard> FitnessCards { get; set; } = null!;
        public DbSet<FitnessCardCategory> FitnessCardCategories { get; set; } = null!;
        public DbSet<UserFitnessCard> UsersFitnessCards { get; set; } = null!;

        public DbSet<Diet> Diets { get; set; } = null!;
        public DbSet<DietCategory> DietCategories { get; set; } = null!;

        public DbSet<WorkoutPlan> WorkoutPlans { get; set; } = null!;
        public DbSet<WorkoutPlanCategory> WorkoutPlanCategories { get; set; } = null!;

    }
}