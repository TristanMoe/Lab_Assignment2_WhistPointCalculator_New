using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_Assignment2_WhistPointCalculator
{
    public class Location
    {
        //Attributes

        //Primary Key
        public string LocationId { get; set; }
        public string Name { get; set; }

        //Navigation Property for Games
        public Games Game { get; set; }
    }
}
