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
                .ThenInclude(gr=>gr.GRPs)
                .FirstOrDefault(p => p.GamesId == gameId);
            if (currentGame == null)
                return NotFound();
            var viewModel = new RoundViewModel(){CurrentGame = currentGame};
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(RoundViewModel roundViewModel)
        {
            if (roundViewModel == null)
                return NotFound();
            return View(roundViewModel);
        }

        //SavePoints
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SavePoints(int id, [Bind("PlayerId,FirstName,LastName")] GamePlayers playerModel)
        {
            if (id != playerModel.PlayerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _showViewsRepo._db.GamePlayers.Update(playerModel);
                    _showViewsRepo._db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View("Index",new RoundViewModel(){CurrentGame =  playerModel.Game});
        }

        public IActionResult NextRound(int gameId)
        {
            _showViewsRepo._db.SaveChanges();
            var currentGame = _showViewsRepo._db.Games
                .Include(g => g.GamePlayers)
                .ThenInclude(gp => gp.Player)
                .Include(g => g.GameRounds)
                .ThenInclude(gr => gr.GRPs)
                .FirstOrDefault(p => p.GamesId == gameId);
            //Add new round
            return View("Index",new RoundViewModel(){CurrentGame = currentGame});
        }
    }
}