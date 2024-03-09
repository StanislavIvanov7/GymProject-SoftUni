using Gym.Core.Contracts;
using Gym.Core.Services;
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

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await dietService.AllDietsAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await dietService.DetailsDietAsync(id);

            return View(model);
        }
    }
}
