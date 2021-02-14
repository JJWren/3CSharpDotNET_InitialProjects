using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LoginAndReg.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace LoginAndReg.Controllers
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
            HttpContext.Session.Clear();
            return View();
        }

        [HttpPost("Register")]
        public IActionResult Register(User NewUser)
        {
            if (ModelState.IsValid)
            {
                if (dbContext.Users.Any(user => user.Email == NewUser.Email))
                {
                    ModelState.AddModelError("Email", "Email is already in use");
                    return View("Index");
                }

                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                NewUser.Password = Hasher.HashPassword(NewUser, NewUser.Password);

                // Don't add this in until functionality of everything works!
                dbContext.Add(NewUser);
                dbContext.SaveChanges();

                // Creates a session of the registered user
                HttpContext.Session.SetInt32("LoggedIn", NewUser.UserID);

                return RedirectToAction("Success");
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost("LoginUser")]
        public IActionResult LoginUser(LUser login)
        {
            if (ModelState.IsValid)
            {
                User UserInDb = dbContext.Users.SingleOrDefault(u => u.Email == login.LEmail);
                // check email
                if (UserInDb == null)
                {
                    ModelState.AddModelError("Email", "Invalid login attempt");
                    return View("Login");
                }
                // check password
                else
                {
                    var hasher = new PasswordHasher<LUser>();
                    var result = hasher.VerifyHashedPassword(login, UserInDb.Password, login.LPassword);
                    if (result == 0)
                    {
                        ModelState.AddModelError("LPassword", "Invalid login attempt");
                        return View("Login");
                    }
                }
                // Creates a session of the logged user
                login.LUserID = UserInDb.UserID;
                HttpContext.Session.SetInt32("LoggedIn", login.LUserID);

                return RedirectToAction("Success");
            }
            else
            {
                return View("Login");
            }
        }

        [HttpGet("Success")]
        public IActionResult Success()
        {
            int? loggedIn = HttpContext.Session.GetInt32("LoggedIn");
            if (loggedIn != null)
            {
                ViewBag.User = dbContext.Users.FirstOrDefault(u => u.UserID == (int)loggedIn);
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
