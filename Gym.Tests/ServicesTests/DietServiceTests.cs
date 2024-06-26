﻿using Gym.Core.Contracts;
using Gym.Core.Models.Diet;
using Gym.Core.Services;
using Gym.Infrastructure.Data;
using Gym.Infrastructure.Data.Common;
using Gym.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework.Internal;

namespace Gym.Tests.ServicesTests
{
    [TestFixture]
    public class DietServiceTests
    {
        private IRepository repo;
        private IDietService dietService;
        private ApplicationDbContext applicationDbContext;

        [SetUp]
        public void Setup()
        {
           
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("HouseDB")
                .Options;

            applicationDbContext = new ApplicationDbContext(contextOptions);

            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Database.EnsureCreated();
        }


        [Test]
        public async Task AllDietTestInMemory()
        {
           
            var repo = new Repository(applicationDbContext);
            dietService = new DietService(repo);

            await repo.AddRangeAsync(new List<Diet>()
            {
                new Diet() { Id = 2, ImageUrl = "", Title = ""},
                new Diet() { Id = 3, ImageUrl = "", Title = ""},
       
            });

            await repo.SaveChangesAsync();

            var dietCollection = await dietService.AllDietsAsync();

            Assert.That(3, Is.EqualTo(dietCollection.Count()));
            Assert.That(dietCollection.Any(h => h.Id == 4), Is.False);
        }

        [Test]
        public async Task TestDietEdit()
        {
         
            var repo = new Repository(applicationDbContext);
            dietService = new DietService(repo);

            await repo.AddAsync(new Diet()
            {
                Id = 2,
                DietCategoryId = 1,
                ImageUrl = "",
                Title = "",
                Description = ""
            });

            await repo.SaveChangesAsync();

            await dietService.EditAsync(2, new DietFormViewModel()
            {
                Id = 2,
                DietCategoryId = 1,
                ImageUrl = "",
                Title = "",
                Description = "This diet is edited",
            });

            var dbDiet = await repo.GetByIdAsync<Diet>(2);

            Assert.That(dbDiet.Description, Is.EqualTo("This diet is edited"));
        }

        [Test]
        public async Task GetDietForEditTestInMemory()
        {

            var repo = new Repository(applicationDbContext);
            dietService = new DietService(repo);
            
            await repo.AddRangeAsync(new List<Diet>()
            {
                new Diet() { Id = 2, ImageUrl = "", Title = "diet",Description = "",DietCategoryId = 1},
                new Diet() { Id = 3, ImageUrl = "", Title = "",Description = "",DietCategoryId = 1},

            });

            await repo.SaveChangesAsync();

            var diet = await dietService.GetDietForEditAsync(2);

            Assert.That(2, Is.EqualTo(diet.Id));
            Assert.AreEqual(diet.Title, "diet");
        }

        [Test]
        public async Task GetDietCategoryTestInMemory()
        {

            var repo = new Repository(applicationDbContext);
            dietService = new DietService(repo);

            await repo.AddAsync(new DietCategory()
            {
                Id = 4,
                Name = ""

            });

            await repo.SaveChangesAsync();

            var dietCollection = await dietService.GetDietCategoriesAsync();

            Assert.That(4, Is.EqualTo(dietCollection.Count()));
            Assert.That(dietCollection.Any(h => h.Id == 5), Is.False);
        }

        [Test]
        public async Task GetDietForDeleteTestInMemory()
        {

            var repo = new Repository(applicationDbContext);
            dietService = new DietService(repo);

            await repo.AddRangeAsync(new List<Diet>()
            {
                new Diet() { Id = 2, ImageUrl = "", Title = "diet",Description = "",DietCategoryId = 1},
                new Diet() { Id = 3, ImageUrl = "", Title = "",Description = "",DietCategoryId = 1},

            });

            await repo.SaveChangesAsync();

            var diet = await dietService.GetDietForDeleteAsync(2);

            Assert.That(2, Is.EqualTo(diet.Id));
            Assert.AreEqual(diet.Title, "diet");
        }

        [Test]
        public async Task ExistDietTestInMemory()
        {

            var repo = new Repository(applicationDbContext);
            dietService = new DietService(repo);

            await repo.AddRangeAsync(new List<Diet>()
            {
                new Diet() { Id = 2, ImageUrl = "", Title = "diet",Description = "",DietCategoryId = 1},
                new Diet() { Id = 3, ImageUrl = "", Title = "",Description = "",DietCategoryId = 1},

            });

            await repo.SaveChangesAsync();

            var diet = await dietService.ExistAsync(2);

            Assert.IsTrue(diet);
        }

        [Test]
        public async Task CategoryExistDietTestInMemory()
        {

            var repo = new Repository(applicationDbContext);
            dietService = new DietService(repo);

            await repo.AddAsync(new DietCategory()
            {
                Id = 4,
                Name = ""

            });

            await repo.SaveChangesAsync();

            var diet = await dietService.CategoryExistAsync(2);

            Assert.IsTrue(diet);
        }


        [Test]
        public async Task AddDietTestInMemory()
        {

            var repo = new Repository(applicationDbContext);
            dietService = new DietService(repo);

            var model = new DietFormViewModel()
            {
                Id = 2,
                Title = "diet",
                Description = "",
                DietCategoryId = 1,
                ImageUrl = "",
            };


            await dietService.AddAsync(model, "2a2dba3e-f9bf-4c83-83eb-fbd8af5f891c");

            var dbProduct = await repo.GetByIdAsync<Diet>(2);

            Assert.That(dbProduct.Id, Is.EqualTo(2));

            Assert.That(dbProduct.Title, Is.EqualTo("diet"));

        }

        [Test]
        public async Task RemoveDietTestInMemory()
        {

            var repo = new Repository(applicationDbContext);
            dietService = new DietService(repo);

            var model = new Diet()
            {
                Id = 2,
                Title = "diet",
                Description = "",
                DietCategoryId = 1,
                ImageUrl = "",
            };

            await repo.AddAsync(model);
            await repo.SaveChangesAsync();


            await dietService.RemoveAsync(2);

            var dbProduct = await repo.GetByIdAsync<Diet>(2);

            Assert.That(dbProduct, Is.EqualTo(null));

        }


        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
