using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChefsNDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;

        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            List<Chef> AllChefs = dbContext.Chefs.Include(d => d.Dishes).ToList();

            return View(AllChefs);
        }

        [HttpGet("Dishes")]
        public IActionResult Dishes()
        {
            List<Dish> AllDishes = dbContext.Dishes.ToList();

            ViewBag.AllChefs = dbContext.Chefs.Include(d => d.Dishes).ToList();

            return View(AllDishes);
        }

        [HttpGet("AddChef")]
        public IActionResult AddChef()
        {
            return View();
        }

        [HttpGet("AddDish")]
        public IActionResult AddDish()
        {
            ViewBag.AllChefs = dbContext.Chefs.Include(d => d.Dishes).ToList();

            return View();
        }

        [HttpPost("NewChef")]
        public IActionResult NewChef(Chef newchef)
        {
            if (ModelState.IsValid)
            {
                // dbContext is the database
                dbContext.Chefs.Add(newchef);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("AddChef");
            }
        }

        [HttpPost("NewDish")]
        public IActionResult NewDish(Dish newdish)
        {
            if (ModelState.IsValid)
            {
                // dbContext is the database
                dbContext.Dishes.Add(newdish);
                dbContext.SaveChanges();
                return RedirectToAction("Dishes");
            }
            else
            {
                return View("AddDish");
            }
        }
    }
}
