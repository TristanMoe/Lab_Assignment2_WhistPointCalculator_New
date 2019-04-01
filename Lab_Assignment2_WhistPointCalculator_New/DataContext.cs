using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Lab_Assignment2_WhistPointCalculator
{
    public class DataContext : DbContext

    {
        #region Entity Declaration
        public DbSet<GamePlayers> GamePlayers { get; set; }
        public DbSet<Players> Players { get; set; }
        public DbSet<Games> Games { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<GameRounds> GameRounds { get; set; }
        public DbSet<GameRoundPlayers> GameRoundPlayers { get; set; }
        public DbSet<Rounds> Rounds { get; set; }
        public DbSet<SoleRound> SoleRounds { get; set; }
        public DbSet<NormalRound> NormalRounds { get; set; }
        public DbSet<SoleRoundWinner> SoleRoundWinners { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(
                    "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Trill\\OneDrive\\Dokumenter\\WhistPointCalculator.mdf;Integrated Security=True;Connect Timeout=30");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*Missing hashkeys and Deletebehavior 
            Not sure if fluent foreign keys are necessary,
            when data annotation is used. 
            Missing a lot of constraints 
            HOWEVER it seems to add Cascade deletion automatically with items with no primary key
                - When primary key is another entitites' primary key. 
             */

            #region Keys 
            modelBuilder.Entity<Players>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Games>()
                .HasKey(p => p.GamesId);

            modelBuilder.Entity<GameRounds>()
                .HasKey(p => p.GameRoundsId);

            modelBuilder.Entity<Location>()
                .HasKey(p => p.LocationId); 

            //No keys? 
            modelBuilder.Entity<GameRoundPlayers>()
                .HasKey(k => k.GameRoundsId);

            modelBuilder.Entity<GamePlayers>()
                .HasKey(k => k.GamesId);

            modelBuilder.Entity<Rounds>()
                .HasKey(k => k.GameRoundsId);

            modelBuilder.Entity<SoleRoundWinner>()
                .HasKey(k => k.GameRoundsId);
            #endregion

            /// <summary>
            /// Inheritance setup for Rounds
            /// </summary>
            #region Round & SoleRound / Normal Round
            modelBuilder.Entity<SoleRound>().HasBaseType<Rounds>();
            modelBuilder.Entity<NormalRound>().HasBaseType<Rounds>();
            #endregion

            /// <summary>
            /// Games and relations (Location, Game Rounds, Game Players)
            /// </summary>
            #region Games & Relations
            /// <summary>
            /// One location has one Game, but a Game
            /// can be placed in several locations
            /// </summary>
            modelBuilder.Entity<Games>()
                .HasMany(p => p.Location)
                .WithOne(b => b.Game)
                .HasForeignKey(k => k.LocationId);

            /// <summary>
            /// A Game can have several players 
            /// </summary>
            modelBuilder.Entity<Games>()
                .HasMany(p => p.GamePlayers)
                .WithOne(b => b.Game)
                .HasForeignKey(k => k.GamesId); 

            /// <summary>
            /// A Game can have several Gamerounds
            /// </summary>
            modelBuilder.Entity<GameRounds>()
                .HasOne(p => p.Game)
                .WithMany(b => b.GameRounds)
                .HasForeignKey(k => k.GamesId); 
            #endregion

            /// <summary>
            /// Game Rounds and relations (Rounds, GameRoundPlayers, SoleRoundWinner)
            /// </summary>
            #region Game Rounds & Relations
            /// <summary>
            /// A Game Round can have several GameRoundPlayers
            /// </summary>
            modelBuilder.Entity<GameRounds>()
                .HasMany(p => p.GRPs)
                .WithOne(b => b.GameRound)
                .HasForeignKey(k => k.GameRoundsId); 

            
            /// <summary>
            /// A Game Round can consists of several rounds
            /// </summary>
            modelBuilder.Entity<GameRounds>()
                .HasMany(p => p.Rounds)
                .WithOne(b => b.Gameround)
                .HasForeignKey(k => k.GameRoundsId); 
            
            /// <summary>
            /// A Game Round can consists of SoleRoundWinners
            /// </summary>
            modelBuilder.Entity<GameRounds>()
                .HasMany(p => p.SR_Winners)
                .WithOne(b => b.GameRound)
                .HasForeignKey(k => k.GameRoundsId);
            #endregion

            /// <summary>
            /// Player has one Gameplayer,
            /// but GamePlayer has many players?
            /// </summary>
            #region Players & GamePlayers
            modelBuilder.Entity<Players>()
                .HasMany(p => p.GamePlayers)
                .WithOne(b => b.Player);
            #endregion
        }
    }
}
