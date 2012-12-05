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
    public partial class events_more : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                //event is here.
                string id = Request.QueryString["id"].ToString();
                Event _event = GlobalHandlers.DatabaseHandler.getEventById(id);
                
                if (_event != null)
                {
                    title_header.Text = _event.Title;
                    titleLabel2.Controls.Add(new LiteralControl(_event.Title));
                    desc.Controls.Add(new LiteralControl(_event.Description));
                    time.Controls.Add(new LiteralControl(_event.Time));
                    loc.Value = _event.Location;
                    this.Title = _event.Title;
                }
                else
                {
                    //show error
                    titleLabel2.Controls.Add(new LiteralControl("Error loading event"));
                }


            }
            else
            {
                Response.Redirect("events.aspx", false);
            }
            setupTop();
        }
        public void addTextToPanel(string text, Panel p)
        {
            Literal lit = new Literal();
            lit.Text = text;
            p.Controls.Add(lit);
        }
        public void setupTop()
        {
            string name = "[ERROR]";
            GlobalHandlers.SettingHandler.Settings.TryGetValue("name", out name);
            name_label.Text = name;
            top_image.ImageUrl = "../../required/css/images/iconready.png";
            top_image.AlternateText = GlobalHandlers.DatabaseHandler.globalInformation.School_Name;
            top_image.Style.Add("max-height", "30px");
        }
    }
}