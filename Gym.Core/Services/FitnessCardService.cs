using Gym.Core.Models;
using Gym.Core.Models.FitnessCard;
using Gym.Infrastructure.Data.Common;
using Gym.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

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
                Quantity = model.Quantity

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
                    Name = x.Name,
                    Description = x.Description,
                    ImageUrl = x.ImageUrl,
                    Price = x.Price,
                    Quantity = x.Quantity,

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
                    IssuesDate = x.IssuesDate.ToString(),
                    Quantity = x.Quantity,

                }).FirstAsync();

            return fitnessCard;
        }

        public async Task EditAsync(int id, FitnessCardFormViewModel model)
        {
            var fitnessCard = await repository.GetByIdAsync<FitnessCard>(id);

            if (fitnessCard != null)
            {
                fitnessCard.Description = model.Description;
                fitnessCard.Price = model.Price;
                fitnessCard.ImageUrl = model.ImageUrl;
                fitnessCard.FitnessCardCategoryId = model.FitnessCardCategoryId;
                fitnessCard.Quantity = model.Quantity;

                await repository.SaveChangesAsync();
            }

        }


        public async Task<FitnessCardFormViewModel> GetFitnessCardForEditAsync(int id)
        {

            var fitnessCard = await repository.AllAsReadOnly<FitnessCard>()
                .Where(x => x.Id == id)
                .Select(x => new FitnessCardFormViewModel()
                {
                    Id = id,
                    FitnessCardCategoryId = x.FitnessCardCategoryId,
                    Price = x.Price,
                    Description = x.Description,
                    ImageUrl = x.ImageUrl,
                    DurationInMonths = x.DurationInMonths,
                    Name = x.Name,
                    Quantity = x.Quantity,
                })
                .FirstAsync();

            return fitnessCard;
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
            //var fitnessCard = await repository.GetByIdAsync<FitnessCard>(id);
            //if (fitnessCard == null)
            //{
            //    throw new ArgumentException("Invalid product");
            //}

            //return new DeleteFitnessCardViewModel()
            //{
            //    Id = fitnessCard.Id,
            //    ImageUrl = fitnessCard.ImageUrl,
            //    Name = fitnessCard.Name,

            //};

            var fitnessCard = await repository.AllAsReadOnly<FitnessCard>()
                .Where(x => x.Id == id)
                .Select(x => new DeleteFitnessCardViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl,

                }).FirstAsync();

            return fitnessCard;


        }

        public async Task RemoveAsync(int id)
        {
            var fitnessCard = await repository.GetByIdAsync<FitnessCard>(id);


            if (fitnessCard != null)
            {
                repository.Delete(fitnessCard);
                await repository.SaveChangesAsync();
            }

        }

        public async Task<IEnumerable<AllFitnessCardViewModel>> AllFitnessCardInCartAsync(string userId)
        {
            var carts = await repository.All<UserFitnessCard>()
               .Where(x => x.UserId == userId)
               .Select(x => new AllFitnessCardViewModel
               {
                   Id = x.FitnessCard.Id,
                   Name = x.FitnessCard.Name,
                   Description = x.FitnessCard.Description,
                   Quantity = x.Quantity,
                   ImageUrl = x.FitnessCard.ImageUrl,
                   Price = x.FitnessCard.Price,



               }).ToListAsync();

            return carts;
        }

        public async Task AddToCartAsync(int id, string userId)
        {
            var cart = await repository.All<UserFitnessCard>()
                .FirstOrDefaultAsync(x => x.FitnessCardId == id && x.UserId == userId);

            if (cart == null)
            {
                var entity = new UserFitnessCard()
                {
                    FitnessCardId = id,
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

        public async Task<UserFitnessCard?> GetFitnessCardInCartAsync(string userId, int id)
        {
            return await repository.AllAsReadOnly<UserFitnessCard>()
                .FirstOrDefaultAsync(x => x.UserId == userId && x.FitnessCardId == id);
        }

        public async Task RemoveFromCartAsync(int id, string userId)
        {
            var fitnessCard = await repository.All<UserFitnessCard>().FirstAsync(x => x.FitnessCardId == id && x.UserId == userId);
            if (fitnessCard.Quantity > 1)
            {
                fitnessCard.Quantity -= 1;
                await repository.SaveChangesAsync();
            }
            else
            {
                repository.Delete(fitnessCard);
                await repository.SaveChangesAsync();
            }
        }

        public async Task<bool> CategoryExistAsync(int id)
        {

            return await repository.AllAsReadOnly<FitnessCardCategory>()
                .AnyAsync(x => x.Id == id);

        }

        public async Task<bool> ExistAsync(int id)
        {
            return await repository.AllAsReadOnly<FitnessCard>()
                .AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExistInCartAsync(int id)
        {
           return await repository.AllAsReadOnly<UserFitnessCard>()
                .AnyAsync(x => x.FitnessCardId == id);
        }
    }
}
