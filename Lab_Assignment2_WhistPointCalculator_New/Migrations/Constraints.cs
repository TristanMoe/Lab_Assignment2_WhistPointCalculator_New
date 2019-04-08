using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab_Assignment2_WhistPointCalculator.Migrations
{
    public class Constraints : Migration
    {
        /// <summary>
        /// Constraints for the system
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //A maximum of 4 players (Pretty sure this does not work)
            //migrationBuilder.Sql("ALTER TABLE Games ADD CONSTRAINT CK_AmountOfPlayers CHECK GamePlayers <= 4");

        }
    }
}
