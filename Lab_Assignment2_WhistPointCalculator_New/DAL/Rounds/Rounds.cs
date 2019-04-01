using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_Assignment2_WhistPointCalculator
{
    public class Rounds
    {
        //Foreign key for Gamerounds
        public string GameRoundsId { get; set; }

        //Navigation Property 
        public GameRounds Gameround { get; set; }
    }
}
