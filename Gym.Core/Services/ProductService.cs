using Gym.Core.Contracts;
using Gym.Core.Enumerations;
using Gym.Core.Models;
using Gym.Infrastructure.Constants;
using Gym.Infrastructure.Data;
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
                  CreatorName = x.Creator.FirstName + " " + x.Creator.LastName,
                  CreatorEmail = x.Creator.Email,
                  Quantity = x.Quantity
                  
                  

              }).FirstAsync();
            
            return product;
        }

        public async Task EditAsync(int id,ProductFormViewModel model)
        {
            var product = await repository.GetByIdAsync<Product>(id);

            if (product != null)
            {
                product.Name = model.Name;
                product.Description = model.Description;
                product.Price = model.Price;
                product.ImageUrl = model.ImageUrl;
                product.ProductCategoryId = model.ProductCategoryId;
                product.Quantity = model.Quantity;

                await repository.SaveChangesAsync();
            }


           

        }

        public async Task<ProductFormViewModel> GetProductForEditAsync(int id)
        {

            var product = await repository.AllAsReadOnly<Product>()
                .Where(x => x.Id == id)
                .Select(x => new ProductFormViewModel()
                {
                    Id = id,
                    Name = x.Name,
                    Price = x.Price,
                    Description = x.Description,
                    ImageUrl = x.ImageUrl,
                    Quantity = x.Quantity,
                }).FirstAsync();

            return product;
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
            var product = await repository.AllAsReadOnly<Product>()
                .Where(x => x.Id == id)
                .Select(x => new DeleteProductViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl,
                }).FirstAsync();

            return product;
        }

        public async Task RemoveAsync(int id)
        {
            var product = repository.GetByIdAsync<Product>(id);


            if(product != null)
            {
                repository.Delete(product);
                await repository.SaveChangesAsync();
            }

       
            
        }

        public async Task<IEnumerable<string>> AllCategoriesNamesAsync()
        {
            return await repository.AllAsReadOnly<ProductCategory>()
                .Select(c => c.Name)
                .ToListAsync();
        }

        public async Task AddToCartAsync(int id,string userId)
        {
            var cart = await repository.All<UserProduct>()
                .FirstOrDefaultAsync(x => x.ProductId == id && x.UserId == userId);

            if (cart == null)
            {
                var entity = new UserProduct()
                {
                    ProductId = id,
                    UserId = userId,
                    Quantity = 1,
                    
                };
                await repository.AddAsync(entity);
                await repository.SaveChangesAsync();

            }
            else
            {
                
                cart.Quantity += 1;
                await repository.SaveChangesAsync();
            }

            

            
        }

        public async Task<IEnumerable<AllProductViewModel>> AllProductsInCartAsync(string userId)
        {
            var carts = await repository.All<UserProduct>()
               .Where(x => x.UserId == userId)
               .Select(x => new AllProductViewModel
               {
                   Id = x.Product.Id,
                   Name = x.Product.Name,
                   Description = x.Product.Description,
                   Quantity = x.Quantity,
                   ImageUrl = x.Product.ImageUrl,
                   Price = x.Product.Price,
                 
                 

               }).ToListAsync();

            return carts;
        }

        public async Task<UserProduct?> GetProductInCartAsync(string userId, int id)
        {
            return await repository.AllAsReadOnly<UserProduct>()
                .FirstOrDefaultAsync(x=>x.UserId == userId && x.ProductId == id);
        }

        public async Task RemoveFromCartAsync(int id,string userId)
        {
            var product = await repository.All<UserProduct>()
                .FirstAsync(x=>x.ProductId == id && x.UserId == userId);

            if (product.Quantity > 1)
            {
                product.Quantity -= 1;
                await repository.SaveChangesAsync();
            }
            else
            {
                repository.Delete(product);
                await repository.SaveChangesAsync();
            }
        
        }

        public async Task<bool> CategoryExistAsync(int id)
        {
           return await repository.AllAsReadOnly<ProductCategory>()
                 .AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await repository.AllAsReadOnly<Product>()
                .AnyAsync(x => x.Id == id);
        }
    }
}
