using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Lab_Assignment2_WhistPointCalculator.DAL
{
    public static class DataSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Players>().HasData(
                new Players()
                {
                    PlayerId = 1,
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
        }
    }
}