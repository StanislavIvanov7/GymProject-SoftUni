using Gym.Core.Contracts;
using Gym.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Gym.Controllers
{

    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService service )
        {
            productService = service;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await productService.AllProductsAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new ProductFormViewModel();
            model.ProductCategories = await productService .GetProductCategoryAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.ProductCategories = await productService.GetProductCategoryAsync();
                return View(model);
            }
            string userId = GetUserId();
            await productService .AddAsync(model,userId);
            return RedirectToAction (nameof(All));

        }
        private string GetUserId()
        {
            var userId = ClaimsPrincipalExtensions.Id(this.User);
            return userId;
        }
    }
}
