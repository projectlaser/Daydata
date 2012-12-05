using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace DayData.config.handlers.instances
{
    public class ProtectionHandler 
    {
        public static ProtectionHandler create()
        {
            return new ProtectionHandler();
        }
        public ProtectionHandler()
        {
            Debug.WriteLine("projectlaser: protection handler started");
        }
        public bool applicationLegit()
        {
            //we need to check their district ID and school ID, just once.
            return true;
        }
        public bool isApplicationEnabled()
        {
            return GlobalHandlers.DatabaseHandler.DayDataEnabled();
        }
        public bool isApplicationOK()
        {
            //TODO
            //we need to check once at startup to see if application is legit, to prevent fraud
            if (GlobalHandlers.DatabaseHandler.MySqlConnection.State != System.Data.ConnectionState.Open)
            {
                GlobalHandlers.DatabaseHandler.MySqlConnection.Open();
                if (GlobalHandlers.DatabaseHandler.MySqlConnection.State != System.Data.ConnectionState.Open)
                    return false;
                else if (GlobalHandlers.DatabaseHandler.MySqlConnection.State == System.Data.ConnectionState.Open)
                    return true;
                return false;
            }
            if (!GlobalHandlers.DatabaseHandler.DayDataEnabled())
            {
                return false;
            }

            return true;
        }
    }
}