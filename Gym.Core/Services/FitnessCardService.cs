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

        public async Task<IEnumerable<AllFitnessCardViewModel>> AllFitnessCardAsync()
        {
            var fitnessCard = await repository.AllAsReadOnly<FitnessCard>()
                .Select(x => new AllFitnessCardViewModel()
                {
                    Id = x.Id,
                    FitnessCardCategory = x.FitnessCardCategory.Name,
                    Description = x.Description ,
                    ImageUrl = x.ImageUrl ,
                    Price = x.Price ,
                    Creator = x.Creator.UserName 
                }).ToListAsync();

            return fitnessCard;
        }
    }
}
