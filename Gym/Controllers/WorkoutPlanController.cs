using Gym.Core.Contracts;
using Gym.Core.Models.Diet;
using Gym.Core.Models.WorkoutPlan;
using Gym.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Gym.Controllers
{
    public class WorkoutPlanController : BaseController
    {
        private readonly IWorkoutPlanService workoutPlanService;

        public WorkoutPlanController(IWorkoutPlanService _workoutPlanService)
        {
            workoutPlanService = _workoutPlanService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
           
            var model = await workoutPlanService.AllWorkoutPlansAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if(await workoutPlanService.ExistAsync(id) == false)
            {
                return BadRequest();
            }
            var model = await workoutPlanService.DetailsWorkoutPlansAsync(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new WorkoutPlanFormViewModel();

            model.WorkoutPlanCategories = await workoutPlanService.GetWorkoutPlanCategoriesAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(WorkoutPlanFormViewModel model)
        {
            if(await workoutPlanService.CategoryExistAsync(model.WorkoutPlanCategoryId)== false)
            {
                ModelState.AddModelError(nameof(model.WorkoutPlanCategoryId), "Category does not exist");
            }
            if (!ModelState.IsValid)
            {
                model.WorkoutPlanCategories = await workoutPlanService.GetWorkoutPlanCategoriesAsync();

                return View(model);
            }

            string userId = GetUserId();

            await workoutPlanService.AddAsync(userId,model);
            return RedirectToAction (nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            if (await workoutPlanService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await workoutPlanService.GetWorkoutPlanForEditAsync(id);

            model.WorkoutPlanCategories = await workoutPlanService.GetWorkoutPlanCategoriesAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(WorkoutPlanFormViewModel model, int id)
        {
            if (await workoutPlanService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (await workoutPlanService.CategoryExistAsync(model.WorkoutPlanCategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.WorkoutPlanCategoryId), "Category does not exist");
            }

            if (!ModelState.IsValid)
            {
                model.WorkoutPlanCategories = await workoutPlanService.GetWorkoutPlanCategoriesAsync();
                return View(model);
            }

            await workoutPlanService.EditAsync(id, model);

            return RedirectToAction(nameof(All));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if(await workoutPlanService.ExistAsync(id) == false) 
            {
                return BadRequest();
            }

            var model = await workoutPlanService.GetWorkoutPlanForDeleteAsync(id);

           
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            if (await workoutPlanService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            await workoutPlanService.RemoveAsync(id);

            return RedirectToAction(nameof(All));
        }

        private string GetUserId()
        {
            var userId = ClaimsPrincipalExtensions.Id(this.User);
            return userId;
        }
    }
}
