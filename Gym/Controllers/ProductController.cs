using Gym.Core.Contracts;
using Gym.Core.Models;
using Gym.Infrastructure.Constants;
using Gym.Infrastructure.Data;
using Gym.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Gym.Controllers
{

    public class ProductController : BaseController 
    {
        private readonly IProductService productService;



        public ProductController(IProductService service)
        {
            productService = service;

        }

        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AllProductsQueryModel model)
        {
            var products = await productService.AllProductsAsync(
                model.Category,
                model.SearchTerm,
                model.Sorting,
                model.CurrentPage,
                model.ProductsPerPage);

            model.TotalProductsCount = products.TotalProductsCount;
            model.Products = products.Products;
            model.Categories = await productService.AllCategoriesNamesAsync();

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
            var model = await productService.GetProductForEditAsync(id);
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
            var model = await productService.GetProductForDeleteAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await productService.RemoveAsync(id);

            return RedirectToAction(nameof(All));

        }

        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            string userId = GetUserId();

            var carts = await productService.AllProductsInCartAsync(userId);

            return View(carts);

        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var userId = GetUserId();

            var product = await productService.GetProductInCartAsync(userId);
            if (product == null)
            {
                return BadRequest();

            }
          

            if (product.UserId != userId)
            {
                return Unauthorized();
            }

            await productService.RemoveFromCartAsync(id,userId);

            return RedirectToAction(nameof(Cart));
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
        {
            string userId = GetUserId();

            await productService.AddToCartAsync(id, userId);

            return RedirectToAction(nameof(All));
        }

        private string GetUserId()
        {
            var userId = ClaimsPrincipalExtensions.Id(this.User);
            return userId;
        }
    }
}
