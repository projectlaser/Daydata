using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DayData.config;
using DayData.config.handlers.tiles.class_id;
using System.Diagnostics;

namespace DayData.desktop
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!GlobalHandlers.ProtectionHandler.isApplicationOK())
            {
                tilePanel.Controls.Add(new LiteralControl(@"<p style=""color: white;"">DayData is currently disabled. Please try again soon.</p>"));
                Title = "DayData disabled. Please try again soon";
                //Response.Write("DayData is currently disabled. Please try again soon.");
                return;
            }
            string name = "[ERROR]";
            GlobalHandlers.SettingHandler.Settings.TryGetValue("name", out name);
            name_label.Text = name;
            namelabel2.Text = name;
            top_image.ImageUrl = "../required/css/images/iconready.png";
            top_image.AlternateText = GlobalHandlers.DatabaseHandler.globalInformation.School_Name;
            top_image.Style.Add("max-height", "30px");
            about.Style.Add("color", GlobalHandlers.DatabaseHandler.globalInformation.Color);
            loadTiles();
            
        }

        public void loadTiles()
        {
            foreach (Tile t in GlobalHandlers.TileManager.getTiles())
            {
                string markup = @"<a href=""?url"" data-role=""button"" data-transition=""slide""><div iconclasses=""?tileIconCss"" id=""?id"" unid=""?id"" url=""?url"" iconSrc=""?iconSrc"" class=""?tilecss""><div class=""?tileIconCss""><img alt=""?appTitle"" src=""?iconSrc"" /></div><div class=""tile-label"">?appTitle</div></div></a>";
                string toAdd = markup;
                if (t.name == "Weather")
                {
                    toAdd = @"<div id=""?id"" unid=""?id"" class=""tile double-horz ?colorStyle""><div id=""weatherImg"" class=""weatherImg""></div></div>";
                    toAdd = toAdd.Replace("?colorStyle", t.color);
                    tilePanel.Controls.Add(new LiteralControl(toAdd));
                }
                else
                {
                    toAdd = markup;
                    toAdd = toAdd.Replace("?tilecss", "tile " + t.size + " " + t.color);
                    toAdd = toAdd.Replace("?tileIconCss", t.iconSize);
                    toAdd = toAdd.Replace("?appTitle", t.appTitle);
                    toAdd = toAdd.Replace("?iconSrc", t.iconSrc);
                    toAdd = toAdd.Replace("?url", t.appUrl);
                    toAdd = toAdd.Replace("?id", t.unique_id);
                 //   Debug.WriteLine("title: " + t.appTitle + " : URL : " + t.appUrl);
                    tilePanel.Controls.Add(new LiteralControl(toAdd));
                }
            }
            Debug.WriteLine("Loaded tiles");
        }
    }
}