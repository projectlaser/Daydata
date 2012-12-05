using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DayData.config.handlers.features.powerschool
{
    public class PowerschoolLoginHandler
    {
        public List<PSSession> powerschool_sessions;
        public PowerschoolLoginHandler()
        {
            powerschool_sessions = new List<PSSession>();
            GlobalHandlers.Debugger.write("Created powerschool session handlers");
        }
        public bool addToSessionList(PSSession ses)
        {
            powerschool_sessions.Add(ses);
            return true;
        }
        public PSSession getSessionBySessionID(string id)
        {
            foreach (PSSession ses in powerschool_sessions)
            {
                if (ses.getSession().SessionID.Equals(id))
                {
                    return ses;
                }
            }
            return null;
        }
        public bool removeFromSessionList(string sessionId)
        {
            foreach (PSSession ses in powerschool_sessions)
            {
                if (ses.getSession().SessionID.Equals(sessionId))
                {
                    powerschool_sessions.Remove(ses);
                    return true;
                }
            }
            return false;

        }
    }
}