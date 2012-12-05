using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DayData.config.handlers.instances.item;
using System.Diagnostics;

namespace DayData.config.handlers.instances
{
    public class SessionHandler : Handler
    {
        public List<SessionItem> Session_List;
        public static SessionHandler create()
        {
            return new SessionHandler();
        }
        public SessionHandler()
        {
            Session_List = new List<SessionItem>();
            Debug.WriteLine("Created session list.");
        }
        public bool addToList(SessionItem sess)
        {
            Session_List.Add(sess);
            return true;
        }
        public bool removeFromList(string sessionId)
        {
            foreach (SessionItem it in Session_List)
            {
                if (it.getSession().SessionID.Equals(sessionId))
                {
                    Session_List.Remove(it);
                    return true;
                }
            }
            GlobalHandlers.DatabaseHandler.removeSessionFromDatabase(sessionId);
            return false;
        }
        public SessionItem getSessionById(string id, List<SessionItem> list)
        {
            try
            {
                foreach (SessionItem s in list)
                {
                    if (s.getSession().SessionID.Equals(id))
                        return s;
                }
            }
            catch (Exception eee)
            {

            }
            return null;
        }
        public bool logout()
        {
            try
            {
                HttpContext.Current.Session["username"] = null;
                string sesId = HttpContext.Current.Session.SessionID;
                HttpContext.Current.Session["ipaddress"] = null;
                GlobalHandlers.DatabaseHandler.removeSessionFromDatabase(sesId);
                HttpContext.Current.Session.Abandon();
                return true;
            }
            catch (Exception eee)
            {
                GlobalHandlers.Debugger.write(eee.ToString());
            }
            return false;
        }
        public void handleLoginCookies(string usernamxe)
        {
            string ipAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            string sessionId = HttpContext.Current.Session.SessionID;
            string username = usernamxe;
            string rank;
            
            HttpContext.Current.Session.Add("ipaddress", ipAddress);
            HttpContext.Current.Session.Add("username", username);
            GlobalHandlers.DatabaseHandler.sessionToDatabase(getSessionById(sessionId, GlobalHandlers.SessionHandler.Session_List));
            Debug.WriteLine("SessionID:[" + sessionId + "] IP Address:[" + ipAddress + "] User:[" + username + "]");
        }
        public bool isLoggedIn()
        {
            bool soFar = true;
            string userOnSession = "";
            if(HttpContext.Current.Session["username"] != null)
                userOnSession = HttpContext.Current.Session["username"].ToString();

            if (userOnSession.Equals(String.Empty) || userOnSession.Equals(""))
            {
                soFar = false;
                return false;
            }
            if (HttpContext.Current.Session["ipaddress"] == "")
                return false;
            return soFar;
        }
    }
}