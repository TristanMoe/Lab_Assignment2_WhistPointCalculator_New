using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lab_Assignment2_WhistPointCalculator
{
    public class GameRounds
    {        
        //Attributes

        //Primary Key
        [Required]
        public int GameRoundsId { get; set; }

        public int RoundNumber { get; set; }

        //Not entirely sure what these are supposed to mean
        //TODO: Discuss 'em
        public int DealerPosition { get; set; }
        public bool Ended { get; set; }
        public bool Started { get; set; }

        //Foreign key for Games
        public int GamesId { get; set; }
        //Navigation Property for Games
        public Games Game { get; set; }

        //Navigation Property for GameRoundPlayers
        public List<GameRoundPlayers> GRPs { get; set; }

        //Navigation Property for SoleRoundWinner
        public List<SoleRoundWinner> SR_Winners { get; set; }

        [Required]
        //Foreign Key for roundtype 
        public int RoundTypeId { get; set; }

        //Navigation Property for Rounds
        public List<Rounds> Rounds { get; set; }
        
    }

}
