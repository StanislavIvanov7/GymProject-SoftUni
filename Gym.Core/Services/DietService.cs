using Gym.Core.Contracts;
using Gym.Core.Models.Diet;
using Gym.Infrastructure.Data.Common;
using Gym.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Gym.Core.Services
{
    public class DietService : IDietService
    {
        private readonly IRepository repository;

        public DietService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task AddAsync(DietFormViewModel model, string userId)
        {
            Diet diet = new Diet()
            {
                Title = model.Title,
                Description = model.Description,
                DietCategoryId = model.DietCategoryId,
                ImageUrl = model.ImageUrl,
                CreatorId = userId,

            };

            await repository.AddAsync(diet);
            await repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllDietViewModel>> AllDietsAsync()
        {
            var diets = await repository.AllAsReadOnly<Diet>()
                 .Select(x => new AllDietViewModel()
                 {
                     Id = x.Id,
                     Title = x.Title,
                     ImageUrl = x.ImageUrl,
                 }).ToListAsync();

            return diets;
        }

        public async Task<DetailsDietViewModel> DetailsDietAsync(int id)
        {
            var diet = await repository.AllAsReadOnly<Diet>()
                .Where(x => x.Id == id)
                .Select(x => new DetailsDietViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    ImageUrl = x.ImageUrl,
                    Description = x.Description,
                    CreatorName = x.Creator.FirstName + " " + x.Creator.LastName,
                    CreatorEmail = x.Creator.Email,
                    DietCategory = x.DietCategory.Name
                }).FirstAsync();


            return diet;
        }

        public async Task EditAsync(int id, DietFormViewModel model)
        {
            var diet = await repository.GetByIdAsync<Diet>(id);

            if (diet != null)
            {
                diet.Description = model.Description;
                diet.Title = model.Title;
                diet.ImageUrl = model.ImageUrl;
                diet.DietCategoryId = model.DietCategoryId;

                await repository.SaveChangesAsync();
            }

        }

        public async Task<DietFormViewModel> GetDietForEditAsync(int id)
        {
            var diet = await repository.AllAsReadOnly<Diet>()
                 .Where(x => x.Id == id)
                 .Select(x => new DietFormViewModel()
                 {
                     Id = id,
                     Title = x.Title,
                     Description = x.Description,
                     DietCategoryId = x.DietCategoryId,
                     ImageUrl = x.ImageUrl,
                 })
                 .FirstAsync();

            return diet;

        }

        public async Task<IEnumerable<DietCategoryViewModel>> GetDietCategoriesAsync()
        {
            var categories = await repository.AllAsReadOnly<DietCategory>()
                .Select(x => new DietCategoryViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToListAsync();

            return categories;
        }

        public async Task<DeleteDietViewModel> GetDietForDeleteAsync(int id)
        {

            var diets = await repository.AllAsReadOnly<Diet>()
                .Where(x => x.Id == id)
                .Select(x => new DeleteDietViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    ImageUrl = x.ImageUrl

                })
                .FirstAsync();

            return diets;
        }

        public async Task RemoveAsync(int id)
        {
            var diet = await repository.GetByIdAsync<Diet>(id);

            if (diet != null)
            {
                repository.Delete<Diet>(diet);
                await repository.SaveChangesAsync();
            }

          
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await repository.AllAsReadOnly<Diet>()
                .AnyAsync(x => x.Id == id);
        }

        public async Task<bool> CategoryExistAsync(int id)
        {
            return await repository.AllAsReadOnly<DietCategory>()
                .AnyAsync(x => x.Id == id);
        }

        public async Task<bool> UserHasFitnessCardAsync(string userId)
        {
           var uf = await repository.AllAsReadOnly<BuyerFitnessCard>()
                 .FirstOrDefaultAsync(x => x.BuyerId == userId);

            if(uf == null)
            {
                return false;
            }

            return true;
        }
    }
}
