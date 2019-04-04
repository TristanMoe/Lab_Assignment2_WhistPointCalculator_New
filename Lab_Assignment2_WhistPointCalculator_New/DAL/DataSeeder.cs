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
                });
        }
    }
}