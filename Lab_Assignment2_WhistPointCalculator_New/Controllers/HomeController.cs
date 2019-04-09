using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Lab_Assignment2_WhistPointCalculator;
using Microsoft.AspNetCore.Mvc;
using Lab_Assignment2_WhistPointCalculator_New.ViewModels;

namespace Lab_Assignment2_WhistPointCalculator_New.Controllers
{
    public class HomeController : Controller
    {
        private ShowViews _showViewsRepo;
        public HomeController(ShowViews showViews)
        {
            _showViewsRepo = showViews;
        }
        public IActionResult Index()
        {
            var viewModel = new HomeViewModel() { Players = _showViewsRepo._db.Players.ToList() };
            return View(viewModel);
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult StartNewGame([Bind("GameName")] string gameName)
        {
            var playerNames = _showViewsRepo._db.Players.Select(p => p.FirstName).ToList();
            var gameId = _showViewsRepo.CreateNewGame(gameName, playerNames, "Who Cares");

            return RedirectToAction("Index", "Round", gameId);
        }
    }
}
