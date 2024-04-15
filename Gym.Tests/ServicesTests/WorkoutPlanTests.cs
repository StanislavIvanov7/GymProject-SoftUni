using Gym.Core.Contracts;
using Gym.Infrastructure.Data.Common;
using Gym.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Core.Services;
using Gym.Infrastructure.Data.Models;
using Gym.Core.Models.Diet;
using Gym.Core.Models.WorkoutPlan;
using Gym.Core.Models.FitnessCard;

namespace Gym.Tests.ServicesTests
{
    [TestFixture]
    public class WorkoutPlanTests
    {
        private IRepository repo;
        private IWorkoutPlanService workoutPlanService;
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
        public async Task AllWorkoutPlanTestInMemory()
        {

            var repo = new Repository(applicationDbContext);
            workoutPlanService = new WorkoutPlanService(repo);

            await repo.AddRangeAsync(new List<WorkoutPlan>()
            {
                new WorkoutPlan() { Id = 2, ImageUrl = "", Name = ""},
                new WorkoutPlan() { Id = 3, ImageUrl = "", Name = ""},

            });

            await repo.SaveChangesAsync();

            var workoutPlanCollection = await workoutPlanService.AllWorkoutPlansAsync();

            Assert.That(3, Is.EqualTo(workoutPlanCollection.Count()));
            Assert.That(workoutPlanCollection.Any(h => h.Id == 4), Is.False);
        }

        [Test]
        public async Task TestWorkoutPlanEdit()
        {

            var repo = new Repository(applicationDbContext);
            workoutPlanService = new WorkoutPlanService(repo);

            await repo.AddAsync(new WorkoutPlan()
            {
                Id = 2,
                WorkoutPlanCategoryId = 1,
                ImageUrl = "",
                Name = "",
                Description = ""
            });

            await repo.SaveChangesAsync();

            await workoutPlanService.EditAsync(2, new WorkoutPlanFormViewModel()
            {
                Id = 2,
                WorkoutPlanCategoryId = 1,
                ImageUrl = "",
                Name = "",
                Description = "This workout plan is edited",
            });

            var dbWorkoutPlan = await repo.GetByIdAsync<WorkoutPlan>(2);

            Assert.That(dbWorkoutPlan.Description, Is.EqualTo("This workout plan is edited"));
        }

        [Test]
        public async Task GetDietForEditTestInMemory()
        {

            var repo = new Repository(applicationDbContext);
            workoutPlanService = new WorkoutPlanService(repo);

            await repo.AddRangeAsync(new List<WorkoutPlan>()
            {
                new WorkoutPlan() { Id = 2, ImageUrl = "", Name = "workoutPlan",Description = "",WorkoutPlanCategoryId = 1},
                new WorkoutPlan() { Id = 3, ImageUrl = "", Name = "",Description = "",WorkoutPlanCategoryId = 1},

            });

            await repo.SaveChangesAsync();

            var diet = await workoutPlanService.GetWorkoutPlanForEditAsync(2);

            Assert.That(2, Is.EqualTo(diet.Id));
            Assert.AreEqual(diet.Name, "workoutPlan");
        }

        [Test]
        public async Task GetWorkoutPlanCategoryTestInMemory()
        {

            var repo = new Repository(applicationDbContext);
            workoutPlanService = new WorkoutPlanService(repo);

            await repo.AddAsync(new WorkoutPlanCategory()
            {
                Id = 5,
                Name = ""

            });

            await repo.SaveChangesAsync();

            var WorkoutPlanCategoriesCollection = await workoutPlanService.GetWorkoutPlanCategoriesAsync();

            Assert.That(5, Is.EqualTo(WorkoutPlanCategoriesCollection.Count()));
            Assert.That(WorkoutPlanCategoriesCollection.Any(h => h.Id == 6), Is.False);
        }

        [Test]
        public async Task GetWorkoutPlanForDeleteTestInMemory()
        {

            var repo = new Repository(applicationDbContext);
            workoutPlanService = new WorkoutPlanService(repo);

            await repo.AddRangeAsync(new List<WorkoutPlan>()
            {
                new WorkoutPlan() { Id = 2, ImageUrl = "", Name = "WorkoutPlan",Description = "",WorkoutPlanCategoryId = 1},
                new WorkoutPlan() { Id = 3, ImageUrl = "", Name = "",Description = "",WorkoutPlanCategoryId = 1},

            });

            await repo.SaveChangesAsync();

            var diet = await workoutPlanService.GetWorkoutPlanForDeleteAsync(2);

            Assert.That(2, Is.EqualTo(diet.Id));
            Assert.AreEqual(diet.Name, "WorkoutPlan");
        }

        [Test]
        public async Task ExistWorkoutPlanTestInMemory()
        {

            var repo = new Repository(applicationDbContext);
            workoutPlanService = new WorkoutPlanService(repo);

            await repo.AddRangeAsync(new List<WorkoutPlan>()
            {
                new WorkoutPlan() { Id = 2, ImageUrl = "", Name = "diet",Description = "",WorkoutPlanCategoryId = 1},
                new WorkoutPlan() { Id = 3, ImageUrl = "", Name = "",Description = "",WorkoutPlanCategoryId = 1},

            });

            await repo.SaveChangesAsync();

            var diet = await workoutPlanService.ExistAsync(2);

            Assert.IsTrue(diet);
        }

        [Test]
        public async Task CategoryExistWorkoutPlanTestInMemory()
        {

            var repo = new Repository(applicationDbContext);
            workoutPlanService = new WorkoutPlanService(repo);

            await repo.AddAsync(new WorkoutPlanCategory()
            {
                Id = 5,
                Name = ""

            });

            await repo.SaveChangesAsync();

            var diet = await workoutPlanService.CategoryExistAsync(2);

            Assert.IsTrue(diet);
        }
        [Test]
        public async Task AddWorkoutPlanTestInMemory()
        {

            var repo = new Repository(applicationDbContext);
            workoutPlanService = new WorkoutPlanService(repo);

            var model = new WorkoutPlanFormViewModel()
            {
                Id = 2,
                Name = "workoutPlan",
                Description = "",
                WorkoutPlanCategoryId = 1,
                ImageUrl = "",
                
            };
            


            await workoutPlanService.AddAsync("2a2dba3e-f9bf-4c83-83eb-fbd8af5f891c",model);

            var dbWorkoutPlan = await repo.GetByIdAsync<WorkoutPlan>(2);

            Assert.That(dbWorkoutPlan.Id, Is.EqualTo(2));

            Assert.That(dbWorkoutPlan.Name, Is.EqualTo("workoutPlan"));

        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
