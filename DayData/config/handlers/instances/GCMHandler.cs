using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DayData.config.handlers.instances
{
    //Google Cloud Messaging Handler
    public class GCMHandler
    {
        public static GCMHandler create()
        {
            return new GCMHandler();
        }
        public bool alert(TypeToAlert type)
        {
            return true;
        }
    }
    public enum TypeToAlert
    {
        Announcements, Events
    }
}