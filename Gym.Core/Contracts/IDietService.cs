using Gym.Core.Models;
using Gym.Core.Models.Diet;
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
    }
}
