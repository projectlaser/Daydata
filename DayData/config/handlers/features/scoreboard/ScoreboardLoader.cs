using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DayData.admin.pub.json.instances;

namespace DayData.config.handlers.features.scoreboard
{

    public class ScoreboardLoader
    {
        ScoreboardItem item = new ScoreboardItem();

        public Score getScoreFromEvent(Event eventD)
        {
            string longString = eventD.Description + " " + eventD.Title;
            return new Score();
        }

    }
}