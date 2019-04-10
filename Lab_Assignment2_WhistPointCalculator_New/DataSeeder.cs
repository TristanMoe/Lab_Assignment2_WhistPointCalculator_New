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

            dataContext.GameRounds.Add(new GameRounds()
            {
                GameNumber = 1,
                GamesId = 1,
                Rounds=new List<Rounds>()

            });
            dataContext.GamePlayers.Add(
                new GamePlayers()
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
           
            dataContext.Rounds.Add(new Rounds()
            {
                RoundNumber = 1,
                BidWinnerPositionId = 1,
                BidWinnerMatePositionId = 2,

            });
            dataContext.SaveChanges();
        }
    }
}