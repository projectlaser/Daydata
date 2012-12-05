using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DayData.config;

namespace DayData.mobile
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // GlobalHandlers.DatabaseHandler.getFeatureValue(
            string toSetTitle = String.Empty;
            GlobalHandlers.SettingHandler.Settings.TryGetValue("name", out toSetTitle);
            headerText.InnerText = toSetTitle;
            this.Title = toSetTitle;
        }
    }
}