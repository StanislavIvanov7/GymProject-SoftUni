using Gym.Core.Contracts;
using Gym.Core.Models;
using Gym.Core.Models.FitnessCard;
using Gym.Core.Services;
using Gym.Infrastructure.Constants;
using Gym.Infrastructure.Data;
using Gym.Infrastructure.Data.Common;
using Gym.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static Gym.Infrastructure.Constants.DataConstant;

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
        public async Task<IActionResult> Details(int id)
        {
            if(await productService.ExistAsync(id) == false)
            {
                return BadRequest();
            }
            var model = await productService .DetailsProductAsync(id);

            return View(model);
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

            var product = await productService.GetProductInCartAsync(userId,id);

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
            if (await productService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            await productService.AddToCartAsync(id, userId);

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Buy(int id)
        {

            if (await productService.ExistAsync(id) == false)
            {
                return BadRequest();
            }
            var userId = GetUserId();

            if (await productService.IsInUserCart(id, userId) == false)
            {
                Unauthorized();
            }

            if (await productService.CanBuyAsync(id) == false)
            {
                return BadRequest();
            }

            await productService.BuyAsync(id, userId);

            return RedirectToAction(nameof(All));

        }

        [HttpGet]
        public async Task<IActionResult> Purchase()
        {
            string userId = GetUserId();

            var purchasedProduct = await productService.AllPurchasedProductsAsync(userId);

            return View(purchasedProduct);

        }
        private string GetUserId()
        {
            var userId = ClaimsPrincipalExtensions.Id(this.User);
            return userId;
        }
    }
}
