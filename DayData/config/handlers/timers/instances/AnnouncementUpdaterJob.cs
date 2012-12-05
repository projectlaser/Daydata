using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using System.Diagnostics;
using DayData.admin.core.features.announcements.classes;

namespace DayData.config.handlers.timers.instances
{
    public class AnnouncementUpdaterJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            try
            {
                doWork();
            }
            catch (Exception eee)
            {
                GlobalHandlers.Debugger.write(eee.ToString());
            }
            Updates.NextTimeUpdate_Announcements = TimerHandlers.convertUTC(context.NextFireTimeUtc.ToString()); // next time updates
            GlobalHandlers.Debugger.write("Executing Announcement Updater Job: Next: " + TimerHandlers.convertUTC(context.NextFireTimeUtc.ToString()).ToString());
        }
        public void doWork()
        {
            if (GlobalHandlers.DatabaseHandler.deleteAnnouncementsOnUpdate() == true)
            {
                bool f= GlobalHandlers.DatabaseHandler.deleteAnnouncements(false);
                if (f == true)
                {
                    Updater d = GlobalHandlers.DatabaseHandler.getUpdater(handlers.instances.ViewerHandler.Feature.ANNOUNCEMENTS);
                    List<string> st = GoogleDocsHandler.downloadFileGetList(d.Link);
                    bool t = GlobalHandlers.DatabaseHandler.setupAnnouncements(st);
                    if (t == true)
                    {
                        GlobalHandlers.Debugger.write("Updated announcements at: " + DateTime.Now.ToString());
                        Updates.LastUpdated_Announcements = DateTime.Now;
                    }
                }
            }
        }
    }
}