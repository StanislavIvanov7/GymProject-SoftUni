using Gym.Core.Models.User;
using Gym.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static Gym.Core.Constants.CustomClaims;
namespace Gym.Controllers
{
    public class UserController : Controller
    {

        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private IUserStore<ApplicationUser> userStore;

        public UserController(SignInManager<ApplicationUser> _signInManager,
            UserManager<ApplicationUser> _userManager,
            IUserStore<ApplicationUser> _userStore)
        {
            signInManager = _signInManager;
            userManager = _userManager;
            userStore = _userStore;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ApplicationUser applicationUser = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,

            };

            await userManager.SetEmailAsync(applicationUser, model.Email);
            await userManager.SetUserNameAsync(applicationUser, model.Email);

            var result = await userManager.CreateAsync(applicationUser, model.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(model);
            }

            await userManager.AddClaimAsync(applicationUser, new System.Security.Claims.Claim(UserFullNameClaim, $"{applicationUser.FirstName} {applicationUser.LastName}"));
            await signInManager.SignInAsync(applicationUser, false);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            LoginFormModel model = new LoginFormModel()
            {
                ReturnUrl = returnUrl,
            };
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await signInManager
                .PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "There was an error while logging you in! Please try again later or contact an administrator.");

                return View(model);
            }
            return Redirect(model.ReturnUrl ?? "/Home/Index");
        }
    }
}
