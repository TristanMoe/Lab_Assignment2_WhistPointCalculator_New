using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_Assignment2_WhistPointCalculator
{
    public class SoleRoundWinner
    {
        //Foreign Key for Game Rounds 
        public string GameRoundsId { get; set; }
        //Navigation Property 
        public GameRounds GameRound { get; set; }

        //Not sure about the second foreign key
    }
}
