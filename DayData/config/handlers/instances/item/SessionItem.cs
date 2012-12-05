using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace DayData.config.handlers.instances.item
{
    public class SessionItem
    {
        HttpSessionState session;
        public SessionItem(HttpSessionState ses)
        {
            session = ses;
        }
        public HttpSessionState getSession()
        {
            return session;
        }
    }
}