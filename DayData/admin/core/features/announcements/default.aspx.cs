using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DayData.config;
using DayData.admin.pub.json.instances;
using System.Diagnostics;

namespace DayData.admin.core.features.announcements
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
            if (IsPostBack)
            {
                string returnX = Request.Form["editButton"];
                string returnChecked = Request.Form["checkedBoxStatus"];
                if (returnX.Contains("TRUE"))
                {
                    string x = returnX.Replace("TRUE", "");
                    string id = x;
                    Debug.WriteLine("Edit Button Clicked to Edit Announcement: " + id);
                    editAnnouncement(id);
                }
                if (returnChecked.Contains("CHECKED"))
                {
                    string d = returnChecked.Replace("CHECKED", "");
                   string type = StringHelper.GetStringInBetween(d, "(", ")", false, false)[0];
                    Debug.WriteLine("Type is: " + type + " Left: " + d);
                }
            }
            else
            {
                if (Response.Cookies["edited"] != null)
                {
                    string t = Response.Cookies["edited"].Value;
                    addNotification("Successfully edited " + t + ".", NotificationType.Successful);
                    Response.Cookies["edited"].Expires = DateTime.Now.AddDays(-1d);

                }
                if (Session["setup"] != null)
                {
                    if (Session["setup"].ToString() == "True")
                        addNotification("An automatic announcement updater has been set up.", NotificationType.Successful);
                }
                loadAnnouncements();
            }
            if (GlobalHandlers.DatabaseHandler.announcementUpdaterAlreadyExists())
            {
                updater_status.Controls.Add(new LiteralControl(@"You already have an automatic updater setup - view it's settings <a href=""#"">here</a>."));
            }
            else
            {
                updater_status.Controls.Add(new LiteralControl(@"An auto-updater for the Announcements has not been set up. <a href=""setup.aspx"">Set one up</a>"));
            }
            
        }
        public void editAnnouncement(string id)
        {

        }
        public void loadAnnouncements()
        {
            string markup = @"<tr><td>?lockmarkup</td><td>?title</td><td>?content</td><td>";
            string editmarkup = @"<a id=""edit?id"" class=""button plain"" announcementid=""?id"" href=""editannouncement.aspx?text=?content&id=?id&title=?title&locked=?lockedstatus"">Edit</a>";
            string deletemarkup = @"<a id=""delete?id"" class=""button danger"" announcementid=""?id"" style=""cursor: pointer"" onclick=""popItUp(?id);"">Delete</a>";
            string noTitleMarkup = @"<tr><td class=""notitle"">(no title)</td><td>?content</td><td>";
            string lockMarkup = @"<a id=""lock?id"" class=""?lockedstatus tooltip"" title=""?lockedstatus"" announcementid=""?id""><div class=""?lockedstatus""></div></a>";
            string toReturn, toReturnEdit, toReturnDelete, toReturnLockMarkup = string.Empty;

            for (int index = announcements.Controls.Count - 1; index >= 0; index--)
                announcements.Controls.RemoveAt(index);

            foreach (Announcement a in GlobalHandlers.DatabaseHandler.getAnnouncements())
            {
                if (a.Title.Length == 0)
                {
                    toReturn = noTitleMarkup.Replace("?content", a.Text);
                }
                else
                {
                    toReturn = markup.Replace("?title", a.Title);
                    toReturn = toReturn.Replace("?content", a.Text);
                }
                toReturnLockMarkup = lockMarkup.Replace("?id", a.ID.ToString());
                if (a.locked)
                {
                    toReturnLockMarkup = toReturnLockMarkup.Replace("?lockedstatus", "Locked");
                }
                else if (a.locked == false)
                {
                    toReturnLockMarkup = toReturnLockMarkup.Replace("?lockedstatus", "Unlocked");
                }
                toReturn = toReturn.Replace("?lockmarkup", toReturnLockMarkup);

                announcements.Controls.Add(new LiteralControl(toReturn));


                string encodedTitle = Server.UrlEncode(a.Title);
                string encodedText = Server.UrlEncode(a.Text);

                toReturnEdit = editmarkup.Replace("?id", a.ID.ToString());
                toReturnEdit = toReturnEdit.Replace("?title", encodedTitle);
                toReturnEdit = toReturnEdit.Replace("?content", encodedText);
                toReturnEdit = toReturnEdit.Replace("?lockedstatus", a.locked.ToString());

                toReturnDelete = deletemarkup.Replace("?id", a.ID.ToString());
               
                announcements.Controls.Add(new LiteralControl(toReturnEdit));
                announcements.Controls.Add(new LiteralControl(toReturnDelete));
                announcements.Controls.Add(new LiteralControl("</td></tr>"));
               
            }
        }
        public string HtmlEncode(string s)
        {
            return HttpUtility.HtmlEncode(s);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string title = TextBox1.Text;
            string content = TextBox2.Text;
            if (title.Length == 0)
            {
                title = "(no title)";
            }
            if (title.Length > 25)
            {
                addNotification("Error: Your title is too long!", NotificationType.Error);
                return;
            }
            if (content.Length > 200)
            {
                addNotification("Error: Your content is too long!", NotificationType.Error);
                return;
            }
            NotificationType t = GlobalHandlers.DatabaseHandler.addAnnouncement(title, content, CheckBox1.Checked);
            if (t == NotificationType.Successful) 
            {
                
                addNotification("Added " + title + " successfully!", t);
                TextBox1.Text = "";
                TextBox2.Text = "";
                loadAnnouncements();
            }
            else if(t== NotificationType.Error)
            {
                addNotification("Failed to add " + title + " try again!", t);
            }
           // Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "success", "notification('Success notification')");
        }
        public void addNotification(string text, NotificationType t)
        {
            string markup = @"<div class=""notification ?type"">" + @"<span class=""icon""></span>"+"?text"+@"<a href=""#"" class=""close"">x</a></div>";
            string toReturn = String.Empty;
            switch (t)
            {
                case NotificationType.Successful:
                    markup = markup.Replace("?type", "success");
                    markup = markup.Replace("?text", text);
                    break;
                case NotificationType.Warning:
                    markup = markup.Replace("?type", "warning");
                    markup = markup.Replace("?text", text);
                    break;
                case NotificationType.Error:
                    markup = markup.Replace("?type", "error");
                    markup = markup.Replace("?text", text);
                    break;
            }
            notifcation_panel.Controls.Add(new LiteralControl(markup));
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //edit
            Debug.WriteLine("edit activated");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            //delete
            if (sender is LinkButton)
            {
                //attr is:
                LinkButton d = (LinkButton)sender;
                string attr = d.ID;
                Debug.WriteLine("Lets delete: " + attr);
            }
            Debug.WriteLine("delete activated from: " + sender);

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void desktopViewer_CheckedChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("Desktop viewer changed");
        }

        protected void mobileViewer_CheckedChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("mobile changed");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("CHanged - LEts update them");
        }
    }
    public enum NotificationType {
        Successful, Error, Warning
    }
}