using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DayData.admin.pub.json.instances;
using DayData.config;

namespace DayData.mobile.features
{
    public partial class event_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            header.Text = GlobalHandlers.SettingHandler.Settings["name"].ToString();
            if (Request.QueryString["id"] != null)
            {
                //event is here.
                string id = Request.QueryString["id"].ToString();
                Event _event = GlobalHandlers.DatabaseHandler.getEventById(id);

                if (_event != null)
                {
                   // ///title_header.Text = _event.Title;
                   // titleLabel2.Controls.Add(new LiteralControl(_event.Title));
                   // desc.Controls.Add(new LiteralControl(_event.Description));
                   // time.Controls.Add(new LiteralControl(_event.Time));
                   // loc.Value = _event.Location;
                    title.Text = _event.Title;
                    time.Text = _event.Time;
                    desc.Text = _event.Description;
                    loc.Value = _event.Location;

                }
                else
                {
                    //show error
                 //   titleLabel2.Controls.Add(new LiteralControl("Error loading event"));

                    //contentPanel.Controls.Add(new LiteralControl("Error loading event"));
                }


            }
            else
            {
                Response.Redirect("events.aspx", false);
            }
        }
    }
}