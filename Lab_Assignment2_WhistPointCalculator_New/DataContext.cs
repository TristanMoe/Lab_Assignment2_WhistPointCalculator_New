using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Lab_Assignment2_WhistPointCalculator.DAL;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Lab_Assignment2_WhistPointCalculator
{
    public class DataContext : DbContext

    {
        public DataContext(DbContextOptions<DataContext> options)
            :base(options)
        {
            
        }
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
                .HasKey(p => p.PlayerId);

            modelBuilder.Entity<Games>()
                .HasKey(p => p.GamesId);

            modelBuilder.Entity<GameRounds>()
                .HasKey(p => p.GameRoundsId);

            modelBuilder.Entity<Location>()
                .HasKey(p => p.LocationId);

            modelBuilder.Entity<GamePlayers>()
                .HasKey(k => new { k.GamesId, k.PlayerPosition });

            //No keys? 
            modelBuilder.Entity<GameRoundPlayers>()
                .HasKey(k => new {k.PlayerPositionId, k.GameRoundsId}); 

            modelBuilder.Entity<Rounds>()
                .HasKey(k => k.GameRoundsId);

            modelBuilder.Entity<SoleRoundWinner>()
                .HasKey(k => new {k.GameRoundsId, k.PlayerPositionId}); 
            #endregion

            #region Round & SoleRound / Normal Round
            modelBuilder.Entity<SoleRound>().HasBaseType<Rounds>();
            modelBuilder.Entity<NormalRound>().HasBaseType<Rounds>();
            #endregion

            #region Games & Relations
            // <summary>
            // One location has one Game, but a Game
            // can be placed in several locations
            // </summary>
            modelBuilder.Entity<Games>()
                .HasMany(g => g.Location)
                .WithOne(l => l.Game)
                .HasForeignKey(l => l.LocationId);

            // <summary>
            // A Game can have several players 
            // </summary>
            modelBuilder.Entity<Games>()
                .HasMany(g => g.GamePlayers)
                .WithOne(gp => gp.Game)
                .HasForeignKey(gp => gp.GamesId); 

            // <summary>
            // A Game can have several Gamerounds
            // </summary>
            modelBuilder.Entity<GameRounds>()
                .HasOne(gr => gr.Game)
                .WithMany(g => g.GameRounds)
                .HasForeignKey(g => g.GamesId); 
            #endregion

            #region Game Rounds & Relations
            // <summary>
            // A Game Round can have several GameRoundPlayers
            // </summary>
            modelBuilder.Entity<GameRounds>()
                .HasMany(gr => gr.GRPs)
                .WithOne(grp => grp.GameRound)
                .HasForeignKey(grp => grp.GameRoundsId); 

            
            // <summary>
            // A Game Round can consists of several rounds
            // </summary>
            modelBuilder.Entity<GameRounds>()
                .HasMany(gr => gr.Rounds)
                .WithOne(r => r.Gameround)
                .HasForeignKey(gr => gr.RoundTypeId); 
            
            // <summary>
            // A Game Round can consists of SoleRoundWinners
            // </summary>
            modelBuilder.Entity<GameRounds>()
                .HasMany(gr => gr.SR_Winners)
                .WithOne(srw => srw.GameRound)
                .HasForeignKey(srw => srw.GameRoundsId);
            #endregion

            // <summary>
            // Player has one Gameplayer,
            // but GamePlayer has many players?
            // </summary>
            #region Players & GamePlayers
            modelBuilder.Entity<Players>()
                .HasMany(gm => gm.GamePlayers)
                .WithOne(p => p.Player)
                .HasForeignKey(gm => gm.PlayerId);
            #endregion

            #region PlayerPosition Relations 

            modelBuilder.Entity<GamePlayers>()
                .HasMany(gp => gp.SoleRoundWinners)
                .WithOne(srw => srw.GamePlayer)
                .HasForeignKey(srw => srw.PlayerPositionId);
            
            modelBuilder.Entity<GamePlayers>()
                .HasMany(gp => gp.GameRoundPlayers)
                .WithOne(grp => grp.GamePlayer)
                .HasForeignKey(grp => grp.PlayerPositionId);

            modelBuilder.Entity<GamePlayers>()
                .HasOne(gp => gp.WinnerNormalRound)
                .WithOne(nr => nr.BidWinnerGameplayer)
                .HasForeignKey<NormalRound>(nr => nr.BidWinnerPositionId);

            modelBuilder.Entity<GamePlayers>()
                .HasOne(gp => gp.WinnerMateNormalRound)
                .WithOne(nr => nr.BidWinnerMateGameplayer)
                .HasForeignKey<NormalRound>(nr => nr.BidWinnerMatePositionId);

            #endregion

            DataSeeder.Seed(modelBuilder);
        }
    }
}
