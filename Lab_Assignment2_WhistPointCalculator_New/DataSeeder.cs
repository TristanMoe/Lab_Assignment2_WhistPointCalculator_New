using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Lab_Assignment2_WhistPointCalculator.DAL
{
    public static class DataSeeder
    {
        public static void Seed(DataContext dataContext)
        {
            dataContext.Database.EnsureCreated();
            var isSeeded = dataContext.Players.FirstOrDefault(p => p.FirstName == "Marcus");
            if (isSeeded != null)
                return;
            dataContext.Players.Add(
                new Lab_Assignment2_WhistPointCalculator.Players()
                {
                    FirstName = "Marcus",
                    LastName = "Gasberg",
                    GamePlayers = new List<GamePlayers>(),
                });
            dataContext.Players.Add(
                new Lab_Assignment2_WhistPointCalculator.Players()
                {
                    FirstName = "Tristan",
                    LastName = "Møller",
                    GamePlayers = new List<GamePlayers>(),
                });
            dataContext.Players.Add(
                new Lab_Assignment2_WhistPointCalculator.Players()
                {
                    FirstName = "Martin",
                    LastName = "Jespersen",
                    GamePlayers = new List<GamePlayers>(),
                });
            dataContext.Players.Add(
                new Lab_Assignment2_WhistPointCalculator.Players()
                {
                    FirstName = "Mathias",
                    LastName = "Hansen",
                    GamePlayers = new List<GamePlayers>(),
                });
            dataContext.SaveChanges();
        }
    }
}