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
        public int Points { get; set; }
        public int Bye { get; set; }

        [Required]
        //Foreign Key
        public string GameRoundsId { get; set; }
        //Navigation Property 
        public GameRounds GameRound { get; set; }

        //Foreign key to players
        public string PlayerId { get; set; }

        //Navigation property to GamePlayers PlayerPosition 
        public Players PlayerPosition { get; set; }

    }
}
