﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Remotion.Linq.Utilities;

namespace Lab_Assignment2_WhistPointCalculator
{
    public class ShowViews
    {
        public DataContext _db { get; private set; }

        public ShowViews(DataContext db)
        {
            _db = db;
        }
        public async Task<Games> ListGameWithPlayers(int? id)
        {
            var games=await _db.Games
                .Include(players => players.GamePlayers)
                .ThenInclude(p=>p.Player)
                .SingleAsync(p=>p.GamesId==id);
            return games;
        }

        public async Task<Games> GetRoundInformation(int gamesId)
        {
            var game = await _db.Games
                .Include(d => d.GameRounds)
                    .ThenInclude(p => p.Game)
                        .ThenInclude(p => p.GamePlayers)
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

       /* public async Task<List<Games>> GameWinners(DataContext db)
        {
            var games=await db.Games
                .Include(p=>p.Wi)
        }*/

        public void CreateNewPlayer(Players player)
        {
            _db.Players.Add(player);
            //var game=new Games{Name=name,};
        }

        public async Task EditPlayer(int id)
        {
            var player = _db.Players.Single(p => p.PlayerId == id);
            _db.Update(player);
            await _db.SaveChangesAsync();
        }

        public async Task DeletePlayer(int id)
        {
            var player = _db.Players.Single(p => p.PlayerId == id);
            _db.Remove(player);
            await _db.SaveChangesAsync();
        }

        public int CreateNewGame(string name,  List<string> playersFirstnames, string locationName)
        {

            var game = new Games { Started = true, Ended = false, Updated = DateTime.Now, Name = name};
            var location = new Location {Name = locationName}; 
            var gameRounds = new GameRounds();
            game.Location = location;
            game.GameRounds = new List<GameRounds>();
            game.GamePlayers = new List<GamePlayers>();

            int i = 1; 
            //set foreign key for each gameplay (assumes that they exist in database)
            foreach (var playerName in playersFirstnames)
            {
                //Find Player
                var player = _db.Players
                    .Single(p => p.FirstName == playerName);


                var gamePlayer = new GamePlayers
                {
                    Player = player,
                    GamesId = game.GamesId,
                    PlayerPosition = i
                };

                _db.GamePlayers.Add(gamePlayer);
                game.GamePlayers.Add(gamePlayer);

                i++; 
            }


            var entity = _db.Games.Add(game);
            _db.GameRounds.Add(gameRounds);
            _db.Locations.Add(location);
            
            _db.SaveChanges();

            return entity.Entity.GamesId;
        }

        public void AddRound(string gamename, int tricks, int trickswon, string trump, string FN_winnerGameplayer, string FN_winnerMateGamePlayer)
        {
            var game = _db.Games
                .Single(g => g.Name == gamename);

            var gameround = _db.GameRounds
                .Include(gr => gr.Game)
                    .ThenInclude(g => g.GamePlayers)
                        .ThenInclude(p => p.Player)
                .Single(gr => gr.GamesId == game.GamesId);

            var gameplayers = _db.GamePlayers
                .Include(gp =>
                    gp.Player.FirstName == FN_winnerGameplayer && gp.Player.FirstName == FN_winnerMateGamePlayer)
                .ToList();

            foreach (var gamePlayer in gameplayers)
            {
                gamePlayer.Points += trickswon; 
            }

            var round = new Rounds
            {
                Tricks = tricks,
                TricksWon = trickswon,
                Trump = trump
            };

            _db.Rounds.Add(round);
            _db.SaveChanges();

        }

        public void EndGame(string gamename)
        {
            //load game
            var game = _db.Games
                .Single(g => g.Name == gamename);
            game.Ended = true; 
        }
    }
}
