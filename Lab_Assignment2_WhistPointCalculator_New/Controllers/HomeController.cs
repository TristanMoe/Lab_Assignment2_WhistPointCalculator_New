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
        private DataContext _dbContext;
        public HomeController(DataContext dbContext)
        {
        }
        public IActionResult Index()
        {
            return View();
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
