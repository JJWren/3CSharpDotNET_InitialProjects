using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {
        private MyContext DbContext;

        public HomeController(MyContext context)
        {
            DbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            HttpContext.Session.Clear();
            return View();
        }

        // [HttpGet("Logout")]
        // public IActionResult Logout()
        // {
        //     HttpContext.Session.Clear();
        //     return RedirectToAction("Index");
        // }

        [HttpPost("Register")]
        public IActionResult Register(User newUser)
        {
            if (ModelState.IsValid)
            {
                if (DbContext.Users.Any(e => e.Email == newUser.Email))
                {
                    ModelState.AddModelError("Email", "Email is already in use!");
                    return View("Index");
                }
                else
                {
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                    DbContext.Add(newUser);
                    DbContext.SaveChanges();
                    HttpContext.Session.SetInt32("UserId", newUser.UserId);
                    return RedirectToAction("Dashboard");
                }
            }
            else
            {
                return View("Index");
            }
        }

        public User GetUser()
        {
            return DbContext.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
        }


        [HttpPost("Login")]
        public IActionResult Login(LUser login)
        {
            if (ModelState.IsValid)
            {
                User userInDb = DbContext.Users.FirstOrDefault(u => u.Email == login.LEmail);
                if (userInDb == null)
                {
                    ModelState.AddModelError("LEmail", "Invalid login attempt");
                    return View("Index");
                }
                else
                {
                    var hasher = new PasswordHasher<LUser>();
                    var result = hasher.VerifyHashedPassword(login, userInDb.Password, login.LPassword);
                    if (result == 0)
                    {
                        ModelState.AddModelError("LEmail", "Invalid login attempt");
                        return View("Index");
                    }
                    HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                    return RedirectToAction("Dashboard");
                }
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet("Dashboard")]
        public IActionResult Dashboard()
        {
            int? loggedIn = HttpContext.Session.GetInt32("UserId");
            if (loggedIn != null)
            {
                ViewBag.User = DbContext.Users.FirstOrDefault(a => a.UserId == (int)loggedIn);

                List<Wedding> CWeddings = DbContext.Weddings.Include(w => w.Creator).Include(e => e.Events).ThenInclude(u => u.User).Where(w => w.DateOfEvent >= DateTime.Now).OrderBy(d => d.DateOfEvent).ToList();

                return View(CWeddings);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet("WeddingForm")]
        public IActionResult WeddingForm()
        {
            int? loggedIn = HttpContext.Session.GetInt32("UserId");
            if (loggedIn != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost("AddWedding")]
        public IActionResult AddWedding(Wedding newWedd)
        {
            User CurrUser = GetUser();
            if (ModelState.IsValid)
            {
                // Sets the One-to-Many relation (UserID and Creator)
                newWedd.UserID = CurrUser.UserId;
                DbContext.Add(newWedd);
                DbContext.SaveChanges();

                Event autorsvp = new Event();
                autorsvp.UserID = newWedd.UserID;
                autorsvp.WeddingID = newWedd.WeddingID;
                DbContext.Add(autorsvp);
                DbContext.SaveChanges();

                return RedirectToAction("Dashboard");
            }
            else
            {
                return View("WeddingForm");
            }
        }

        [HttpGet("EventPage/{WeddingID}")]
        public IActionResult EventPage(int WeddingID)
        {
            User CurrUser = GetUser();
            if (CurrUser != null)
            {
                Wedding CurrWedd = DbContext.Weddings.Include(g => g.Events).ThenInclude(u => u.User).FirstOrDefault(w => w.WeddingID == WeddingID);

                return View("EventPage", CurrWedd);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet("UnRSVP/{WeddingID}")]
        public IActionResult UnRSVP(int WeddingID)
        {
            User CurrUser = GetUser();
            Event ToRmv = DbContext.Events.FirstOrDefault(e => e.WeddingID == WeddingID && e.UserID == CurrUser.UserId);
            DbContext.Events.Remove(ToRmv);
            DbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("RSVP/{WeddingID}")]
        public IActionResult RSVP(int WeddingID)
        {
            User CurrUser = GetUser();
            Event rsvp = new Event();
            rsvp.UserID = CurrUser.UserId;
            rsvp.WeddingID = WeddingID;
            DbContext.Add(rsvp);
            DbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }
    }
}
