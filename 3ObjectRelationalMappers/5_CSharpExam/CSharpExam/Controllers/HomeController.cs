using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CSharpExam.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CSharpExam.Controllers
{
    public class HomeController : Controller
    {
        private MyContext DbContext;

        public HomeController(MyContext context)
        {
            DbContext = context;
        }

        public User GetUser()
        {
            return DbContext.Users.FirstOrDefault(u => u.UserID == HttpContext.Session.GetInt32("UserID"));
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
                    HttpContext.Session.SetInt32("UserID", newUser.UserID);
                    return RedirectToAction("Bright_Ideas");
                }
            }
            else
            {
                return View("Index");
            }
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
                    HttpContext.Session.SetInt32("UserID", userInDb.UserID);
                    return RedirectToAction("Bright_Ideas");
                }
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet("Bright_Ideas")]
        public IActionResult Bright_Ideas()
        {
            User CurrUser = GetUser();
            if (CurrUser != null)
            {
                ViewBag.User = GetUser();

                ViewBag.Ideas = DbContext.Ideas.Include(idea => idea.Creator).Include(l => l.Likes).ThenInclude(u => u.User).OrderByDescending(l => l.Likes.Count).ToList();

                return View("Bright_Ideas");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost("IdeaForm")]
        public IActionResult IdeaForm(Idea newIdea)
        {
            User CurrUser = GetUser();
            if (ModelState.IsValid)
            {
                // Sets the One-to-Many relation (UserID and Creator)
                newIdea.UserID = CurrUser.UserID;
                DbContext.Add(newIdea);
                Console.WriteLine("Idea has been added.");
                DbContext.SaveChanges();

                Like newLike = new Like();
                newLike.UserID = newIdea.UserID;
                newLike.IdeaID = newIdea.IdeaID;
                DbContext.Add(newLike);
                DbContext.SaveChanges();

                ViewBag.Ideas = DbContext.Ideas.Include(idea => idea.Creator).Include(l => l.Likes).ThenInclude(u => u.User).OrderBy(l => l.Likes.Count).ToList();

                return RedirectToAction("Bright_Ideas");
            }
            else
            {
                Console.WriteLine("Failed to add Idea.");

                ViewBag.User = GetUser();

                ViewBag.Ideas = DbContext.Ideas.Include(idea => idea.Creator).Include(l => l.Likes).ThenInclude(u => u.User).OrderBy(l => l.Likes.Count).ToList();

                return View("Bright_Ideas");
            }
        }

        [HttpGet("PeopleWhoLiked/{IdeaID}")]
        public IActionResult PeopleWhoLiked(int IdeaID)
        {
            User CurrUser = GetUser();
            if (CurrUser != null)
            {
                ViewBag.User = GetUser();

                Idea CurrIdea = DbContext.Ideas.Include(i => i.Likes).ThenInclude(u => u.User).FirstOrDefault(w => w.IdeaID == IdeaID);

                return View("PeopleWhoLiked", CurrIdea);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet("Like/{IdeaID}")]
        public IActionResult Like(int IdeaID)
        {
            User CurrUser = GetUser();
            if (CurrUser != null)
            {
                ViewBag.User = GetUser();

                ViewBag.Ideas = DbContext.Ideas.Include(idea => idea.Creator).Include(l => l.Likes).ThenInclude(u => u.User).OrderBy(l => l.Likes.Count).ToList();

                Like liked = new Like();
                liked.UserID = CurrUser.UserID;
                liked.IdeaID = IdeaID;
                DbContext.Add(liked);
                DbContext.SaveChanges();

                return RedirectToAction("Bright_Ideas");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet("Unlike/{IdeaID}")]
        public IActionResult Unlike(int IdeaID)
        {
            User CurrUser = GetUser();
            if (CurrUser != null)
            {
                ViewBag.User = GetUser();

                ViewBag.Ideas = DbContext.Ideas.Include(idea => idea.Creator).Include(l => l.Likes).ThenInclude(u => u.User).OrderBy(l => l.Likes.Count).ToList();

                Like ToRmv = DbContext.Likes.SingleOrDefault(l => l.IdeaID == IdeaID && l.UserID == CurrUser.UserID);
                DbContext.Remove(ToRmv);
                DbContext.SaveChanges();

                return RedirectToAction("Bright_Ideas");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet("Delete/{IdeaID}")]
        public IActionResult Delete(int IdeaID)
        {
            User CurrUser = GetUser();
            if (CurrUser != null)
            {
                ViewBag.User = GetUser();

                ViewBag.Ideas = DbContext.Ideas.Include(idea => idea.Creator).Include(l => l.Likes).ThenInclude(u => u.User).OrderBy(l => l.Likes.Count).ToList();

                Idea ToRmv = DbContext.Ideas.SingleOrDefault(l => l.IdeaID == IdeaID);
                DbContext.Remove(ToRmv);
                DbContext.SaveChanges();

                return RedirectToAction("Bright_Ideas");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet("UserInfo/{CreatorID}")]
        public IActionResult UserInfo(int CreatorID)
        {
            User CurrUser = GetUser();
            if (CurrUser != null)
            {
                User ThisUser = DbContext.Users.Where(u => u.UserID == CreatorID).Include(i => i.Likes).ThenInclude(l => l.Idea).SingleOrDefault();

                ViewBag.UserIdeas = DbContext.Ideas.Any(i => i.UserID == CreatorID);

                return View("UserInfo", ThisUser);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
