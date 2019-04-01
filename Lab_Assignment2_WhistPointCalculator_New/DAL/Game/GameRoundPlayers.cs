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
        public bool Bye { get; set; }

        [Required]
        //Foreign Key
        public int GameRoundsId { get; set; }
        //Navigation Property 
        public GameRounds GameRound { get; set; }

        //Foreign key to players
        public int PlayerPositionId { get; set; }

        //Navigation property to GamePlayers PlayerPosition 
        public GamePlayers GamePlayer { get; set; }
    }
}
