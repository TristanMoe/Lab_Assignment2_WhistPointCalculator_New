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
        public string GameRoundsId { get; set; }

        public int RoundNumber { get; set; }

        //Not entirely sure what these are supposed to mean
        //TODO: Discuss 'em
        public int DealerPositionEnded { get; set; }
        public int Started { get; set; }

        //Foreign key for Games
        public string GamesId { get; set; }
        //Navigation Property for Games
        public Games Game { get; set; }

        //Navigation Property for GameRoundPlayers
        public List<GameRoundPlayers> GRPs { get; set; }

        //Navigation Property for SoleRoundWinner
        public List<SoleRoundWinner> SR_Winners { get; set; }

        //Navigation Property for Rounds
        public List<Rounds> Rounds { get; set; }
        
    }

}
