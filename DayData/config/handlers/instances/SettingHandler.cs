using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Diagnostics;

namespace DayData.config.handlers.instances
{
    public class SettingHandler : Handler
    {
        public Dictionary<string, string> Settings;
        public static SettingHandler create()
        {
            return new SettingHandler();
        }
        public string MySQL_Connection_String
        {
            get
            { 
                return ConfigurationManager.AppSettings["mysqlConnectionString"];
            }
        }
        public void setup()
        {
            Settings = GlobalHandlers.DatabaseHandler.getSettings();
            Debug.WriteLine("Total in settings: " + Settings.Keys);
        }
        public SettingHandler()
        {

        }
        public string getMySQLConnectionString()
        {
            return MySQL_Connection_String;
        }
    }
}