using Gym.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Gym.Controllers
{
    public class WorkoutPlanController : Controller
    {
        private readonly IWorkoutPlanService workoutPlanService;
        public WorkoutPlanController(IWorkoutPlanService _workoutPlanService)
        {
            workoutPlanService = _workoutPlanService;
        }
        public async Task<IActionResult> All()
        {
            var model = await workoutPlanService.AllWorkoutPlansAsync();

            return View(model);
        }
    }
}
