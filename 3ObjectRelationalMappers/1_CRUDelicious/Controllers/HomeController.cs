using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CRUDelicious.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDelicious.Controllers
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
            ViewBag.AllDishes = dbContext.Dishes.OrderByDescending(dish => dish.DishID);
            return View();
        }

        [HttpGet("MakeDish")]
        public IActionResult MakeDish()
        {
            return View("MakeDish");
        }

        [HttpPost("AddDish")]
        public IActionResult AddDish(Dish NewDish)
        {
            if (ModelState.IsValid)
            {
                // dbContext is the database
                dbContext.Add(NewDish);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("MakeDish");
            }
        }

        [HttpGet("ViewDish/{DishID}")]
        public IActionResult ViewDish(int DishID)
        {
            Dish CurrDish = dbContext.Dishes.FirstOrDefault(dish => dish.DishID == DishID);
            
            ViewBag.DishID = CurrDish.DishID;
            ViewBag.Name = CurrDish.Name;
            ViewBag.Chef = CurrDish.Chef;
            ViewBag.Tastiness = CurrDish.Tastiness;
            ViewBag.Calories = CurrDish.Calories;
            ViewBag.Description = CurrDish.Description;

            // Could also just do:
            // ViewBag.CurrDish = CurrDish;
            // Instead of going ViewBag overboard LOL

            return View("ViewDish");
        }

        [HttpGet("EditDish/{DishID}")]
        public IActionResult EditDish(int DishID)
        {
            Dish CurrDish = dbContext.Dishes.FirstOrDefault(dish => dish.DishID == DishID);
            
            ViewBag.DishID = CurrDish.DishID;
            ViewBag.Name = CurrDish.Name;
            ViewBag.Chef = CurrDish.Chef;
            ViewBag.Tastiness = CurrDish.Tastiness;
            ViewBag.Calories = CurrDish.Calories;
            ViewBag.Description = CurrDish.Description;

            // Could also just do:
            // ViewBag.CurrDish = CurrDish;
            // Instead of going ViewBag overboard LOL

            return View(CurrDish);
        }

        [HttpPost("UpdateDish/{DishID}")]
        public IActionResult Edit(Dish editedDish, int DishID)
        {
            if (ModelState.IsValid)
            {
                // dbContext is the database
                Dish CurrDish = dbContext.Dishes.FirstOrDefault(dish => dish.DishID == DishID);

                CurrDish.Chef = editedDish.Chef;
                CurrDish.Name = editedDish.Name;
                CurrDish.Calories = editedDish.Calories;
                CurrDish.Tastiness = editedDish.Tastiness;
                CurrDish.Description = editedDish.Description;
                CurrDish.UpdatedAt = DateTime.Now;

                // Could also just do:
                // ViewBag.CurrDish = CurrDish;
                // Instead of going ViewBag overboard LOL

                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("EditDish", DishID);
            }
        }

        [HttpGet("DeleteDish/{DishID}")]
        public IActionResult DeleteDish(int DishID)
        {
            // dbContext is the database
            Dish CurrDish = dbContext.Dishes.SingleOrDefault(dish => dish.DishID == DishID);

            dbContext.Dishes.Remove(CurrDish);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
