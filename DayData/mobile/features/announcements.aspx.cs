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
    public partial class announcements : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            header.Text = GlobalHandlers.SettingHandler.Settings["name"].ToString();
            setupAndShow();

        }
        public void setupAndShow()
        {
            contentPanel.Controls.Add(new LiteralControl(@"<ul data-role=""listview"" data-inset=""true"">"));
            contentPanel.Controls.Add(new LiteralControl(@"<li data-role=""list-divider"">Announcements for " + DateTime.Now.ToString("D") + ":</li>"));


            foreach (Announcement e in GlobalHandlers.DatabaseHandler.getAnnouncements())
            {
                string WITH_TITLE_Markup = @"<li><h4>?title</h4><p>?text</p></li>";
                string WITHOUT_TITLE_Markup = @"<li>?text</li>";

                string toAdd = String.Empty;
                if (e.Title == "" || e.Title == "(no title)")
                {
                    toAdd = WITHOUT_TITLE_Markup;
                    toAdd = toAdd.Replace("?text", e.Text);
                    contentPanel.Controls.Add(new LiteralControl(toAdd));
                }
                else
                {
                    toAdd = WITH_TITLE_Markup;
                    toAdd = toAdd.Replace("?title", e.Title);
                    toAdd = toAdd.Replace("?text", e.Text);
                    contentPanel.Controls.Add(new LiteralControl(toAdd));
                }
            }
            contentPanel.Controls.Add(new LiteralControl("</ul>"));
        }
    }
}