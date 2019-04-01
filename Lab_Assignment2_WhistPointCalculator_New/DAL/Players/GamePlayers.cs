﻿using System;
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
        //Foreign key for Player 
        public int PlayerId { get; set; }

        //Navigation Property for players
        public Players Player { get; set; }

        [Required]
        //Foreign Key for Game
        public int GamesId { get; set; }

        //Navigation Property for Games 
        public Games Game { get; set; }
    }
}
