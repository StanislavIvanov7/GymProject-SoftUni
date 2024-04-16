using Gym.Core.Contracts;
using Gym.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Gym.Areas.Admin.Controllers
{
    public class ProductController : AdminBaseController
    {
        private readonly IProductService productService;



        public ProductController(IProductService service)
        {
            productService = service;

        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await productService.AllProductsForAdminPageAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {

            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var model = new ProductFormViewModel();
            model.ProductCategories = await productService.GetProductCategoryAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductFormViewModel model)
        {

            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            if (await productService.CategoryExistAsync(model.ProductCategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.ProductCategoryId), "Category does not exist");

            }
            if (!ModelState.IsValid)
            {
                model.ProductCategories = await productService.GetProductCategoryAsync();
                return View(model);
            }
            string userId = GetUserId();
            await productService.AddAsync(model, userId);
            return RedirectToAction(nameof(All));

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (await productService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var model = await productService.GetProductForEditAsync(id);

            model.ProductCategories = await productService.GetProductCategoryAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProductFormViewModel model)
        {
            if (await productService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            if (await productService.CategoryExistAsync(model.ProductCategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.ProductCategoryId), "Category does not exist");
            }

            if (!ModelState.IsValid)
            {
                model.ProductCategories = await productService.GetProductCategoryAsync();
                return View(model);
            }

            await productService.EditAsync(id, model);

            return RedirectToAction(nameof(All));


        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await productService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var model = await productService.GetProductForDeleteAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await productService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }
            await productService.RemoveProductsFromUserProductsAsync(id);

            await productService.RemoveProductsFromBuyerProductsAsync(id);
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
