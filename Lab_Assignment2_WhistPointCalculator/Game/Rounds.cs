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

    public class SoleRound : Rounds
    {
        //Attributes
        public string Soletype { get; set; }

        
    }

    public class NormalRound : Rounds
    {
        //Attributes 

        //Not sure about the attributes or foreign keys
    }
}
