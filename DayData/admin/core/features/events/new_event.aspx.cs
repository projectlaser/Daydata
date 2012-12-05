using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using DayData.admin.core.features.events.handlers;
using DayData.config;
using Cliver;
using DayData.admin.pub.json.instances;

namespace DayData.admin.core.features.events
{
    public partial class new_event : System.Web.UI.Page
    {
        List<Filter> filter;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!GlobalHandlers.SessionHandler.isLoggedIn())
            {
                Response.Redirect("~/admin/login/default.aspx", false);
                return;
            }
            if (!IsPostBack)
            {
                //initial load...
                //lets add to the filters
                filter = GlobalHandlers.DatabaseHandler.getFilters();
                foreach (Filter f in filter)
                {
                    filters.Items.Add(f.Name);
                }
                try {
                    if (Request.QueryString["date"] != null)
                    {
                        //then its there, redrictced possibly, lets parse it.
                        DateTime dateT;
                        DateTimeRoutines.TryParseDate(Request.QueryString["date"], DateTimeRoutines.DateTimeFormat.USA_DATE, out dateT);
                        if (dateT != null)
                        {
                            //parsed successfully.
                            //lets set Date.Text to the date
                            date.Text = dateT.Month + "/" + dateT.Day + "/" + dateT.Year;
                        }
                    }
            
                }
            catch(Exception eee)
                {
            }
            }
            else if (IsPostBack)
            {
                //yes this is a post back, so lets load our forms
                title.Text = Request.Form["title"].ToString();
                date.Text = Request.Form["date"].ToString();
                filter = GlobalHandlers.DatabaseHandler.getFilters();
            }
        }

        protected void check_CheckedChanged(object sender, EventArgs e)
        {
          //  Debug.WriteLine("our check box changed to: " + check.Checked);
           // if (check.Checked == false)
         //   {
             //   PlaceHolder1.Visible = true;
         //   }
       //     else if (check.Checked)
        //    {
//PlaceHolder1.Visible = false;
        //    }
        }

        protected void filters_SelectedIndexChanged(object sender, EventArgs e)
        {
            //we changed our filter, lets set up the info..
            //Debug.WriteLine("filter changed too: " + filters.SelectedItem.Value);
            //lets get the log and lat of the loc
            if (filter != null)
            {
                //lets get long and lat of the loc
                foreach (Filter f in filter)
                {
                    if (f.Name == filters.SelectedItem.Value)
                    {
                        //does equal..
                        loc.Text = f.Lat + " " + f.Long;
                        loc.Focus();
                        TextBox1.Focus(); // this is just to activate the javascript
                    }
                }
            }
        }

        protected void checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox.Checked == false)
            {
                placeholder.Visible = true;
            }
            else if (checkbox.Checked)
            {
                placeholder.Visible = false;
            }
        }
        public string getLongLat()
        {
            if (long_lat.Value != null)
            {
                string toReturn = long_lat.Value.Replace("(", "");
                toReturn = toReturn.Replace(")", "");
                toReturn = toReturn.Replace(" ", "");
                return toReturn;
            }
            Filter f = GlobalHandlers.DatabaseHandler.getDefaultFilter();
            return f.Long + "," + f.Lat;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //lets add an event.
            bool noEnd = checkbox.Checked;
            Event eventToAdd = new Event();
            string Event_Title = String.Empty;
            string Event_Time = String.Empty;
            string Event_Date = String.Empty;
            string Event_Desc = String.Empty;
            string Event_Loc = String.Empty;
            string Event_Room = String.Empty; //coming soon
            if (noEnd)
            {
                //ok.. so lets just set the starting time.
                Event_Time = starttime.Text;
            }
            else
            {
                Event_Time = starttime.Text + "-" + endtime.Text;
            }
            Event_Title = title.Text;
            Event_Date = date.Text;
            Event_Desc = desc.Text;
            Event_Loc = getLongLat();

            eventToAdd.Title = Event_Title;
            eventToAdd.Time = Event_Time;
            eventToAdd.Location = Event_Loc;
            eventToAdd.Date = Event_Date;
            eventToAdd.Description = Event_Desc;
            eventToAdd.From = "0";
            if (GlobalHandlers.DatabaseHandler.addEvent(eventToAdd))
            {
                Response.Redirect("default.aspx", false);
            }
            //Debug.WriteLine("Title: " + Event_Title + " : Date: " + Event_Date + " : Desc: " + Event_Desc + " : Loc: " + Event_Loc);
          //  string timeStartEvent = 
        }
    }
}