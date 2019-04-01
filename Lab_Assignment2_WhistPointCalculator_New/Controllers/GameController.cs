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
    public class GameController : Controller
    {
        private DataContext _dbContext;
        public GameController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var viewModel = new GameViewModel(){Players = _dbContext.Players.ToList()};
            return View(viewModel);
        }

        public IActionResult EditPlayers()
        {
            var viewModel = new EditPlayersViewModel(){Players = _dbContext.Players.ToList()};
            
            return View(viewModel);
        }
    }
}