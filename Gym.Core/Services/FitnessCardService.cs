using Gym.Core.Contracts;
using Gym.Core.Models;
using Gym.Core.Models.FitnessCard;
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
    public class FitnessCardService : IFitnessCardService
    {
        private readonly IRepository repository;

        public FitnessCardService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task AddAsync(FitnessCardFormViewModel model, string userId)
        {

            FitnessCard fitnessCard = new FitnessCard()
            {

                Description = model.Description,
                Price = model.Price,
                ImageUrl = model.ImageUrl,
                FitnessCardCategoryId = model.FitnessCardCategoryId,
                CreatorId = userId,
                DurationInMonths = model.DurationInMonths,
                Name = model.Name,
                IssuesDate = DateTime.Now,

            };

            await repository.AddAsync(fitnessCard);
            await repository.SaveChangesAsync();



        }

        public async Task<IEnumerable<AllFitnessCardViewModel>> AllFitnessCardAsync()
        {
            var fitnessCard = await repository.AllAsReadOnly<FitnessCard>()
                .Select(x => new AllFitnessCardViewModel()
                {
                    Id = x.Id,
                    FitnessCardCategory = x.FitnessCardCategory.Name,
                    Description = x.Description,
                    ImageUrl = x.ImageUrl,
                    Price = x.Price,
                    Creator = x.Creator.UserName
                    
                }).ToListAsync();

            return fitnessCard;
        }

        public async Task<DetailsFitnessCardViewModel> DetailsFitnessCardAsync(int id)
        {

            var fitnessCard = await repository
                .All<FitnessCard>()
                .Where(x => x.Id == id)
                .Select(x => new DetailsFitnessCardViewModel()
                {
                    Id = x.Id,
                    Description = x.Description,
                    ImageUrl = x.ImageUrl,
                    Price = x.Price,
                    Creator = x.Creator.UserName,
                    FitnessCardCategory = x.FitnessCardCategory.Name,
                    DurationInMoths = x.DurationInMonths,
                    Name = x.Name,
                    IssuesDate = x.IssuesDate.ToString()

                }).FirstOrDefaultAsync();

            if (fitnessCard == null)
            {
                throw new ArgumentException("Invalid fitness card");
            }

            return fitnessCard;
        }

        public async Task EditAsync(int id, FitnessCardFormViewModel model)
        {
            var fitnessCard = await repository.GetByIdAsync<FitnessCard>(id);

            if (fitnessCard == null)
            {
                throw new ArgumentException("Invalid fitness card");
            }


            fitnessCard.Description = model.Description;
            fitnessCard.Price = model.Price;
            fitnessCard.ImageUrl = model.ImageUrl;
            fitnessCard.FitnessCardCategoryId = model.FitnessCardCategoryId;


            await repository.SaveChangesAsync();
        }


        public async Task<FitnessCardFormViewModel> GetFitnessCardForEditAsync(int id)
        {
            var fitnessCard = await repository.GetByIdAsync<FitnessCard>(id);

            if (fitnessCard == null)
            {
                throw new ArgumentException("Invalid fitness card");
            }
            var model = new FitnessCardFormViewModel()
            {
                Id = id,
                FitnessCardCategoryId = fitnessCard.FitnessCardCategoryId,
                Price = fitnessCard.Price,
                Description = fitnessCard.Description,
                ImageUrl = fitnessCard.ImageUrl,
                DurationInMonths = fitnessCard.DurationInMonths,
                Name = fitnessCard.Name,
                

                


            };

            //model.ProductCategories = await GetProductCategoryAsync();

            return model;
        }

        public async Task<IEnumerable<FitnessCardCategoryViewModel>> GetFitnessCardCategoryAsync()
        {
            var categories = await repository
                .AllAsReadOnly<FitnessCardCategory>()
                .Select(x => new FitnessCardCategoryViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToListAsync();

            return categories;
        }

        public async Task<DeleteFitnessCardViewModel> GetFitnessCardForDeleteAsync(int id)
        {
            var fitnessCard = await repository.GetByIdAsync<FitnessCard>(id);
            if (fitnessCard == null)
            {
                throw new ArgumentException("Invalid product");
            }

            return new DeleteFitnessCardViewModel()
            {
                Id = fitnessCard.Id,
                ImageUrl = fitnessCard.ImageUrl,
                Name = fitnessCard.Name,
                
            };
        }

        public async Task RemoveAsync(int id)
        {
            var fitnessCard = await repository.GetByIdAsync<FitnessCard>(id);
           

            if (fitnessCard == null)
            {
                throw new ArgumentException("Invalid fitness card");
            }

            repository.Delete(fitnessCard);
            await repository.SaveChangesAsync();
        }
    }
}
