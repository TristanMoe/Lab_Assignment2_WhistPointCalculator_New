using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_Assignment2_WhistPointCalculator.DAL.Players
{
    public class GameRoundPlayers
    {
        //Foreign Key 
        public int PlayerPosition { get; set; }
        public int Points { get; set; }

        //Navigation Property
        public GamePlayers GamePlayer { get; set; }
    }
}
