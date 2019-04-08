using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_Assignment2_WhistPointCalculator
{
    public class NormalRound : Rounds
    {
        //Attributes 
        [Range(1,13)]
        public int Tricks { get; set; }
        public string Trump { get; set; }

        [Required]
        //Foreign key for bid winner position 
        public int BidWinnerPositionId { get; set; }
        //Navigation property 
        public GamePlayers BidWinnerGameplayer { get; set; }

        [Required]
        //Foreign key for bid winner mate position 
        public int BidWinnerMatePositionId { get; set; }
        //Navigation property 
        public GamePlayers BidWinnerMateGameplayer { get; set; }
    }
}
