using Gym.Core.Contracts;
using Gym.Core.Models.Diet;
using Gym.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Gym.Areas.Admin.Controllers
{
    public class DietController : AdminBaseController
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
        public async Task<IActionResult> Add()
        {

            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var model = new DietFormViewModel();

            model.DietCategories = await dietService.GetDietCategoriesAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(DietFormViewModel model)
        {
            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            if (await dietService.CategoryExistAsync(model.DietCategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.DietCategoryId), "Category does not exist");
            }

            if (!ModelState.IsValid)
            {
                model.DietCategories = await dietService.GetDietCategoriesAsync();
                return View(model);
            }
            string userId = GetUserId();

            await dietService.AddAsync(model, userId);

            return RedirectToAction(nameof(All));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            if (await dietService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var model = await dietService.GetDietForEditAsync(id);

            model.DietCategories = await dietService.GetDietCategoriesAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DietFormViewModel model, int id)
        {
            if (await dietService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            if (await dietService.CategoryExistAsync(model.DietCategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.DietCategoryId), "Category does not exist");
            }

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
            if (await dietService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var model = await dietService.GetDietForDeleteAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            if (await dietService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }

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
