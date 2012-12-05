using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DayData.config;

namespace DayData.admin.core.features.events
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!GlobalHandlers.SessionHandler.isLoggedIn())
            {
                Response.Redirect("~/admin/login/default.aspx", false);
                return;
            }
            string script = @"<script type=""text/javascript""> $('document').ready(function() { alert('loaded') });</script>";
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "load", script);
        }
    }
}