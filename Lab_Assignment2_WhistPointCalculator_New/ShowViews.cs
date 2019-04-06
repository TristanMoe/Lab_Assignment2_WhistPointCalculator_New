using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Lab_Assignment2_WhistPointCalculator
{
    public class ShowViews
    {
        public DataContext _db { get; private set; }

        public ShowViews(DataContext db)
        {
            _db = db;
        }
        public async Task<List<Games>> ListGamesWithNumberOfPlayer()
        {
            var listOfGames=await _db.Games
                .Include(players => players.GamePlayers).AsNoTracking().ToListAsync();
            return listOfGames;
        }

        public async Task<Games> GetRoundInformation(int gamesId)
        {
            var game = await _db.Games
                .Include(d => d.GameRounds)
                    .ThenInclude(p => p.GRPs)
                        .ThenInclude(p => p.GamePlayer)
                            .ThenInclude(p => p.Player)
                .SingleAsync(p => p.GamesId == gamesId);

            return game;


            /* Console.WriteLine("Bids, result and points for every round:");
            
             foreach (var round in game.GameRounds)
             {              
                 Console.WriteLine($"Round :{round.RoundNumber}");
                 foreach (var player in round.GRPs)
                 {
                     Console.WriteLine($"{player.GamePlayer.Player.FirstName} {player.GamePlayer.Player.LastName}");
                     Console.WriteLine($"Bid: {player.}");
                     Console.WriteLine($"Result:");
                     Console.WriteLine($"Points:{player.Points}");
                 }
 
                 Console.WriteLine($"result of round {}");
             }
             //Tristan er langsom så funktionen er ikke færdig*/
        }

        public async Task<List<Games>> GameWinners(DataContext db)
        {
            /*var games=await db.Games
                .Include(p=>p.Wi)*/
        }

        public void CreateNewGame()
        {
            //var game=new Games{Name=name,};
        }
    }
}
