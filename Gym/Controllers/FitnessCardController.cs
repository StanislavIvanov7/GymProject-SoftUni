using Gym.Core.Contracts;
using Gym.Core.Models.FitnessCard;
using Gym.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Gym.Controllers
{
    public class FitnessCardController : BaseController
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
            var model = new FitnessCardFormViewModel();

            model.FitnessCardCategories = await fitnessCardService.GetFitnessCardCategoryAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(FitnessCardFormViewModel model)
        {
            if(await fitnessCardService.CategoryExistAsync(model.FitnessCardCategoryId) == false)
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
        public async Task<IActionResult> Details(int id)
        {
            if(await fitnessCardService.ExistAsync(id) == false)
            {
                return BadRequest();
            }
            var model = await fitnessCardService.DetailsFitnessCardAsync(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            if (await fitnessCardService.ExistAsync(id) == false)
            {
                return BadRequest();
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
            await fitnessCardService.RemoveAsync(id);

            return RedirectToAction(nameof(All));

        }

        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            string userId = GetUserId();

            var carts = await fitnessCardService.AllFitnessCardInCartAsync(userId);

            return View(carts);

        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
        {
            if(await fitnessCardService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            await fitnessCardService.AddToCartAsync(id, userId);

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var userId = GetUserId();

            var fitnessCard = await fitnessCardService.GetFitnessCardInCartAsync(userId,id);
            if (fitnessCard == null)
            {
                return BadRequest();

            }


            if (fitnessCard.UserId != userId)
            {
                return Unauthorized();
            }

            await fitnessCardService.RemoveFromCartAsync(id, userId);

            return RedirectToAction(nameof(Cart));
        }
        private string GetUserId()
        {
            var userId = ClaimsPrincipalExtensions.Id(this.User);
            return userId;
        }
    }
}
