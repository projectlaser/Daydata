using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DayData.config;
using Cliver;
using System.Globalization;

namespace DayData.desktop.features
{
    public partial class lunchmenu : System.Web.UI.Page
    {
        string loadDate = String.Empty;
        bool loadToday = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            string loadNumber = String.Empty;
            ListItem forSelected = null;
            try
            {
                if (Request.QueryString["date"] != null)
                {
                    string date = Request.QueryString["date"].ToString();
                    string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month);
                    string toset = monthName + " " + date + " " + DateTime.Now.Year;
                    loadNumber = date;
                    date = toset;
                    loadDate = date;
                    loadToday = false;
                    DateTime n = new DateTime(DateTime.Now.Year, DateTime.Now.Month, Int32.Parse(loadNumber));
                    forSelected = new ListItem(n.DayOfWeek.ToString() + ", " + monthName + " " + n.Day, n.Day + "");

                }
            }
            catch (Exception eee)
            {
                GlobalHandlers.Debugger.write(eee.ToString());
            }

            setupDefaultHeader();
            if (loadToday)
            {
                Date.Text = "Lunch menu for: " + DateTime.Now.ToString("dddd, MMMMM d");
                if (DateTime.Now.isWeekday())
                {

                    string[] lunchItems = GlobalHandlers.DatabaseHandler.getListOfItemsForToday();

                    if (lunchItems == null)
                    {
                        panel.Controls.Add(new LiteralControl("<tr><td>No information</td></tr>"));
                        return;
                    }

                    foreach (string item in lunchItems)
                    {
                        panel.Controls.Add(new LiteralControl("<tr><td>" + item + "</td></tr>"));
                    }
                }
                else
                {
                    panel.Controls.Add(new LiteralControl("<tr><td>No information</td></tr>"));
                }
            }
            else if(!loadToday)
            {
                DateTime d;
                DateTimeRoutines.TryParseDate(loadDate, DateTimeRoutines.DateTimeFormat.USA_DATE, out d);
                GlobalHandlers.Debugger.write("getting this far loadDate:"+loadDate);
                if (d == null)
                {
                    panel.Controls.Add(new LiteralControl("<tr><td>No information</td></tr>"));
                    return;
                }
                Date.Text = "Lunch menu for: " + d.ToString("dddd, MMMMM d");
                if (d.isWeekday())
                {

                    string[] lunchItems = GlobalHandlers.DatabaseHandler.getListOfItemsForADay(loadNumber);
                    if (lunchItems == null)
                    {
                        panel.Controls.Add(new LiteralControl("<tr><td>No information</td></tr>"));
                        return;
                    }

                    foreach (string item in lunchItems)
                    {
                        panel.Controls.Add(new LiteralControl("<tr><td>" + item + "</td></tr>"));
                    }
                }
                else
                {
                    panel.Controls.Add(new LiteralControl("<tr><td>No information</td></tr>"));
                }
            }
            foreach (DateTime day in AllDatesInMonth(DateTime.Now.Year, DateTime.Now.Month))
            {
                if (day.isWeekday() &&  day >= DateTime.Now)
                {
                    combo.Items.Add(new ListItem(day.DayOfWeek.ToString() + ", "+DateTime.Now.ToString("MMMM") +" "+ day.Day, day.Day + ""));
                }
            }
            combo.SelectedIndex = combo.Items.IndexOf(forSelected);
        }
        public static IEnumerable<DateTime> AllDatesInMonth(int year, int month)
        {
            int days = DateTime.DaysInMonth(year, month);
            for (int day = 1; day <= days; day++)
            {
                yield return new DateTime(year, month, day);
            }
        }
        public void setupDefaultHeader()
        {
            string name = "[ERROR]";
            GlobalHandlers.SettingHandler.Settings.TryGetValue("name", out name);
            this.Title = "Lunch Menu: " + name;
            name_label.Text = name;
            top_image.ImageUrl = "../../required/css/images/iconready.png";
            top_image.AlternateText = GlobalHandlers.DatabaseHandler.globalInformation.School_Name;
            top_image.Style.Add("max-height", "30px");
        }

        protected void combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            GlobalHandlers.Debugger.write("selected changed: " + combo.SelectedIndex);
        }
    }
    public static class Extensions
    {
        public static bool isWeekday(this DateTime date)
        {
            if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}