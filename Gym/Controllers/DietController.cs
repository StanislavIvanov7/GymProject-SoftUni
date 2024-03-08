using Gym.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Gym.Controllers
{
    public class DietController : Controller
    {
        private readonly IDietService dietService;

        public DietController(IDietService _dietService)
        {
            dietService = _dietService;

        }

        public async Task<IActionResult> All()
        {
            var model = await dietService.AllDietsAsync();

            return View(model);
        }
    }
}
