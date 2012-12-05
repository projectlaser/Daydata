using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DayData.config.handlers.features.scoreboard
{
    public class Score
    {
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public string Team1Score { get; set; }
        public string Team2Score { get; set; }
        public Sport SportName {get; set;}
        public TypeOfGame TypeOfGameName { get; set; }

    }
    public enum Sport
    {
        Baseball, Boys_Basketball, Girls_Basketball, Cross_Country, Football, Boys_Golf, Girls_Golf, Boys_Soccer, Girls_Soccer, Softball, Swimming, Boys_Tennis, Girls_Tennis, Boys_Track, Girls_Track, Volleyball, Wrestling
    }
    public enum TypeOfGame
    {
        Freshman, JV, Varsity, None
    }
}