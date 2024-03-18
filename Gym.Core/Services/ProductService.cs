using Gym.Core.Contracts;
using Gym.Core.Enumerations;
using Gym.Core.Models;
using Gym.Infrastructure.Data.Common;
using Gym.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

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
                CreatorId = userId,
                Quantity = model.Quantity,
                

            };

            await repository.AddAsync(product);
            await repository.SaveChangesAsync();
        }

        public async Task<ProductQueryViewModel> AllProductsAsync(string? category,
            string? searchTerm,
            ProductSorting sorting = ProductSorting.Newest,
            int currentPage = 1,
            int housesPerPage = 1)
        {
            var productsToShow = repository.AllAsReadOnly<Product>();

            if(category != null)
            {
                productsToShow = productsToShow.Where(x => x.ProductCategory.Name == category);

            }

            if(searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();
                productsToShow = productsToShow.Where(x => (x.Name.ToLower().Contains(normalizedSearchTerm) ||
                                                           x.Description.ToLower().Contains(normalizedSearchTerm)));

            }

            productsToShow = sorting switch
            {
                ProductSorting.Price => productsToShow
                    .OrderBy(h => h.Price),
                _ => productsToShow
                    .OrderByDescending(h => h.Id)
            };

            var products = await productsToShow
                .Skip((currentPage - 1) * housesPerPage)
                .Take(housesPerPage)
                .Select(x=> new AllProductViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    ImageUrl = x.ImageUrl,
                    Price = x.Price,
                    Creator = x.Creator.UserName,
                    Quantity = x.Quantity,
                    
                })
                .ToListAsync();

            int totalProducts = await productsToShow.CountAsync();

            return new ProductQueryViewModel()
            {
                Products = products,
               TotalProductsCount = totalProducts
            };


       
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
                  Creator = x.Creator.UserName,
                  Quantity = x.Quantity
                  
                  

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
            product.Quantity = model.Quantity;

            await repository.SaveChangesAsync();

           

        }

        public async Task<ProductFormViewModel> GetProductForEditAsync(int id)
        {
            var product = await repository.GetByIdAsync<Product>(id);

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
                Quantity = product.Quantity,


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

        public async Task<DeleteProductViewModel> GetProductForDeleteAsync(int id)
        {
            var product = await repository.GetByIdAsync<Product>(id);
            if (product == null)
            {
                throw new ArgumentException("Invalid product");
            }

            return new DeleteProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                ImageUrl = product.ImageUrl,
            };
        }

        public async Task RemoveAsync(int id)
        {
            var product = repository.All<Product>().FirstOrDefault(x=>x.Id == id);

            if(product == null)
            {
                throw new ArgumentException("Invalid product");
            }

            repository.Delete(product);
            await repository.SaveChangesAsync();
            
        }

        public async Task<IEnumerable<string>> AllCategoriesNamesAsync()
        {
            return await repository.AllAsReadOnly<ProductCategory>()
                .Select(c => c.Name)
                .ToListAsync();
        }
    }
}
