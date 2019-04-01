using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lab_Assignment2_WhistPointCalculator
{
    public class GamePlayers
    {
        //Attributes

        //Primary Key
        [Required]
        public int PlayerPosition { get; set; }

        public int Points { get; set; }

        [Required]
        //Navigation Property for players
        public Players Player { get; set; }

        //Foreign Key for Game
        public string GamesId { get; set; }

        //Foreign key for Player 
        public string PlayerId { get; set; }

        [Required]
        //Navigation Property for Games 
        public Games Game { get; set; }
    }
}
