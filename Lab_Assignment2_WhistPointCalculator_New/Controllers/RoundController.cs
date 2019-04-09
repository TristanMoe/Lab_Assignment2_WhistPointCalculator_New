using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab_Assignment2_WhistPointCalculator;
using Lab_Assignment2_WhistPointCalculator_New.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab_Assignment2_WhistPointCalculator_New.Controllers
{
    public class RoundController : Controller
    {
        private ShowViews _showViewsRepo;
        public RoundController(ShowViews showViews)
        {
            _showViewsRepo = showViews;
        }
        public IActionResult Index(int gameId)
        {
            var currentGame = _showViewsRepo._db.Games
                .Include(g => g.GamePlayers)
                .ThenInclude(gp=>gp.Player)
                .Include(g=>g.GameRounds)
                .FirstOrDefault(p => p.GamesId == gameId);
            if (currentGame == null)
                return NotFound();
            var viewModel = new RoundViewModel(){CurrentGame = currentGame};
            return View(viewModel);
        }

        public IActionResult NextRound()
        {
            return View("Index");
        }
    }
}