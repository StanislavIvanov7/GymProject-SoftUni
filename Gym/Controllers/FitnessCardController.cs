using Gym.Core.Contracts;
using Gym.Core.Models;
using Gym.Core.Models.FitnessCard;
using Gym.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
            var model = await fitnessCardService.DetailsFitnessCardAsync(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await fitnessCardService.GetFitnessCardByIdAsync(id);
            //if(model == null)
            //{
            //    return BadRequest();
            //}
            model.FitnessCardCategories = await fitnessCardService.GetFitnessCardCategoryAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, FitnessCardFormViewModel model)
        {


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
            var fitnessCard = await fitnessCardService.GetFitnessCardByIdAsync(id);

            var model = new DeleteFitnessCardViewModel()
            {
                Id = fitnessCard.Id,
                ImageUrl = fitnessCard.ImageUrl,
                
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
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
