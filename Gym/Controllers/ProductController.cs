﻿using Microsoft.AspNetCore.Mvc;

namespace Gym.Controllers
{

    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
