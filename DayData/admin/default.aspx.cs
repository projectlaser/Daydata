using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DayData.config;
using System.Drawing;
using DayData.config.handlers.timers;
using Quartz;

namespace DayData.admin
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
                if (Request.Form["editfield"] != null)
                {
                    string text = Request.Form["editfield"].ToString();

                    if (text.StartsWith("updateNow"))
                    {
                        string returning = text.Replace("updateNow(", "");
                        returning = returning.Replace(")", "");
                        updateNow(returning);
                    }
                    else if (text.StartsWith("deleteNow"))
                    {
                        string returning = text.Replace("deleteNow(", "");
                        returning = returning.Replace(")", "");
                        deleteNow(returning);
                    }
                    else if (text == "shutoff")
                    {
                        //requesting emergency shutoff
                        emergencyShutoff();
                    }
                }
            }
            SchoolName.Text = GlobalHandlers.DatabaseHandler.globalInformation.School_Name;
            DistrictName.Text = GlobalHandlers.DatabaseHandler.globalInformation.District_Name;
            schoolID.Text = GlobalHandlers.DatabaseHandler.globalInformation.School_ID;
            DistrictID.Text = GlobalHandlers.DatabaseHandler.globalInformation.District_ID;
            ColorLabel.Text = GlobalHandlers.DatabaseHandler.globalInformation.Color;
            ColorLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml(GlobalHandlers.DatabaseHandler.globalInformation.Color);
            version.Text = ConstantManager.Total_Version.ToString();
            SecondColorLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml(GlobalHandlers.DatabaseHandler.globalInformation.SecondColor);
            SecondColorLabel.Text = GlobalHandlers.DatabaseHandler.globalInformation.SecondColor;
            string markup = @"<tr><td>?type</td><td>?how</td><td>?when</td><td>?lastUpdate</td></tr>";

            Updater updater = GlobalHandlers.DatabaseHandler.getUpdater(config.handlers.instances.ViewerHandler.Feature.ANNOUNCEMENTS);
            if (updater == null)
            {
                panelUpdaters.Controls.Add(new LiteralControl("<tr><td>No announcement updater found</td></tr>"));
            }
            else
            {
                string toAdd = markup.Replace("?id", updater.ID);
                toAdd = toAdd.Replace("?type", getTypeById(updater.Feature_Id));
                toAdd = toAdd.Replace("?how", getTypeIdName(updater.Type_Id, config.handlers.instances.ViewerHandler.Feature.ANNOUNCEMENTS));
                toAdd = toAdd.Replace("?when", getFormattedWhen(updater.Type));
                toAdd = toAdd.Replace("?lastUpdate", Updates.NextTimeUpdate_Announcements.ToString("U").Replace("Z", ""));
                panelUpdaters.Controls.Add(new LiteralControl(toAdd));
            }

            Updater eventUpdater = GlobalHandlers.DatabaseHandler.getUpdater(config.handlers.instances.ViewerHandler.Feature.EVENTS);
            if (eventUpdater == null)
            {
                panelUpdaters.Controls.Add(new LiteralControl("<tr><td>No event updater found</td></tr>"));
            }
            else
            {
                string toAdde = markup.Replace("?id", eventUpdater.ID);
                toAdde = toAdde.Replace("?type", getTypeById(eventUpdater.Feature_Id));
                toAdde = toAdde.Replace("?when", getFormattedWhen(eventUpdater.Type));
                toAdde = toAdde.Replace("?how", getTypeIdName(updater.Type_Id, config.handlers.instances.ViewerHandler.Feature.EVENTS));
                toAdde = toAdde.Replace("?lastUpdate", Updates.NextTimeUpdate_Events.ToString("U").Replace("Z", ""));
                panelUpdaters.Controls.Add(new LiteralControl(toAdde));
            }
            form.Style.Clear();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/admin/pub/pages/settings/announcements.aspx");
        }

        public void updateNow(string id)
        {
            GlobalHandlers.Debugger.write("update now: " + id);
            //this sent a request to update the current whatever ID of the updater
            //GlobalHandlers.TimerHandlers.getScheduler().TriggerJob(new JobKey("announcements", "main"));
        }
        public void deleteNow(string id)
        {
            GlobalHandlers.Debugger.write("delete now: " + id);
            string type = GlobalHandlers.DatabaseHandler.getTypeById(id);
            GlobalHandlers.Debugger.write("we are deleting: " + type);
            GlobalHandlers.TimerHandlers.getScheduler().DeleteJob(new JobKey(type.ToLower(), "main"));
            
        }

        public string getFormattedWhen(string when)
        {
            if (when == "1")
            {
                //every hour of every day
                return "Every hour of Every day";
            }
            else if (when == "5")
            {
                return "Every five hours of Every Day";
            }
            else if (when.StartsWith("24:"))
            {
                string time = when.Replace("24:", "");
                return "Every day at " + time + ":00 AM";
            }
            else
            {
                return "Unknown Time";
            }
        }
        public string getTypeById(string id)
        {
            if (id == "0")
            {
                return "Announcements";
            }
            else if (id == "1")
            {
                return "Events";
            }
            return "Unknown";
        }
        public string getTypeIdName(string d, DayData.config.handlers.instances.ViewerHandler.Feature f)
        {
            if (f == config.handlers.instances.ViewerHandler.Feature.ANNOUNCEMENTS)
            {
                if (d == "0")
                {
                    return "Google Docs";
                }
                else if (d == "1")
                {
                    return "HTML Page";
                }
                else if (d == "2")
                {
                    return "Email/DOCX";
                }
            }
            else if (f == config.handlers.instances.ViewerHandler.Feature.EVENTS)
            {
                if (d == "0")
                {
                    return "Missouri River";
                }
                else if (d == "1")
                {
                    return "HTML Page";
                }
                else if (d == "2")
                {
                    return "Manually";
                }
            }
            return "Unknown";
        }
        public void emergencyShutoff()
        {
            GlobalHandlers.DatabaseHandler.setEnabled(false);
            GlobalHandlers.Debugger.write("Shutoff DayData");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}