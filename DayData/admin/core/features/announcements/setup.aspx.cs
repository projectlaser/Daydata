using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Diagnostics;
using DayData.admin.core.features.announcements.classes;
using DayData.config;
using System.Web.Services;

namespace DayData.admin.core.features.announcements
{
    public partial class setup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!GlobalHandlers.SessionHandler.isLoggedIn())
            {
                Response.Redirect("~/admin/login/default.aspx", false);
                return;
            }
            if (!IsPostBack)
            {
                if (GlobalHandlers.DatabaseHandler.announcementUpdaterAlreadyExists())
                {
                    alreadySetup.Value = "true";
                }
            }

        }

        protected void link_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string id=GoogleDocsHandler.getGoogleDocID(link.Text);
                idBox.Text = id;
                List<string> st = GoogleDocsHandler.downloadFileGetList(id);
                foreach (string announcement in st)
                {
                    Panel1.Controls.Add(new LiteralControl("<tr><td>" + announcement + "</td></tr>"));
                }
            }
            catch (Exception ee)
            {
                Debug.WriteLine(ee);
            }

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedItem.Text == "Every 24 hours")
            {
                holder.Visible = true;
            }
            else
            {
                holder.Visible = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (idBox.Text == "")
            {
                return;
            }
            //GlobalHandlers.DatabaseHandler.submitAnnouncementUpdater("google_docs", link.Text, idBox.Text, DropDownList1.SelectedValue, (DropDownList2.Visible) ? DropDownList2.SelectedValue.ToString() : null);
            Session.Add("setup", GlobalHandlers.DatabaseHandler.submitAnnouncementUpdater("google_docs", link.Text, idBox.Text, DropDownList1.SelectedValue, (DropDownList2.Visible) ? DropDownList2.SelectedValue.ToString() : null).ToString());
            Response.Redirect("default.aspx");
        }
    }
}