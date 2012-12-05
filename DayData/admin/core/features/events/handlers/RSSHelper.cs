using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.IO;
using System.Net;

namespace DayData.admin.core.features.events.handlers
{
    public class RSSHelper
    {
        public RSSHelper() { }
        public Channel parseRSS(string r_url)
        {
            string feedUri = r_url;
            var myFeed = getChannelQuery(XDocument.Load(new StreamReader(HttpWebRequest.Create(feedUri).GetResponse().GetResponseStream())));
            foreach (var channel in myFeed)
            {
                return channel;
            }
            return null;
        }
        static IEnumerable<Channel> getChannelQuery(XDocument xdoc)
        {
            return from channels in xdoc.Descendants("channel")
                   select new Channel
                   {
                       Title = channels.Element("title") != null ? channels.Element("title").Value : "",
                       Link = channels.Element("link") != null ? channels.Element("link").Value : "",
                       Description = channels.Element("description") != null ? channels.Element("description").Value : "",
                       Items = from items in channels.Descendants("item")
                               select new Item
                               {
                                   Title = items.Element("title") != null ? items.Element("title").Value : "",
                                   Link = items.Element("link") != null ? items.Element("link").Value : "",
                                   Description = items.Element("description") != null ? items.Element("description").Value : "",
                                   Guid = (items.Element("guid") != null ? items.Element("guid").Value : "")
                               }
                   };
        }
        public class Channel
        {
            public string Title { get; set; }
            public string Link { get; set; }
            public string Description { get; set; }
            public IEnumerable<Item> Items { get; set; }
        }
        public class Item
        {
            public string Title { get; set; }
            public string Link { get; set; }
            public string Description { get; set; }
            public string Guid { get; set; }
        }
    }
}