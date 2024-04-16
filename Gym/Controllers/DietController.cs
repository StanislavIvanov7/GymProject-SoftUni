using Gym.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Gym.Controllers
{
    public class DietController : BaseController
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
            if (await dietService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            var userId = GetUserId();
            if (await dietService.UserHasFitnessCardAsync(userId) == false && User.IsAdmin() == false)
            {
                return Unauthorized();
            }
            var model = await dietService.DetailsDietAsync(id);

            return View(model);

        }

        private string GetUserId()
        {
            var userId = ClaimsPrincipalExtensions.Id(this.User);
            return userId;
        }
    }
}
