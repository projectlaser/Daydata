using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DayData.config;

namespace DayData.admin.core.features.announcements
{
    public partial class delete_page : System.Web.UI.Page
    {
        string IDToDelete = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!GlobalHandlers.SessionHandler.isLoggedIn())
            {
                Response.Redirect("~/admin/login/default.aspx", false);
                return;
            }
            if (Request.QueryString["id"] != null)
            {
               // Response.Write(Request.QueryString["id"].ToString());
                IDToDelete = Request.QueryString["id"];

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (GlobalHandlers.DatabaseHandler.deleteAnnouncement(IDToDelete))
            {
                Response.Redirect("default.aspx", false);
            }
        }
    }
}