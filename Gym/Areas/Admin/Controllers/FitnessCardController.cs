using Gym.Core.Models.FitnessCard;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Gym.Areas.Admin.Controllers
{
    public class FitnessCardController : AdminBaseController
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

        [HttpGet]
        public async Task<IActionResult> Add()
        {

            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var model = new FitnessCardFormViewModel();

            model.FitnessCardCategories = await fitnessCardService.GetFitnessCardCategoryAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(FitnessCardFormViewModel model)
        {

            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            if (await fitnessCardService.CategoryExistAsync(model.FitnessCardCategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.FitnessCardCategoryId), "Category does not exist");

            }

            if (!ModelState.IsValid)
            {
                model.FitnessCardCategories = await fitnessCardService.GetFitnessCardCategoryAsync();
                return View(model);
            }

            string userId = GetUserId();

            await fitnessCardService.AddAsync(model, userId);

            return RedirectToAction(nameof(All));

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            if (await fitnessCardService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var model = await fitnessCardService.GetFitnessCardForEditAsync(id);

            model.FitnessCardCategories = await fitnessCardService.GetFitnessCardCategoryAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, FitnessCardFormViewModel model)
        {

            if (await fitnessCardService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            if (await fitnessCardService.CategoryExistAsync(model.FitnessCardCategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.FitnessCardCategoryId), "Category does not exist");
            }
            if (!ModelState.IsValid)
            {
                model.FitnessCardCategories = await fitnessCardService.GetFitnessCardCategoryAsync();
                return View(model);
            }

            await fitnessCardService.EditAsync(id, model);

            return RedirectToAction(nameof(All));


        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {

            if (await fitnessCardService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var model = await fitnessCardService.GetFitnessCardForDeleteAsync(id);


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await fitnessCardService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }
            await fitnessCardService.RemoveFitnessCardFromUserFitnessCardsAsync(id);

            await fitnessCardService.RemoveFitnessCardFromBuyerFitnessCardsAsync(id);

            await fitnessCardService.RemoveAsync(id);

            return RedirectToAction(nameof(All));

        }

        private string GetUserId()
        {
            var userId = ClaimsPrincipalExtensions.Id(this.User);
            return userId;
        }
    }
}
