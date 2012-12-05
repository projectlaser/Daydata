using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DayData.config;
using DayData.admin.pub.json.instances;

namespace DayData.mobile.features
{
    public partial class events : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            header.Text = GlobalHandlers.SettingHandler.Settings["name"].ToString();
            setup();
            showEvents();
        }
        public void setup()
        {
            contentPanel.Controls.Add(new LiteralControl(@"<ul data-role=""listview"" data-inset=""true"">"));
            contentPanel.Controls.Add(new LiteralControl(@"<li data-role=""list-divider"">Events for " + DateTime.Now.ToString("D") + ":</li>"));
        }
        public void showEvents()
        {
            List<Event> eventList = GlobalHandlers.DatabaseHandler.getEvents(true);
            foreach (Event t in eventList)
            {
                string markup = @"<li><a href=""event_details.aspx?id=?idOfEvent"">?title</a></li>";
                string toAdd = String.Empty;
                toAdd = markup.Replace("?title", t.Title);
                toAdd = toAdd.Replace("?idOfEvent", t.ID);
                contentPanel.Controls.Add(new LiteralControl(toAdd));
            }
            addEnd();
        }
        public void addEnd()
        {
            contentPanel.Controls.Add(new LiteralControl("</ul>"));
        }

    }
}