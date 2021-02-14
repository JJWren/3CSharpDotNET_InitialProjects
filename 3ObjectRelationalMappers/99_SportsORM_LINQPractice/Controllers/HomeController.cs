using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            ViewBag.WomensLeague = _context.Leagues.Where(league => league.Name.Contains("Womens"));

            ViewBag.HockeyLeague = _context.Leagues.Where(league => league.Name.Contains("Hockey"));

            ViewBag.AllButFootball = _context.Leagues.Where(league => !league.Name.Contains("Football"));

            ViewBag.ConfLeague = _context.Leagues.Where(league => league.Name.Contains("Conference"));

            ViewBag.AtlanticLeague = _context.Leagues.Where(league => league.Name.Contains("Atlantic"));

            ViewBag.DallasTeams = _context.Teams.Where(team => team.Location == "Dallas");

            ViewBag.RaptorsTeams = _context.Teams.Where(team => team.TeamName.Contains("Raptors"));

            ViewBag.CityTeams = _context.Teams.Where(team => team.Location.Contains("City"));

            ViewBag.TTeams = _context.Teams.Where(team => team.TeamName.Contains("T"));

            ViewBag.ByLocTeams = _context.Teams.OrderBy(team => team.Location);

            ViewBag.ByLocTeams = _context.Teams.OrderByDescending(team => team.TeamName);

            ViewBag.CooperPlayers = _context.Players.Where(player => player.LastName == "Cooper").OrderBy(player => player.FirstName);

            ViewBag.NoJoshuaCooperPlayers = _context.Players.Where(player => player.LastName == "Cooper" && player.FirstName != "Joshua").OrderBy(player => player.FirstName);

            ViewBag.AlexanderWyattPlayers = _context.Players.Where(player => player.FirstName == "Alexander" || player.FirstName == "Wyatt").OrderBy(player => player.FirstName);

            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            ViewBag.AtlSoccConf = _context.Leagues.Where(league => league.Name.Contains("Womens"));

            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}