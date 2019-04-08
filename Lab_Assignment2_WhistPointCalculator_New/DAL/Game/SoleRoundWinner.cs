using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_Assignment2_WhistPointCalculator
{
    public class SoleRoundWinner
    {
        [Range(1,13)]
        public int Tricks { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
