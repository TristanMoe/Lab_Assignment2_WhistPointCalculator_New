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
        private ShowViews showViewsRepo;
        public RoundController(ShowViews showViews)
        {
            showViewsRepo = showViews;
        }
        public IActionResult Index(Games game)
        {
            var viewModel = new RoundViewModel(){CurrentGame = game};
            return View(viewModel);
        }

        public IActionResult NextRound()
        {
            return View("Index");
        }
    }
}