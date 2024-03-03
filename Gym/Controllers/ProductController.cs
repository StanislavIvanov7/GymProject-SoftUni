using Gym.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

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
    }
}
