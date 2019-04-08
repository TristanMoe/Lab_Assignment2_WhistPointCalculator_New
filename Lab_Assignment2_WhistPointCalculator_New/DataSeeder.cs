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
                new Players()
                {
                    FirstName = "Marcus",
                    LastName = "Gasberg",
                    GamePlayers = new List<GamePlayers>(),
                }
                ,
                new Players()
                {
                    PlayerId = 2,
                    FirstName = "Martin",
                    LastName = "Jespersen",
                    GamePlayers = new List<GamePlayers>(),
                });

            modelBuilder.Entity<GamePlayers>().HasData(
                new GamePlayers()
                {
                    GamesId = 1,
                    PlayerId = 1,
                    Points = 4,
                    PlayerPosition = 1

                },
                new GamePlayers()
                {
                    GamesId = 1,
                    PlayerId = 2,
                    Points = 3,
                    PlayerPosition = 2
                });
            modelBuilder.Entity<Games>().HasData(
                new Games()
                {
                    GamesId = 1,
                    Name = "SuperWeebTanks",
                    Ended = false

                });
            dataContext.Players.Add(
                new Players()
                {
                    FirstName = "Tristan",
                    LastName = "Møller",
                    GamePlayers = new List<GamePlayers>(),
                });
            dataContext.Players.Add(
                new Players()
                {
                    FirstName = "Martin",
                    LastName = "Jespersen",
                    GamePlayers = new List<GamePlayers>(),
                });
            dataContext.Players.Add(
                new Players()
                {
                    FirstName = "Mathias",
                    LastName = "Hansen",
                    GamePlayers = new List<GamePlayers>(),
                });
            dataContext.SaveChanges();
        }
    }
}