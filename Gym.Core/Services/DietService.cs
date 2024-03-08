﻿using Gym.Core.Contracts;
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
    }
}
