using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DayData.config.handlers
{
    public class TextByIds
    {
        public static string getFeatureTypeByID(string id)
        {
            switch (id)
            {
                case "0":
                    return "Announcements";
                case "1":
                    return "Unknown";
                default:
                    return "Unknown ATM";
            }
        }
    }
}