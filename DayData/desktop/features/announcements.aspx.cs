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
    public partial class announcements : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string name = "[ERROR]";
            GlobalHandlers.SettingHandler.Settings.TryGetValue("name", out name);
            name_label.Text = name;
            this.Title = "Announcements: " + name;
            top_image.ImageUrl = "../../required/css/images/iconready.png";
            top_image.AlternateText = GlobalHandlers.DatabaseHandler.globalInformation.School_Name;
            top_image.Style.Add("max-height", "30px");
            dateLabel.Text = DateTime.Now.ToString("dddd, MMMMM d");
            loadAnnouncements();
        }
        public void loadAnnouncements()
        {
            string markup_no_title = @"<tr><td>?text</td></tr>";
            string markup_with_title = @"<tr><td><h4>?title</h4>?text</td></tr>";

            foreach (Announcement d in GlobalHandlers.DatabaseHandler.getAnnouncements())
            {
                string toAdd;
                if (d.Title == "(no title)" || d.Title == "")
                {
                    toAdd = markup_no_title.Replace("?text", d.Text);
                    tablePanel.Controls.Add(new LiteralControl(toAdd));
                }
                else
                {
                    toAdd = markup_with_title.Replace("?text", d.Text);
                    toAdd = toAdd.Replace("?title", d.Title);
                    tablePanel.Controls.Add(new LiteralControl(toAdd));
                }
            }

        }
    }
}