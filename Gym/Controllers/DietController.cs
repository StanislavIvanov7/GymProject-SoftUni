using Gym.Core.Contracts;
using Gym.Core.Models.Diet;
using Gym.Core.Models.FitnessCard;
using Gym.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new DietFormViewModel();

            model.DietCategories = await dietService.GetDietCategoriesAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(DietFormViewModel model)
        {
            if(!ModelState.IsValid)
            {
                model.DietCategories = await dietService.GetDietCategoriesAsync();
                return View(model);
            }
            string userId = GetUserId();

            await dietService.AddAsync(model,userId);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await dietService.GetDietForEditAsync(id);

            model.DietCategories = await dietService.GetDietCategoriesAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DietFormViewModel model,int id)
        {

            if (!ModelState.IsValid)
            {
                model.DietCategories = await dietService.GetDietCategoriesAsync();
                return View(model);
            }

            await dietService.EditAsync(id, model);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await dietService.GetDietForDeleteAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await dietService.RemoveAsync(id);

            return RedirectToAction(nameof(All));

        }
        private string GetUserId()
        {
            var userId = ClaimsPrincipalExtensions.Id(this.User);
            return userId;
        }
    }
}
