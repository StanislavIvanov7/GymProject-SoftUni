﻿using Gym.Core.Models.FitnessCard;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Gym.Controllers
{
    public class FitnessCardController : BaseController
    {
        private readonly IFitnessCardService fitnessCardService;


        public FitnessCardController(IFitnessCardService _fitnessCardService)
        {
            fitnessCardService = _fitnessCardService;
        }

        public async Task<IActionResult> All()
        {
            var model = await fitnessCardService.AllFitnessCardAsync();

            return View(model);
        }
        

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (await fitnessCardService.ExistAsync(id) == false)
            {
                return BadRequest();
            }
            var model = await fitnessCardService.DetailsFitnessCardAsync(id);

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            string userId = GetUserId();

            var carts = await fitnessCardService.AllFitnessCardInCartAsync(userId);

            return View(carts);

        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
        {
            if (await fitnessCardService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            await fitnessCardService.AddToCartAsync(id, userId);

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var userId = GetUserId();

            var fitnessCard = await fitnessCardService.GetFitnessCardInCartAsync(userId, id);
            if (fitnessCard == null)
            {
                return BadRequest();

            }


            if (fitnessCard.UserId != userId)
            {
                return Unauthorized();
            }

            await fitnessCardService.RemoveFromCartAsync(id, userId);

            return RedirectToAction(nameof(Cart));

        }

        [HttpPost]
        public async Task<IActionResult> Buy(int id)
        {
            
            if(await fitnessCardService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            var userId = GetUserId();

            if (await fitnessCardService.IsInUserCart(id, userId) == false)
            {
                Unauthorized();
            }

            if(await fitnessCardService.CanBuyAsync(id)== false)
            {
                return RedirectToAction(nameof(All));
            }

            await fitnessCardService.BuyAsync(id, userId);

            return RedirectToAction(nameof(All));



        }

        [HttpGet]
        public async Task<IActionResult> Purchase()
        {
            string userId = GetUserId();

            var purchasedFitnessCard = await fitnessCardService.AllPurchasedFitnessCardAsync(userId);

            return View(purchasedFitnessCard);

        }
        private string GetUserId()
        {
            var userId = ClaimsPrincipalExtensions.Id(this.User);
            return userId;
        }
    }
}
