using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DayData.desktop.features
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //this is just a redirecter
            if (Request.QueryString["feature"] != null)
            {
                string request = Request.QueryString["feature"].ToString().ToLower();
                switch (request)
                {
                    case "announcements":
                        Response.Redirect("announcements.aspx", false);
                        break;
                    case "events":
                        Response.Redirect("events.aspx", false);
                        break;
                    case "lunch":
                        Response.Redirect("lunchmenu.aspx", false);
                        break;
                    case "grades":
                        Response.Redirect("grades.aspx", false);
                        break;
                    case "booksearch":
                        Response.Redirect("booksearch.aspx", false);
                        break;
                }
            }
        }
    }
}