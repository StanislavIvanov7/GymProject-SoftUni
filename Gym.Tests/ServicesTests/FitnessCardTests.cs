using Gym.Core.Contracts;
using Gym.Infrastructure.Data.Common;
using Gym.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Core.Models.FitnessCard;
using Gym.Core.Models.Diet;
using Gym.Core.Services;
using Gym.Infrastructure.Data.Models;

namespace Gym.Tests.ServicesTests
{
    [TestFixture]
    public class FitnessCardTests
    {
        private IRepository repo;
        private IFitnessCardService fitnessCardService;
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
        public async Task AllFitnessCardTestInMemory()
        {

            var repo = new Repository(applicationDbContext);
            fitnessCardService = new FitnessCardService(repo);

            await repo.AddRangeAsync(new List<FitnessCard>()
            {
                new FitnessCard() { Id = 2, ImageUrl = "", Name = ""},
                new FitnessCard() { Id = 3, ImageUrl = "", Name = ""},
            });
            await repo.SaveChangesAsync();

            var dietCollection = await fitnessCardService.AllFitnessCardAsync();

            Assert.That(3, Is.EqualTo(dietCollection.Count()));
            Assert.That(dietCollection.Any(h => h.Id == 4), Is.False);
        }

        [Test]
        public async Task TestFitnessCardEdit()
        {

            var repo = new Repository(applicationDbContext);
            fitnessCardService = new FitnessCardService(repo);

            await repo.AddAsync(new FitnessCard()
            {
                Id = 2,
                FitnessCardCategoryId = 1,
                ImageUrl = "",
                Name = "",
                Description = ""
            });
            await repo.SaveChangesAsync();

            await fitnessCardService.EditAsync(2, new FitnessCardFormViewModel()
            {
                Id = 2,
                FitnessCardCategoryId = 1,
                ImageUrl = "",
                Name = "",
                Description = "This fitness card is edited",
            });

            var dbDiet = await repo.GetByIdAsync<FitnessCard>(2);

            Assert.That(dbDiet.Description, Is.EqualTo("This fitness card is edited"));
        }

        [Test]
        public async Task GetFitnessCardForEditTestInMemory()
        {

            var repo = new Repository(applicationDbContext);
            fitnessCardService = new FitnessCardService(repo);

            await repo.AddRangeAsync(new List<FitnessCard>()
            {
                new FitnessCard() { Id = 2, ImageUrl = "", Name = "fitness card",Description = "",FitnessCardCategoryId = 1},
                new FitnessCard() { Id = 3, ImageUrl = "", Name = "",Description = "",FitnessCardCategoryId = 1},

            });
            await repo.SaveChangesAsync();

            var diet = await fitnessCardService.GetFitnessCardForEditAsync(2);

            Assert.That(2, Is.EqualTo(diet.Id));
            Assert.AreEqual(diet.Name, "fitness card");
        }

        [Test]
        public async Task GetFitnessCardCategoryTestInMemory()
        {

            var repo = new Repository(applicationDbContext);
            fitnessCardService = new FitnessCardService(repo);

            await repo.AddAsync(new FitnessCardCategory()
            {
                Id = 7,
                Name = ""

            });
            await repo.SaveChangesAsync();

            var fitnessCardCollection = await fitnessCardService.GetFitnessCardCategoryAsync();

            Assert.That(7, Is.EqualTo(fitnessCardCollection.Count()));
            Assert.That(fitnessCardCollection.Any(h => h.Id == 8), Is.False);
        }

        [Test]
        public async Task GetFitnessCardForDeleteTestInMemory()
        {

            var repo = new Repository(applicationDbContext);
            fitnessCardService = new FitnessCardService(repo);

            await repo.AddRangeAsync(new List<FitnessCard>()
            {
                new FitnessCard() { Id = 2, ImageUrl = "", Name = "fitnessCard",Description = "",FitnessCardCategoryId = 1},
                new FitnessCard() { Id = 3, ImageUrl = "", Name = "",Description = "",FitnessCardCategoryId = 1},

            });
            await repo.SaveChangesAsync();

            var diet = await fitnessCardService.GetFitnessCardForDeleteAsync(2);

            Assert.That(2, Is.EqualTo(diet.Id));
            Assert.AreEqual(diet.Name, "fitnessCard");
        }

        [Test]
        public async Task ExistFitnessCardTestInMemory()
        {

            var repo = new Repository(applicationDbContext);
            fitnessCardService = new FitnessCardService(repo);

            await repo.AddRangeAsync(new List<FitnessCard>()
            {
                new FitnessCard() { Id = 2, ImageUrl = "", Name = "fitnessCard",Description = "",FitnessCardCategoryId = 1},
                new FitnessCard() { Id = 3, ImageUrl = "", Name = "",Description = "",FitnessCardCategoryId = 1},

            });
            await repo.SaveChangesAsync();

            var diet = await fitnessCardService.ExistAsync(2);

            Assert.IsTrue(diet);
        }

        [Test]
        public async Task CategoryExistFitnessCardTestInMemory()
        {

            var repo = new Repository(applicationDbContext);
            fitnessCardService = new FitnessCardService(repo);

            await repo.AddAsync(new FitnessCardCategory()
            {
                Id = 7,
                Name = ""

            });
            await repo.SaveChangesAsync();

            var diet = await fitnessCardService.CategoryExistAsync(2);

            Assert.IsTrue(diet);
        }

        [Test]
        public async Task AddFitnessCardTestInMemory()
        {

            var repo = new Repository(applicationDbContext);
            fitnessCardService = new FitnessCardService(repo);

            var model = new FitnessCardFormViewModel()
            {
                Id = 2,
                Name = "fitnessCard",
                Description = "",
                FitnessCardCategoryId = 1,
                ImageUrl = "",
                Price = 40,
                Quantity = 10,
                DurationInMonths = 1,

            };


            await fitnessCardService.AddAsync(model, "2a2dba3e-f9bf-4c83-83eb-fbd8af5f891c");

            var dbFitnessCard = await repo.GetByIdAsync<FitnessCard>(2);

            Assert.That(dbFitnessCard.Id, Is.EqualTo(2));

            Assert.That(dbFitnessCard.Name, Is.EqualTo("fitnessCard"));

        }


        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }

    }
}
