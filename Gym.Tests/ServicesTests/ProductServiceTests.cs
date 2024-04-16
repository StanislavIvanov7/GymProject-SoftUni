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
using System.Diagnostics;
using System.Xml.Linq;
using Gym.Core.Models;
using Gym.Core.Models.Diet;
using Gym.Core.Models.FitnessCard;
using Gym.Core.Models.WorkoutPlan;

namespace Gym.Tests.ServicesTests
{
    [TestFixture]
    public class ProductServiceTests
    {
        private IRepository repo;
        private IProductService productService;
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

        //[Test]
        //public async Task DetailsProductTestInMemory()
        //{

        //    var repo = new Repository(applicationDbContext);
        //    productService = new ProductService(repo);

        //    var product = new Product()
        //    {
        //        Id = 2,
        //        Name = "product",
        //        ProductCategoryId = 2,
        //        Description = "The description of product",
        //        CreatorId = "2a2dba3e-f9bf-4c83-83eb-fbd8af5f891c",
        //        Quantity = 50,
        //        Price = 24.95m,
        //        ImageUrl = "https://www.ciela.com/media/catalog/product/cache/32bb0748c82325b02c55df3c2a9a9856/a/n/ana-karenina-lev-tolstoi-hermes-9789542619529.jpg",

        //    };

        //    await repo.AddAsync(product);
      

        //    var currentProductDetails = new DetailsProductViewModel()
        //    {
        //        Id = product.Id,
        //        Name = product.Name,
        //        Price = product.Price,
        //        ProductCategory = product.ProductCategory.Name,
        //        Description = product.Description,
        //        CreatorEmail = product.Creator.Email,
        //        CreatorName = product.Creator.FirstName + " " + product.Creator.LastName,
        //        Quantity = product.Quantity,
        //        ImageUrl = product.ImageUrl,

        //    };

        //    // Act
        //    var result = await productService.DetailsProductAsync(product.Id);

        //    // Assert
        //    Assert.AreEqual(product.Id, result.Id);
        //    Assert.AreEqual(product.Name, result.Name);
        //    Assert.AreEqual(product.Price, result.Price);
        //    Assert.AreEqual(product.ProductCategory.Name, result.ProductCategory);
        //    Assert.AreEqual(product.Description, result.Description);
        //    Assert.AreEqual(product.Creator.Email, result.CreatorEmail);
        //    Assert.AreEqual(product.Creator.FirstName + " " + product.Creator.LastName, result.CreatorName);
        //    Assert.AreEqual(product.Quantity, result.Quantity);
        //    Assert.AreEqual(product.ImageUrl, result.ImageUrl);



        //}

        [Test]
        public async Task TestProductEdit()
        {

            var repo = new Repository(applicationDbContext);
            productService = new ProductService(repo);
        
            await repo.AddAsync(new Product()
            {
                Id = 2,
                Price = 1,
                ImageUrl = "",
                Name = "",
                Description = "",
                Quantity = 1,
                ProductCategoryId = 1,
            });

            await repo.SaveChangesAsync();

            await productService.EditAsync(2, new ProductFormViewModel()
            {
                Id = 2,
                Price = 1,
                ImageUrl = "",
                Name = "",
                Description = "This product is edited",
                Quantity = 1,
                ProductCategoryId = 1,
            });

            var dbProduct = await repo.GetByIdAsync<Product>(2);

            Assert.That(dbProduct.Description, Is.EqualTo("This product is edited"));
        }

        [Test]
        public async Task GetProductForEditTestInMemory()
        {

            var repo = new Repository(applicationDbContext);
            productService = new ProductService(repo);
          
            await repo.AddRangeAsync(new List<Product>()
            {
                new Product() { Id = 2, ImageUrl = "", Name = "product",Description = "",Quantity = 50,Price = 3},
                new Product() { Id = 3, ImageUrl = "", Name = "",Description = "",Quantity = 50,Price = 3},

            });

            await repo.SaveChangesAsync();

            var product = await productService.GetProductForEditAsync(2);

            Assert.That(2, Is.EqualTo(product.Id));
            Assert.AreEqual(product.Name, "product");
        }

        [Test]
        public async Task GetProductCategoryTestInMemory()
        {

            var repo = new Repository(applicationDbContext);
            productService = new ProductService(repo);

            await repo.AddAsync(new ProductCategory()
            {
                Id = 4,
                Name = ""

            });

            await repo.SaveChangesAsync();

            var productCollection = await productService.GetProductCategoryAsync();

            Assert.That(4, Is.EqualTo(productCollection.Count()));
            Assert.That(productCollection.Any(h => h.Id == 5), Is.False);
        }

        [Test]
        public async Task GetProductForDeleteTestInMemory()
        {

            var repo = new Repository(applicationDbContext);
            productService = new ProductService(repo);

            await repo.AddRangeAsync(new List<Product>()
            {
                new Product() { Id = 2, ImageUrl = "", Name = "product"},
                new Product() { Id = 3, ImageUrl = "", Name = ""},

            });

            await repo.SaveChangesAsync();

            var diet = await productService.GetProductForDeleteAsync(2);

            Assert.That(2, Is.EqualTo(diet.Id));
            Assert.AreEqual(diet.Name, "product");
        }
        [Test]
        public async Task AllProductCategoryTestInMemory()
        {

            var repo = new Repository(applicationDbContext);
            productService = new ProductService(repo);

            await repo.AddAsync(new ProductCategory()
            {
               Id = 4,
               Name = "Test",

            });

            await repo.SaveChangesAsync();

            var productCategories = await productService.AllCategoriesNamesAsync();

            Assert.That(4, Is.EqualTo(productCategories.Count()));
            Assert.That(productCategories.Any(x=>x.Id == 5), Is.False);
        }

