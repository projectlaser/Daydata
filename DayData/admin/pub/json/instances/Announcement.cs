using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace DayData.admin.pub.json.instances
{
    public class Announcement
    {
        public string Title;
        public string Text;
        public int ID;
        public bool locked = false;
    }
}