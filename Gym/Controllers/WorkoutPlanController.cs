using Gym.Core.Contracts;
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

            var userId = GetUserId();

            if (await workoutPlanService.UserHasFitnessCardAsync(userId) == false && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var model = await workoutPlanService.DetailsWorkoutPlansAsync(id);

            return View(model);
        }


        private string GetUserId()
        {
            var userId = ClaimsPrincipalExtensions.Id(this.User);
            return userId;
        }
    }
}
