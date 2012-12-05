using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DayData.config;
using System.IO;

namespace DayData.admin
{
    public partial class logs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!GlobalHandlers.SessionHandler.isLoggedIn())
            {
                Response.Redirect("~/admin/login/default.aspx", false);
                return;
            }
            string markup = "<tr><td>?title</td><td><strong>?content</strong></td></tr>";
            try
            {
                
                using (StreamReader sr = new StreamReader("../core/controls/File.ashx?FileName=Debug.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string toAdd = markup;
                        toAdd = toAdd.Replace("?title", "");
                        toAdd = toAdd.Replace("?content", line);
                        body.Controls.Add(new LiteralControl(toAdd));
                    }
                }
            }
            catch (Exception eee)
            {
                GlobalHandlers.Debugger.write(eee.ToString());
            }
        }
    }
}