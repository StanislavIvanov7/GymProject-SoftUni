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

        [HttpGet] 
        public async Task<IActionResult> Edit(int id)
        {
            var model = await productService.GetProductByIdAsync(id);
            //if(model == null)
            //{
            //    return BadRequest();
            //}
            model.ProductCategories = await productService.GetProductCategoryAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProductFormViewModel model)
        {
          

            if (!ModelState.IsValid)
            {
                model.ProductCategories = await productService.GetProductCategoryAsync();
                return View(model);
            }

            await productService.EditAsync(id,model);

            return RedirectToAction(nameof(All));


        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await productService .DetailsProductAsync(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await productService.GetProductByIdAsync(id);

            var model = new DeleteProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                ImageUrl = product.ImageUrl,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await productService.RemoveAsync(id);

            return RedirectToAction(nameof(All));

        }
        private string GetUserId()
        {
            var userId = ClaimsPrincipalExtensions.Id(this.User);
            return userId;
        }
    }
}
