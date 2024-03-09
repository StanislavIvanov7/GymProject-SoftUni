using Gym.Core.Models;
using Gym.Core.Models.Diet;
using Gym.Core.Models.FitnessCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Core.Contracts
{
    public interface IDietService
    {
        Task<IEnumerable<AllDietViewModel>> AllDietsAsync();

        Task<DetailsDietViewModel> DetailsDietAsync(int id);

        Task<IEnumerable<DietCategoryViewModel>> GetDietCategoriesAsync();
    }
}
