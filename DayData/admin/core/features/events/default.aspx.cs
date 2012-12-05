using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DayData.config;
using DayData.admin.pub.json.instances;
using DayData.admin.core.features.events.handlers;
using System.Diagnostics;
using DayData.admin.core.features.events.handlers.Updaters;

namespace DayData.admin.core.features.events
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!GlobalHandlers.SessionHandler.isLoggedIn())
            {
                Response.Redirect("~/admin/login/default.aspx", false);
                return;
            }
            if (Request.QueryString["todo"] != null)
            {
                string whatToDo = Request.QueryString["todo"];
                if (whatToDo == "update")
                {
                    string settingsMissouriRiverID = GlobalHandlers.SettingHandler.Settings["school_id_missouri_river"];
                    List<Event> ev = MissouriRiver.getEvents("http://www.missouririverconf.org/g5-bin/client.cgi?G5genie=167&school_id="+settingsMissouriRiverID+"&XMLCalendar=3");
                     GlobalHandlers.DatabaseHandler.updateEvents(ev);
                     GlobalHandlers.Debugger.write("updated events - requested");
                }
            }
            loadTodaysEvents();
            loadFilters();
        }
        public void loadFilters()
        {
            List<Filter> filters = GlobalHandlers.DatabaseHandler.getFilters();
            filter_selections.Items.Clear();
            foreach (Filter f in filters)
            {
                string markup = @"<tr><td>?name</td><td>?lat, ?long</td><td><div lat=""?lat"" long=""?long"" class=""minimap""></div></td></tr>";
                string toReturn = String.Empty;
                toReturn = markup.Replace("?name", f.Name);
                toReturn = toReturn.Replace("?lat", f.Lat);
                toReturn = toReturn.Replace("?long", f.Long);
                filters_table.Controls.Add(new LiteralControl(toReturn));
                filter_selections.Items.Add(f.Name);
            }
        }
        public void loadTodaysEvents()
        {
//                 <tr><td>0</td><td>The Plot Event</td><td>Descirption of our plot event goes here</td><td>Link For More...</td></tr>
            List<Event> events = GlobalHandlers.DatabaseHandler.getEvents(true);
            foreach (Event x in events)
            {
                //<tr><th>ID</th><th>Title</th><th>Time</th><th>Description</th><th>Added By</th><th>Location</th><th></th><th></th></tr>
                string markup = @"<tr><td>?id</td><td>?title</td><td>?time</td><td>?desc</td><td>?addedby</td><td>?locationName</td><td><div lat=""?lat"" long=""?long"" class=""minimap""></div></td><td>?buttons</td></tr>";
                string buttons = @"<div class=""button-group""> <a for=""?id"" href=""#edit"" class=""button primary"">Edit Event</a><a for=""?id"" href=""delete"" class=""button danger"">Delete Event</a></div>";
                string toAdd = markup;
                toAdd = toAdd.Replace("?buttons", buttons);
                toAdd = toAdd.Replace("?id", x.ID);
                toAdd = toAdd.Replace("?title", x.Title);
                toAdd = toAdd.Replace("?time", x.Time);
                toAdd = toAdd.Replace("?desc", x.Description);
                toAdd = toAdd.Replace("?addedby", x.From);

                Filter f = GlobalHandlers.DatabaseHandler.getFilterFromLocation(x.Location);
                toAdd = toAdd.Replace("?locationName", f.Name);
                


                toAdd = toAdd.Replace("?lat", f.Lat);
                toAdd = toAdd.Replace("?long", f.Long);
                tablePanel.Controls.Add(new LiteralControl(toAdd));
             //   tablePanel.Controls.Add(new LiteralControl("<tr><td>"+x.ID+"</td><td>"+x.Title+"</td><td>"+x.Description+"</td><td>"+buttons+"</td></tr>"));
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
         //lets deleted the selected 
            Debug.WriteLine("Delete : " + filter_selections.SelectedValue);
            int toremove = filter_selections.SelectedIndex;
            filter_selections.Items.RemoveAt(toremove);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}