        [Test]
        public async Task AddProductTestInMemory()
        {

            var repo = new Repository(applicationDbContext);
            productService = new ProductService(repo);

            var model = new ProductFormViewModel()
            {
                Id = 2,
                Name = "product",
                Description = "",
                ProductCategoryId = 1,
                ImageUrl = "",
                Quantity = 10,

            };
        


            await productService.AddAsync(model, "2a2dba3e-f9bf-4c83-83eb-fbd8af5f891c");

            var dbProduct = await repo.GetByIdAsync<Product>(2);

            Assert.That(dbProduct.Id, Is.EqualTo(2));

            Assert.That(dbProduct.Name, Is.EqualTo("product"));

        }

        [Test]
        public async Task RemoveProductTestInMemory()
        {

            var repo = new Repository(applicationDbContext);
            productService = new ProductService(repo);

            var model = new Product()
            {
                Id = 2,
                Name = "product",
                Description = "",
                ProductCategoryId = 1,
                ImageUrl = "",
                Quantity = 10,

            };

            await repo.AddAsync(model);
            await repo.SaveChangesAsync();




            await productService.RemoveAsync(2);

            var dbProduct = await repo.GetByIdAsync<Product>(2);

            Assert.That(dbProduct, Is.EqualTo(null));

        }
        [Test]
        public async Task AddProductToCartTestInMemory()
        {

            var repo = new Repository(applicationDbContext);
            productService = new ProductService(repo);

            await productService.AddToCartAsync(1, "2a2dba3e-f9bf-4c83-83eb-fbd8af5f891c");

            var dbFitnessCard = await repo.All<UserProduct>()
                .FirstOrDefaultAsync(x => x.ProductId == 1 && x.UserId == "2a2dba3e-f9bf-4c83-83eb-fbd8af5f891c");

            Assert.That(dbFitnessCard.ProductId, Is.EqualTo(1));

            Assert.That(dbFitnessCard.Quantity, Is.EqualTo(1));

        }

        [Test]
        public async Task RemoveFitnessCardFromCartTestInMemory()
        {

            var repo = new Repository(applicationDbContext);
            productService = new ProductService(repo);
            await repo.AddAsync(new UserProduct()
            {
                UserId = "2a2dba3e-f9bf-4c83-83eb-fbd8af5f891c",
                Quantity = 2,
                ProductId = 1
            });
            await repo.SaveChangesAsync();
            await productService.RemoveFromCartAsync(1, "2a2dba3e-f9bf-4c83-83eb-fbd8af5f891c");

            var dbFitnessCard = await repo.All<UserProduct>()
                .FirstOrDefaultAsync(x => x.ProductId == 1 && x.UserId == "2a2dba3e-f9bf-4c83-83eb-fbd8af5f891c");

            Assert.That(dbFitnessCard.Quantity, Is.EqualTo(1));



        }

        [Test]
        public async Task RemoveProductFromUserProductTableTestInMemory()
        {

            var repo = new Repository(applicationDbContext);
            productService = new ProductService(repo);

            var model = new UserProduct()
            {
                UserId = "2a2dba3e - f9bf - 4c83 - 83eb - fbd8af5f891c",
                ProductId = 1,
                Quantity = 10

            };

            await repo.AddAsync(model);

            await repo.SaveChangesAsync();

            await productService.RemoveProductsFromUserProductsAsync(1);

            var dbFitnessCard = await repo.All<UserProduct>()
                .FirstOrDefaultAsync(x => x.ProductId == 1);



            Assert.That(dbFitnessCard, Is.EqualTo(null));

        }

        [Test]
        public async Task RemoveProductFromBuyerProductTableTestInMemory()
        {

            var repo = new Repository(applicationDbContext);
            productService = new ProductService(repo);

            var model = new BuyerProduct()
            {
                BuyerId = "2a2dba3e - f9bf - 4c83 - 83eb - fbd8af5f891c",
                ProductId = 1,
                Quantity = 10

            };

            await repo.AddAsync(model);

            await repo.SaveChangesAsync();

            await productService.RemoveProductsFromBuyerProductsAsync(1);

            var dbFitnessCard = await repo.All<BuyerProduct>()
                .FirstOrDefaultAsync(x => x.ProductId == 1);



            Assert.That(dbFitnessCard, Is.EqualTo(null));

        }

        [Test]
        public async Task AllPurchasedProductsTestInMemory()
        {

            var repo = new Repository(applicationDbContext);
            productService = new ProductService(repo);

            var model = new BuyerProduct()
            {
                BuyerId = "2a2dba3e-f9bf-4c83-83eb-fbd8af5f891c",
                ProductId = 1,
                Quantity = 10

            };

            await repo.AddAsync(model);


            await repo.SaveChangesAsync();

            var FitnessCardCollection = await productService.AllPurchasedProductsAsync("2a2dba3e-f9bf-4c83-83eb-fbd8af5f891c");

            Assert.That(1, Is.EqualTo(FitnessCardCollection.Count()));
            Assert.That(FitnessCardCollection.Any(h => h.Id == 2), Is.False);
        }

        [Test]
        public async Task IsInUserCartTestInMemory()
        {

            var repo = new Repository(applicationDbContext);
            productService = new ProductService(repo);

            var model = new UserProduct()
            {
                UserId = "2a2dba3e-f9bf-4c83-83eb-fbd8af5f891c",
                ProductId = 1,
                Quantity = 10

            };

            await repo.AddAsync(model);


            await repo.SaveChangesAsync();

            var result = await productService.IsInUserCart(1, "2a2dba3e-f9bf-4c83-83eb-fbd8af5f891c");

            Assert.IsTrue(result);
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }

    }
}
