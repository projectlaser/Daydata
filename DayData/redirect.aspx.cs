using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DayData
{
    public partial class redirect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userAgent = Request.UserAgent;

        //    string thisUserAgent = Request.UserAgent'

            if (userAgent != null)
            {
                //check if android
                if (userAgent.ToLower().Contains("android"))
                {
                    //its android, redirect them to the android app
                    Response.Redirect("https://play.google.com/store/apps/details?id=projectlaser.tjhs&feature=search_result#?t=W251bGwsMSwxLDEsInByb2plY3RsYXNlci50amhzIl0", false);

                }
                else if (userAgent.ToLower().Contains("iPhone") || userAgent.ToLower().Contains("iPod") || userAgent.ToLower().Contains("iPad"))
                {
                    Response.Redirect("http://project-laser.com/tjhs/mobile/", false);
                }
                else
                {
                    Response.Redirect("http://project-laser.com/tjhs/mobile/", false);
                }
            }
        }
    }
}