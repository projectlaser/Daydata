using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DayData.config;
using DayData.config.handlers.timers;

namespace DayData.admin.pub.alerts
{
    public partial class alert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["alert"] != null)
            {
                string toAlert = Request.QueryString["alert"];
                if(toAlert.ToLower() == "announcements")
                {
                    //ok it wants us to alert the announcements
                    GlobalHandlers.GCMHandler.alert(config.handlers.instances.TypeToAlert.Announcements);
                    Updates.LastUpdated_Announcements = DateTime.Now;
                }
            }
        }
    }
}