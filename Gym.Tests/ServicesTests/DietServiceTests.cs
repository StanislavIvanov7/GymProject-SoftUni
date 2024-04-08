using Gym.Core.Contracts;
using Gym.Core.Services;
using Gym.Infrastructure.Data;
using Gym.Infrastructure.Data.Common;
using Gym.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
