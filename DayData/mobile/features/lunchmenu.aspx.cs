using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DayData.config;

namespace DayData.mobile.features
{
    public partial class lunchmenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            header.Text = GlobalHandlers.SettingHandler.Settings["name"].ToString();
            setup();
        }
        public void setup()
        {
            contentPanel.Controls.Add(new LiteralControl(@"<ul data-role=""listview"" data-inset=""true"">"));
            contentPanel.Controls.Add(new LiteralControl(@"<li data-role=""list-divider"">Lunch Menu for " + DateTime.Now.ToString("D") + ":</li>"));

            string[] lunchItems = GlobalHandlers.DatabaseHandler.getListOfItemsForToday();
            if(lunchItems == null)
            {
                //no items. lets tell them.
                contentPanel.Controls.Add(new LiteralControl("<li><h2>No lunch menu available today</h2></li>"));
                addEnd();
                return;
            }
            foreach (string e in lunchItems)
            {
                string WITHOUT_TITLE_Markup = @"<li>?text</li>";
                string toAdd = String.Empty;
                toAdd = WITHOUT_TITLE_Markup.Replace("?text", e);
                contentPanel.Controls.Add(new LiteralControl(toAdd));
            }
            addEnd();
        
        }
        public void addEnd()
        {
            contentPanel.Controls.Add(new LiteralControl("</ul>"));
        }
    }
}