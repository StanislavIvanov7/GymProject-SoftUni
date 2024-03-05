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

        private string GetUserId()
        {
            var userId = ClaimsPrincipalExtensions.Id(this.User);
            return userId;
        }
    }
}
