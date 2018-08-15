using System;
using Ch_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ch_2.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View(new Product
            {
                Id = Guid.NewGuid(),
                Name = "paste",
                Description = "There's no other paste",
                Category = "Home products",
                Price = 560.23m
            });
        }
    }
}