using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DayData.config.handlers.timers
{
    public class Updater
    {
        public string ID = String.Empty;
        public string Feature_Id { get; set; }
        public string Type_Id { get; set; }
        public string Updater_Name { get; set; }
        public string Link { get; set; }
        public string Type { get; set; }
        public string Seperator { get; set; }
    }
}