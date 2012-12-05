using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DayData.config;

namespace DayData.admin.core.controls
{
    public partial class GoogleAnalytics : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            string id;
            GlobalHandlers.SettingHandler.Settings.TryGetValue("google_analytics_tracker_id", out id);

            var script = @"<script type=""text/javascript"">" +
                         @"var gaJsHost = ((""https:"" == document.location.protocol) ? ""https://ssl."" : ""http://www."");" +
                         @"document.write(unescape(""%3Cscript src='"" + gaJsHost + ""google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E""));</script>" +
@"<script type=""text/javascript""> var pageTracker = _gat._getTracker('" + id + "');" +
@"pageTracker._trackPageview();" +
"</script>";
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "google_analytics", script);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}