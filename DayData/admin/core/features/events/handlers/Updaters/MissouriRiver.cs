using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DayData.admin.pub.json.instances;
using System.Net;
using System.Diagnostics;
using System.IO;
using DayData.config;
using System.Globalization;
using System.Text.RegularExpressions;
using Cliver;

namespace DayData.admin.core.features.events.handlers.Updaters
{
    public class MissouriRiver
    {
        public MissouriRiver(string updateByLink)
        {
            //http://www.missouririverconf.org/g5-bin/client.cgi?G5genie=167&school_id=6 < link

        }
        public static List<Event> getEvents(string link)
        {
            List<Event> toReturn = new List<Event>();

            //http://www.missouririverconf.org/g5-bin/client.cgi?G5genie=167&school_id=6&G5button=13
            RSSHelper helper = new RSSHelper();
            return parseRSS(helper.parseRSS(link));
        }
        public static List<Event> parseRSS(RSSHelper.Channel channel)
        {
            List<Event> listOFEventsToReturn = new List<Event>();
            foreach (var item in channel.Items)
            {
                string title = String.Empty;
                string desc = String.Empty;
                string Location = string.Empty;
                string time = String.Empty;
                Filter fitler = new Filter();
                Event events = new Event();

                string letsGetInfoFromThis = item.Description; 
                try
                {
                    title = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(item.Title);
                    title = cleanUpSpaces(title);
                    letsGetInfoFromThis = letsGetInfoFromThis.Replace(item.Title, "");
                    letsGetInfoFromThis = cleanUpMain(letsGetInfoFromThis);
                    //gets now get the date out
                    letsGetInfoFromThis = removeDate(letsGetInfoFromThis);
                    //  Debug.WriteLine("Info: "  +letsGetInfoFromThis + ":Title:"+title);
                    string commentSection = getCommentSection(letsGetInfoFromThis);
                    desc = cleanUpSpaces(commentSection);
                    time = getTime(letsGetInfoFromThis).getTimeRangeString();
                    
                    //  Debug.WriteLine("Found time of: " + getTime(letsGetInfoFromThis).getTimeRangeString());
                    Filter d = getLocation(letsGetInfoFromThis);
                    if (d != null)
                    {
                        //good. we found the location - lets return it now
                        fitler = d;
                    }
                    else if(d == null)
                    {
                        d = GlobalHandlers.DatabaseHandler.getDefaultFilter();
                    }

                    events.Description = desc;
                    events.From = "0";
                    events.Filter = d;
                    events.Time = time;
                    events.Title = title;
                    events.Date = DateTime.Now.ToString("MM/dd/yyyy");
                    Debug.WriteLine("date: " + events.Date);
                    listOFEventsToReturn.Add(events);

                    Debug.WriteLine("Title: " + events.Title + " Desc: " + events.Description + " Filter Name: " + events.Filter.Name + " LongLat: " + events.Filter.Long + "," + events.Filter.Lat + " Time: " + events.Time);

                    
                    //Debug.WriteLine("Rest:" + letsGetInfoFromThis + "Time:" + getTime(letsGetInfoFromThis).getTimeRangeString() + "Title:" + title + "Comments:" + commentSection);
                }
                catch (Exception eee)
                {
                    GlobalHandlers.Debugger.write(eee.ToString());
                }


                //  Debug.WriteLine("Title: " +item.Title + ":" + item.Description);

            }
            return listOFEventsToReturn;
        }

        public static Filter getLocation(string loc)
        {
            List<Filter> filters = GlobalHandlers.DatabaseHandler.getFilters();
            foreach (Filter filt in filters)
            {
                if (filt.Name.ToLower().Contains(loc.ToLower()))
                {
                    return filt;
                }
                else
                {
                    return null;
                }

            }
            return null;
        }

        public static string getCommentSection(string source)
        {
            try
            {
                string com = StringHelper.GetStringInBetween(source, "Comments", ":", false, false)[0];
                int indexOfComments = source.IndexOf("Comments:");
                string size = source.Substring(indexOfComments);
                int totalSize = size.Length;
                string returning = source.Substring(indexOfComments, totalSize);
                return returning.Replace("Comments:", "");
            }
            catch (Exception ee)
            {
                Debug.WriteLine(ee.ToString());
                return String.Empty;
            }
        }

        public static string removeDate(string source)
        {
            string toRemove = DateTime.Now.ToString("yyyy/MM/dd").Replace("/", "-");
            return source.Replace(toRemove, "");

        }
        public static string cleanUpSpaces(string source)
        {
            return Regex.Replace(source, @"\s+", " ");
        }
        public static string cleanUpMain(string source)
        {
            string src = source;
            src = src.Replace("\n", "");
            return src;
        }
        public static EventTimeResult getTime(string source)
        {
            DateTimeRoutines.ParsedDateTime dateTime;
            if (DateTimeRoutines.TryParseTime(source, DateTimeRoutines.DateTimeFormat.USA_DATE, out dateTime))
            {
                if (dateTime.IsTimeFound)
                {
                    string rest = source.Substring(dateTime.IndexOfTime, dateTime.LengthOfTime);
                    return new EventTimeResult(dateTime.DateTime.ToShortTimeString(), rest, source);
                }
            }
            return new EventTimeResult("", "", source);
        }
    }
}
public class EventTimeResult
{
    string REAL_TIME = String.Empty;
    string FROM = String.Empty;
    string LONG_STRING = String.Empty;
    public EventTimeResult(string realTime, string cameFrom, string source)
    {
        REAL_TIME = realTime;
        FROM = cameFrom;
        LONG_STRING = source;
    }
    public string getTimeRangeString()
    {
        return getTimeRange(LONG_STRING);
    }
    public string getTimeRange(string source)
    {
        string TO = String.Empty;
        string To_Use = source;
        if (FROM.Length == 0)
        {
            return "All Day";
        }
        source = source.Replace(FROM, "");
        source = source.Replace("-", "");
        string toReal = "";
        bool notFound = false;
        DateTimeRoutines.ParsedDateTime dt;
        if (DateTimeRoutines.TryParseTime(source, DateTimeRoutines.DateTimeFormat.USA_DATE, out dt))
        {
            if (dt.IsTimeFound)
            {
                TO = dt.DateTime.ToShortTimeString();
                toReal = source.Substring(dt.IndexOfTime, dt.LengthOfTime);
            }
            else
            {
                notFound = true;
                toReal = String.Empty;
            }
        }
        if (toReal.Length == 0)
            return REAL_TIME;
        try
        {
            LONG_STRING = LONG_STRING.Replace(FROM, "");
            LONG_STRING = LONG_STRING.Replace(toReal, "");
        }
        catch (Exception ee) { }

        if (notFound)
        {
            return REAL_TIME;
        }
        return REAL_TIME + "-" + TO;

    }

}