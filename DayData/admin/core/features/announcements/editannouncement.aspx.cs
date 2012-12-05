using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DayData.config;
using DayData.admin.pub.json.instances;

namespace DayData.admin.core.features.announcements
{
    public partial class editannouncement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!GlobalHandlers.SessionHandler.isLoggedIn())
            {
                Response.Redirect("~/admin/login/default.aspx", false);
                return;
            }
            if (IsPostBack)
            {
                return;
            }
            string str = Request.QueryString["text"];
            if (str != null)
            {
                string title = Request.QueryString["title"];
                string id = Request.QueryString["id"];
                bool outBool = false;
                Boolean.TryParse(Request.QueryString["locked"], out outBool);
                announcementText.Text = str.HtmlDecode();
                announcemenTitle.Text = title.HtmlDecode();
                announcementLocked.Checked = outBool;
                idOfAnnouncement.Value = id;
            }

        }

        protected void editButton_Click(object sender, EventArgs e)
        {
            try
            {
                Announcement a = new Announcement();
                a.Title = announcemenTitle.Text;
                a.Text = announcementText.Text;
                a.locked = announcementLocked.Checked;

                GlobalHandlers.Debugger.write("text: " + a.Text);
                
                int outParse = 0;
                Int32.TryParse(idOfAnnouncement.Value, out outParse);
                a.ID = outParse;

                GlobalHandlers.Debugger.write("Announcement title: " + a.Title + " Text: " + a.Text + " Id: " + a.ID);
                bool isUpdated = GlobalHandlers.DatabaseHandler.updateAnnouncement(a);
                if (isUpdated)
                {
                    Response.AppendCookie(new HttpCookie("edited", a.Title));
                    
                    Response.Redirect("default.aspx", false);
                }
            }
            catch (Exception ee)
            {
                GlobalHandlers.Debugger.write(ee.ToString());
            }
        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {

        }
    }
    public static class Extensions
    {
        public static string HtmlEncode(this string s)
        {
            return HttpUtility.HtmlEncode(s);
        }
        public static string HtmlDecode(this string s)
        {
            return HttpUtility.HtmlDecode(s);
        }
    }
    public static class Holder
    {
        public static String Title;
        public static String Text;
        public static String Id;
        public static Boolean Locked;
    }
}