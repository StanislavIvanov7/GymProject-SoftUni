using Gym.Core.Contracts;
using Gym.Core.Models;
using Gym.Infrastructure.Data.Common;
using Gym.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository repository;

        public ProductService(IRepository _repository)
        {
            repository = _repository;
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
    }
}
