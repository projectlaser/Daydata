using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DayData.config;

namespace DayData.admin.core.features.lunchmenu
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
            string[] d = GlobalHandlers.DatabaseHandler.getListOfItemsForToday();
            string[] tomorrow = GlobalHandlers.DatabaseHandler.getListOfItemsForTomorrow();
            if (d != null)
            {
                foreach (String s in d)
                {
                    LinkButton button = new LinkButton();
                    button.Click += new EventHandler(Button1_Click);
                    button.CssClass = "button plain";
                    button.Attributes.Add("for", s);
                    button.Text = "Edit";

                    LinkButton delete = new LinkButton();
                    delete.Click += new EventHandler(DeleteButton_Click);
                    delete.CssClass = "button danger";
                    delete.Attributes.Add("for", s);
                    delete.Text = "Delete";

                    lunchTodayPanel.Controls.Add(new LiteralControl("<tr><td>" + s + "</td><td>"));
                    lunchTodayPanel.Controls.Add(button);
                    lunchTodayPanel.Controls.Add(delete);
                    lunchTodayPanel.Controls.Add(new LiteralControl("</td></tr>"));
                    TodayLabel.Text = DateTime.Now.ToString("MMMM") + " " + DateTime.Now.Day;
                }
            }
            else if (d == null)
            {
                lunchTodayPanel.Controls.Add(new LiteralControl("<tr><td><i>No information found</i></td></tr>"));
            }
            if (tomorrow != null)
            {
                foreach (String s in tomorrow)
                {
                    LinkButton button = new LinkButton();
                    button.Click += new EventHandler(Button1_Click);
                    button.CssClass = "button plain";
                    button.Attributes.Add("for", s);
                    button.Text = "Edit";

                    LinkButton delete = new LinkButton();
                    delete.Click += new EventHandler(DeleteButton_Click);
                    delete.CssClass = "button danger";
                    delete.Attributes.Add("for", s);
                    delete.Text = "Delete";

                    lunchTomorrowPanel.Controls.Add(new LiteralControl("<tr><td>" + s + "</td><td>"));
                    lunchTomorrowPanel.Controls.Add(button);
                    lunchTomorrowPanel.Controls.Add(delete);
                    lunchTomorrowPanel.Controls.Add(new LiteralControl("</td></tr>"));
                    Label1.Text = DateTime.Now.ToString("MMMM") + " " + DateTime.Now.Day;
                }
            }
            else if (tomorrow == null)
            {
                lunchTomorrowPanel.Controls.Add(new LiteralControl("<tr><td><i>No information found</i></td></tr>"));
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GlobalHandlers.Debugger.write("button pressed");
            Button sent = (Button)sender;
            if (sent != null)
            {
                //get attr from it.
                GlobalHandlers.Debugger.write(sent.Attributes["for"]);
            }
        }
        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            GlobalHandlers.Debugger.write("button pressed");
            Button sentFrom = (Button)sender;
            if (sentFrom != null)
            {
                GlobalHandlers.Debugger.write(sentFrom.Attributes["for"]);
            }
        }
    }
}