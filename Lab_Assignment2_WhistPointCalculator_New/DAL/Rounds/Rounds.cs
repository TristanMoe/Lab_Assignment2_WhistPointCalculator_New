using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lab_Assignment2_WhistPointCalculator
{
    public class Rounds
    {
        [Required]
        //Foreign key for Gamerounds
        public int GameRoundsId { get; set; }

        //Navigation Property 
        public GameRounds Gameround { get; set; }
    }
}
