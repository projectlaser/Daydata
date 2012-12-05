using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DayData.config;

namespace DayData.admin.core.settings
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, string> pair in GlobalHandlers.SettingHandler.Settings)
            {
                string markup = @"<tr><td>?key</td><td>?value</td></tr>";
                string toAdd = markup;
                toAdd = toAdd.Replace("?key", pair.Key);
                toAdd = toAdd.Replace("?value", pair.Value);
                panel.Controls.Add(new LiteralControl(toAdd));
            }
        }
    }
}