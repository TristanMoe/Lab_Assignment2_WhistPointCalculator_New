using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_Assignment2_WhistPointCalculator
{
    public class GameRoundPlayers
    {
        //Attributes
        public int ByePoints { get; set; }

        [Required]
        //Foreign Key
        public string GameRoundsId { get; set; }
        //Navigation Property 
        public GameRounds GameRound { get; set; }

        //Do not understand this foreign Key
        //public int PlayerPos {get; set;}

    }
}
