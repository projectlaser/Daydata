using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using DayData.config;
using DayData.config.handlers.instances;

namespace DayData.admin.login
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            submit.Text = @"Login";
            if (GlobalHandlers.SessionHandler.isLoggedIn())
            {
                if (Request.QueryString["set"] != null)
                {
                    string set = Request.QueryString["set"].ToString();
                    switch (set)
                    {
                        case "logout":
                            if (GlobalHandlers.SessionHandler.logout())
                            {
                                //if did logout
                                panel.Controls.Add(new LiteralControl(@"<p style=""color: #5AB953; font-size: large;"">You have been successfully logged out!</p>"));
                            }
                            break;
                    }
                }
                else
                {
                    Response.Redirect("~/admin/default.aspx", false);
                }
                return;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            string user = username.Value;
            string pass = password.Value;
            LoginResult res = GlobalHandlers.DatabaseHandler.login(user, pass);
            if (res == LoginResult.SUCCESSFUL)
            {
                GlobalHandlers.SessionHandler.handleLoginCookies(user);
                Response.Redirect("~/admin/default.aspx", false);
            }
            else if (res == LoginResult.UserDoesNotExist || res == LoginResult.PasswordIncorrect)
            {
                Debug.WriteLine("Incorrect password / user does not exist");

            }
        }
    }
}