using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DayData.config.handlers.tiles.class_id;

namespace DayData.config.handlers.tiles.instances
{
    public class Announcements : Tile
    {
        public string unique_id { get; set; }
        public string name { get; set; }
        public string color { get; set; }
        public string size { get; set; }
        public string label { get; set; }
        public string iconSrc { get; set; }
        public string appTitle { get; set; }
        public string appUrl { get; set; }
    }
}