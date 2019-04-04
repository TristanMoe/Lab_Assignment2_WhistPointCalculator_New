using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_Assignment2_WhistPointCalculator
{
    public class SoleRoundWinner
    {
        public int Tricks { get; set; }

        [Required]
        //Foreign Key for Game Rounds 
        public int GameRoundsId { get; set; }
        //Navigation Property 
        public GameRounds GameRound { get; set; }

        [Required]
        //Player position foreign key
        public int PlayerPositionId { get; set; }


        //Navigation property 
        public GamePlayers GamePlayer { get; set; }

    }
}
