using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DayData.admin.core.features.events.handlers;

namespace DayData.admin.pub.json.instances
{
	public class Event
	{
        public string ID { get; set; }
        public string Title { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string From { get; set; }
        public Filter Filter { get; set; }
	}
}