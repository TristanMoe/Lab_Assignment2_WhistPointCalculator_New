using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Lab_Assignment2_WhistPointCalculator
{
    public class Games
    {
        //Attributes

        //Primary Key
        [Required]
        public string GamesId { get; set; }

        public string Description { get; set; }

        public string Started { get; set; }

        //Not sure what this should be...
        public DateTime EndedUpdated { get; set; }

        //Foreign Key for Location
        public string LocationId { get; set; }

        //Navigation Property for Location
        public List<Location> Location { get; set; }

        //Navigation Property for Game Round
        public List<GameRounds> GameRounds { get; set; }

        //Navigation Property for Gameplayers
        public List<GamePlayers> GamePlayers { get; set; }
    }

    public class Location
    {
        //Attributes

        //Primary Key
        public string LocationId { get; set; }
        public string Name { get; set; }

        //Navigation Property for Games
        public Games Game { get; set; }
    }
}
