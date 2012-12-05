using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Diagnostics;
using DayData.config;
using DayData.config.handlers.instances;
using MySql.Data.MySqlClient;
using DayData.config.handlers.timers;
using DayData.admin.core.features.events.handlers.Updaters;
using DayData.config.handlers.tiles;
using DayData.admin.pub.json.instances;
using DayData.admin.core.features.announcements.classes;

namespace DayData
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalHandlers.DatabaseHandler = DatabaseHandler.create(config.handlers.instances.Type.MySQL);
            GlobalHandlers.SessionHandler = SessionHandler.create();
            GlobalHandlers.SettingHandler = SettingHandler.create();
            GlobalHandlers.ProtectionHandler = ProtectionHandler.create();
            GlobalHandlers.Debugger = GlobalDebugger.create();
            GlobalHandlers.TimerHandlers = TimerHandlers.create();
            GlobalHandlers.ViewerHandler = ViewerHandler.create();

            if (GlobalHandlers.DatabaseHandler.connect())
            {
                Debug.WriteLine("[DatabaseHandler]: Database connected successfully");
            }
            else
            {
                Debug.WriteLine("[DatabaseHandler]: Database failed to connect");
                GlobalHandlers.Debugger.write("Database failed to connect");
            }
            GlobalHandlers.DatabaseHandler.fillGlobalInformation();
            GlobalHandlers.ViewerHandler.populateList(GlobalHandlers.DatabaseHandler.getViewers());
            GlobalHandlers.TimerHandlers.startAllTimers();
            GlobalHandlers.SettingHandler.setup();
            GlobalHandlers.TileManager = TileManager.create();
            GlobalHandlers.GCMHandler = GCMHandler.create();
            GlobalHandlers.PowerschoolHandler = new config.handlers.features.powerschool.PowerschoolLoginHandler();
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            GlobalHandlers.SessionHandler.addToList(new config.handlers.instances.item.SessionItem(Session));
            Debug.WriteLine("[SessionHandler]: New Session Created: [" + HttpContext.Current.Session.SessionID + "]: Total:[" + GlobalHandlers.SessionHandler.Session_List.Count + "] At: [" + DateTime.Now.ToString("u").Replace("Z", "")+ "]");
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }
        protected void Application_PreSendContent(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            GlobalHandlers.SessionHandler.removeFromList(Session.SessionID);
            Debug.WriteLine("[SessionHandler]: Session Deleted: [" + Session.SessionID + "]");
        }

        protected void Application_End(object sender, EventArgs e)
        {
            GlobalHandlers.DatabaseHandler.removeAllSessionsFromDatabase();
            GlobalHandlers.DatabaseHandler.MySqlConnection.Close();
        }
    }
}