using Gym.Core.Models.FitnessCard;
using Microsoft.AspNetCore.Mvc;

namespace Gym.Controllers
{
    public class FitnessCardController : Controller
    {
        private readonly IFitnessCardService fitnessCardService;

        public FitnessCardController(IFitnessCardService _fitnessCardService)
        {
                fitnessCardService = _fitnessCardService;
        }

        public async Task<IActionResult> All()
        {
            var model = await fitnessCardService.AllFitnessCardAsync();

            return View(model);
        }
    }
}
