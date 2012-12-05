using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DayData.config;

namespace DayData.admin.pub.pages.features
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // version.Text = ConstantManager.Total_Version.ToString();
            if (!GlobalHandlers.SessionHandler.isLoggedIn())
            {
                Response.Redirect("~/admin/login/default.aspx", false);
                return;
            }
        }
    }
}