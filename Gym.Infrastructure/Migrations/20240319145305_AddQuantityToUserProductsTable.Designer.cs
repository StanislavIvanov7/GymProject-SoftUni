﻿// <auto-generated />
using System;
using Gym.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gym.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240319145305_AddQuantityToUserProductsTable")]
    partial class AddQuantityToUserProductsTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Gym.Infrastructure.Data.Models.Diet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Diet identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Diet creator identifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("Diet description");

                    b.Property<int>("DietCategoryId")
                        .HasColumnType("int")
                        .HasComment("Diet category identifier");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)")
                        .HasComment("Diet image url");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)")
                        .HasComment("Diet title");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("DietCategoryId");

                    b.ToTable("Diets");

                    b.HasComment("Diet table");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatorId = "2a2dba3e-f9bf-4c83-83eb-fbd8af5f891c",
                            Description = "Breakfast: 1 boiled egg, 1 slice whole grain toast, 1/2 grapefruit, green tea. Snack: 1 small apple, 10 almonds. Lunch: Grilled chicken, mixed greens. Snack: Greek yogurt with berries. Dinner: Baked salmon, quinoa, asparagus.",
                            DietCategoryId = 1,
                            ImageUrl = "https://www.fitterfly.com/blog/wp-content/uploads/2022/12/Step-by-Step-Diet-Plan-for-Weight-Loss-copy_11zon.webp",
                            Title = "The best diet for weight loss"
                        });
                });

            modelBuilder.Entity("Gym.Infrastructure.Data.Models.DietCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Diet category identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Diet category name");

                    b.HasKey("Id");

                    b.ToTable("DietCategories");

                    b.HasComment("Diet category table");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Weight loss"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Weight gain"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Weight maintenance"
                        });
                });

            modelBuilder.Entity("Gym.Infrastructure.Data.Models.FitnessCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Fitness card identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Fitness card creator identifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("Fitness card description");

                    b.Property<int>("DurationInMonths")
                        .HasColumnType("int")
                        .HasComment("Fitness card duration");

                    b.Property<int>("FitnessCardCategoryId")
                        .HasColumnType("int")
                        .HasComment("Fitness card category identifier");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)")
                        .HasComment("Fitness card image url");

                    b.Property<DateTime>("IssuesDate")
                        .HasColumnType("datetime2")
                        .HasComment("Fitness card issues date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Fitness card name");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Fitness card price");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("FitnessCardCategoryId");

                    b.ToTable("FitnessCards");

                    b.HasComment("Fitness card table");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatorId = "2a2dba3e-f9bf-4c83-83eb-fbd8af5f891c",
                            Description = "You have access to the gym every day before 4pm. The duration of this card is 1 month.",
                            DurationInMonths = 1,
                            FitnessCardCategoryId = 3,
                            ImageUrl = "https://mymetalbusinesscard.com/wp-content/uploads/2022/10/Fitness-Cards-Blog-Images.jpg",
                            IssuesDate = new DateTime(2024, 3, 19, 16, 53, 5, 138, DateTimeKind.Local).AddTicks(4874),
                            Name = "Fitness card for men before 4pm.",
                            Price = 40m
                        });
                });

            modelBuilder.Entity("Gym.Infrastructure.Data.Models.FitnessCardCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Fitness card category identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Fitness card category name");

                    b.HasKey("Id");

                    b.ToTable("FitnessCardCategories");

                    b.HasComment("Fitnes card category table");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Group training"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Individual training"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Until 4pm. for men"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Until 4pm. for girls"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Unlimited access for men"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Unlimited access for girls"
                        });
                });

            modelBuilder.Entity("Gym.Infrastructure.Data.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Product identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Product creator identifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("Product description");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)")
                        .HasComment("Product image url");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Product name");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Product price");

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("int")
                        .HasComment("Product category identifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasComment("Product quantity");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("Products");

                    b.HasComment("Product table");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatorId = "2a2dba3e-f9bf-4c83-83eb-fbd8af5f891c",
                            Description = "The best protein bar.High amount of proteins (18 grams).",
                            ImageUrl = "https://fitspo.zone/wp-content/uploads/2022/11/slim_choco_brownie_front.jpg",
                            Name = "Fit Spo Slim Bar",
                            Price = 3.50m,
                            ProductCategoryId = 1,
                            Quantity = 100
                        });
                });

            modelBuilder.Entity("Gym.Infrastructure.Data.Models.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Product category identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Product category name");

                    b.HasKey("Id");

                    b.ToTable("ProductCategories");

                    b.HasComment("Product category table");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Protein bars"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Fitness supplements"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Fruits"
                        });
                });

            modelBuilder.Entity("Gym.Infrastructure.Data.Models.UserFitnessCard", b =>
                {
                    b.Property<int>("FitnessCardId")
                        .HasColumnType("int")
                        .HasComment("Fitness card identifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)")
                        .HasComment("User identifier");

                    b.HasKey("FitnessCardId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersFitnessCards");

                    b.HasComment("Fitness card-user mapping table");
                });

            modelBuilder.Entity("Gym.Infrastructure.Data.Models.UserProduct", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)")
                        .HasComment("User identifier");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasComment("Product identifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("UserId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("UsersProducts");

                    b.HasComment("Users and products mapping table");
                });

            modelBuilder.Entity("Gym.Infrastructure.Data.Models.WorkoutPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Workout plan identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Workout plan creator identifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("Workout plan description");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)")
                        .HasComment("Workout plan image url");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Workout plan name");

                    b.Property<int>("WorkoutPlanCategoryId")
                        .HasColumnType("int")
                        .HasComment("Workout plan category identifier");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("WorkoutPlanCategoryId");

                    b.ToTable("WorkoutPlans");

                    b.HasComment("Workout plan table");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatorId = "2a2dba3e-f9bf-4c83-83eb-fbd8af5f891c",
                            Description = "first day-chest and arms, second day-back and shoulder, third day-legs, fourth day-rest",
                            ImageUrl = "https://i0.wp.com/www.muscleandfitness.com/wp-content/uploads/2016/09/Bodybuilder-Working-Out-His-Upper-Body-With-Cable-Crossover-Exercise.jpg?quality=86&strip=all",
                            Name = "The best workout plan for begginar",
                            WorkoutPlanCategoryId = 2
                        });
                });

            modelBuilder.Entity("Gym.Infrastructure.Data.Models.WorkoutPlanCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Workout plan category identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Workout plan category name");

                    b.HasKey("Id");

                    b.ToTable("WorkoutPlanCategories");

                    b.HasComment("Workout plan category table");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Amateur"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Beginner"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Advanced"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Professional"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Gym.Infrastructure.Data.Models.Diet", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gym.Infrastructure.Data.Models.DietCategory", "DietCategory")
                        .WithMany("Diets")
                        .HasForeignKey("DietCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("DietCategory");
                });

            modelBuilder.Entity("Gym.Infrastructure.Data.Models.FitnessCard", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gym.Infrastructure.Data.Models.FitnessCardCategory", "FitnessCardCategory")
                        .WithMany("FitnesCards")
                        .HasForeignKey("FitnessCardCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("FitnessCardCategory");
                });

            modelBuilder.Entity("Gym.Infrastructure.Data.Models.Product", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gym.Infrastructure.Data.Models.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("Gym.Infrastructure.Data.Models.UserFitnessCard", b =>
                {
                    b.HasOne("Gym.Infrastructure.Data.Models.FitnessCard", "FitnessCard")
                        .WithMany("UserFitnessCards")
                        .HasForeignKey("FitnessCardId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FitnessCard");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Gym.Infrastructure.Data.Models.UserProduct", b =>
                {
                    b.HasOne("Gym.Infrastructure.Data.Models.Product", "Product")
                        .WithMany("UserProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Gym.Infrastructure.Data.Models.WorkoutPlan", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gym.Infrastructure.Data.Models.WorkoutPlanCategory", "WorkoutPlanCategory")
                        .WithMany("FitnesPrograms")
                        .HasForeignKey("WorkoutPlanCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("WorkoutPlanCategory");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Gym.Infrastructure.Data.Models.DietCategory", b =>
                {
                    b.Navigation("Diets");
                });

            modelBuilder.Entity("Gym.Infrastructure.Data.Models.FitnessCard", b =>
                {
                    b.Navigation("UserFitnessCards");
                });

            modelBuilder.Entity("Gym.Infrastructure.Data.Models.FitnessCardCategory", b =>
                {
                    b.Navigation("FitnesCards");
                });

            modelBuilder.Entity("Gym.Infrastructure.Data.Models.Product", b =>
                {
                    b.Navigation("UserProducts");
                });

            modelBuilder.Entity("Gym.Infrastructure.Data.Models.ProductCategory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Gym.Infrastructure.Data.Models.WorkoutPlanCategory", b =>
                {
                    b.Navigation("FitnesPrograms");
                });
#pragma warning restore 612, 618
        }
    }
}
