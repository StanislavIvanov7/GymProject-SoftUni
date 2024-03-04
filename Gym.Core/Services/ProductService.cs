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

        public async Task<ProductFormViewModel> GetByIdAsync(int id)
        {
            var product = await repository.All<Product>().FirstOrDefaultAsync(x=>x.Id == id);

            if (product == null)
            {
                throw new ArgumentException("Invalid product");
            }
            var model =  new ProductFormViewModel()
            {
                Id = id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                ImageUrl= product.ImageUrl,
               

            };

            model.ProductCategories = await GetProductCategoryAsync();

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
