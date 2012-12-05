using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DayData.config;
using DayData.config.handlers.timers;

namespace DayData.desktop
{
    public partial class about : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string name = String.Empty;
            GlobalHandlers.SettingHandler.Settings.TryGetValue("name", out name);
            name_label.Text = name;
            //namelabel2.Text = name;
            top_image.ImageUrl = "../required/css/images/iconready.png";
            top_image.AlternateText = GlobalHandlers.DatabaseHandler.globalInformation.School_Name;
            top_image.Style.Add("max-height", "30px");
            loadStatus();
        }
        public void loadStatus()
        {
            string markup = @"<tr><td>?statusitem</td><td>?status</td></tr>";

            for (int i = 0; i < 5; i++)
            {
                string toAdd = markup;
                if (i == 0)
                {
                    //announcement last updated
                    toAdd = toAdd.Replace("?statusitem", "Last Updated Announcements");
                    toAdd = toAdd.Replace("?status", TimerHandlers.getCentralTime(Updates.LastUpdated_Announcements).ToString("U").Replace("Z", ""));
                    tablePanel.Controls.Add(new LiteralControl(toAdd));
                }
                if (i == 1)
                {
                    //announcement last updated
                    toAdd = toAdd.Replace("?statusitem", "Last Updated Events");
                    toAdd = toAdd.Replace("?status", TimerHandlers.getCentralTime(Updates.LastUpdated_Events).ToString("U").Replace("Z", ""));
                    tablePanel.Controls.Add(new LiteralControl(toAdd));
                }
                
            }

            

        }
    }
}