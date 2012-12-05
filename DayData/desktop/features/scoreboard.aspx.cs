﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DayData.config;

namespace DayData.desktop.features
{
    public partial class scoreboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            setupDefaultHeader();
        }
        public void setupDefaultHeader()
        {
            string name = "[ERROR]";
            GlobalHandlers.SettingHandler.Settings.TryGetValue("name", out name);
            this.Title = "Scoreboard: " + name;
            name_label.Text = name;
            top_image.ImageUrl = "../../required/css/images/iconready.png";
            top_image.AlternateText = GlobalHandlers.DatabaseHandler.globalInformation.School_Name;
            top_image.Style.Add("max-height", "30px");
        }
    }
}