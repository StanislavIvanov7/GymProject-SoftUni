using Gym.Core.Contracts;
using Gym.Core.Models.Diet;
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
    public class DietService : IDietService
    {
        private readonly IRepository repository;

        public DietService(IRepository _repository)
        {
                repository = _repository;
        }
        public async Task<IEnumerable<AllDietViewModel>> AllDietsAsync()
        {
           var diets = await repository.AllAsReadOnly<Diet>()
                .Select(x=>  new AllDietViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    ImageUrl = x.ImageUrl,
                }).ToListAsync();

            return diets;
        }

        public async Task<DetailsDietViewModel> DetailsDietAsync(int id)
        {
            var diet = await repository.All<Diet>()
                .Where(x => x.Id == id)
                .Select(x => new DetailsDietViewModel()
                {
                    Title = x.Title,
                    ImageUrl = x.ImageUrl,
                    Description = x.Description,
                    Creator = x.Creator.UserName,
                    DietCategory = x.DietCategory.Name
                }).FirstOrDefaultAsync();
                
            if(diet == null)
            {
                throw new ArgumentException("Invalid diet");
            }

            return diet;
        }

        public async Task<IEnumerable<DietCategoryViewModel>> GetDietCategoriesAsync()
        {
            var categories = await repository.All<DietCategory>()
                .Select(x => new DietCategoryViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToListAsync();

            return categories;
        }
    }
}
