using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DayData.config;
using DayData.admin.pub.json.instances;

namespace DayData.desktop.features
{
    public partial class events : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            todayLabel.Text = DateTime.Now.ToString("dddd, MMMMM d");
            setupDefaultHeader();
            List<Event> listOfTodaysEvents = GlobalHandlers.DatabaseHandler.getEvents(true);
            string markup = @"<li><a href=""events_more.aspx?id=?idOfEvent""><span style=""width:60%; display: inline;"">?title</span> ?time</a></li>";

            if (listOfTodaysEvents == null)
            {
                eventPanel.Controls.Add(new LiteralControl(@"<li><a href=""#""><span>No events today</span></a></li>"));
                return;
            }
            foreach (Event d in listOfTodaysEvents)
            {
                /**
                 * <li><a href="#"><span style="width: 60%; display: inline;">Event Title #3</span> 6:00 PM - 5:00 AM</a></li>**/
                string toAdd = markup.Replace("?idOfEvent", d.ID);
                toAdd = toAdd.Replace("?title", d.Title);
                toAdd = toAdd.Replace("?time", d.Time);
                eventPanel.Controls.Add(new LiteralControl(toAdd));
            }
        }
        public void setupDefaultHeader()
        {
            string name = "[ERROR]";
            GlobalHandlers.SettingHandler.Settings.TryGetValue("name", out name);
            this.Title = "Events: " + name;
            name_label.Text = name;
            top_image.ImageUrl = "../../required/css/images/iconready.png";
            top_image.AlternateText = GlobalHandlers.DatabaseHandler.globalInformation.School_Name;
            top_image.Style.Add("max-height", "30px");
        }
    }
}