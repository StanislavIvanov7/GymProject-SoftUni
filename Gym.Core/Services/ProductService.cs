using Gym.Core.Contracts;
using Gym.Core.Models;
using Gym.Infrastructure.Data.Common;
using Gym.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace Gym.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository repository;

        public ProductService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task AddAsync(ProductFormViewModel model,string userId)
        {

            Product product = new Product()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                ImageUrl = model.ImageUrl,
                ProductCategoryId = model.ProductCategoryId,
                CreatorId = userId

            };

            await repository.AddAsync(product);
            await repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllProductViewModel>> AllProductsAsync()
        {
            var products = await repository.AllAsReadOnly<Product>()
                .Select(x => new AllProductViewModel()
                {
                    Id = x.Id,
                    ImageUrl = x.ImageUrl,
                    Description = x.Description,
                    Name = x.Name,
                    Price = x.Price,
                }).ToListAsync();

            return products;
        }

        public async Task<DetailsProductViewModel> DetailsProductAsync(int id)
        {
            var product = await repository.AllAsReadOnly<Product>()
              .Where(x => x.Id == id)
              .Select(x => new DetailsProductViewModel()
              {
                  Id = x.Id,
                  Name = x.Name,
                  Price = x.Price,
                  ImageUrl = x.ImageUrl,
                  Description = x.Description,
                  ProductCategory = x.ProductCategory.Name,
                  Creator = x.Creator.UserName

              }).FirstOrDefaultAsync();

            if(product == null)
            {
                throw new ArgumentException("Invalid product");
            }
            
            return product;
        }

        public async Task EditAsync(int id,ProductFormViewModel model)
        {
            var product = await repository .All<Product>().FirstOrDefaultAsync (x=>x.Id == model.Id);

            if (product == null)
            {
                throw new ArgumentException("Invalid product");
            }

            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.ImageUrl = model.ImageUrl;
            product .ProductCategoryId = model.ProductCategoryId;

            await repository.SaveChangesAsync();

           

        }

        public async Task<ProductFormViewModel> GetProductByIdAsync(int id)
        {
            var product = await repository.All<Product>().FirstOrDefaultAsync(x=>x.Id == id);

            if (product == null)
            {
                throw new ArgumentException("Invalid product");
            }
            var model = new ProductFormViewModel()
            {
                Id = id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                ImageUrl = product.ImageUrl,


            };

            //model.ProductCategories = await GetProductCategoryAsync();

            return model;
        }

        public async Task<IEnumerable<AllProductCategoryViewModel>> GetProductCategoryAsync()
        {
            return await repository.AllAsReadOnly<ProductCategory>()
                 .Select(x => new AllProductCategoryViewModel
                 {
                     Id = x.Id,
                     Name = x.Name,
                 }).ToListAsync();
        }

    }
}
