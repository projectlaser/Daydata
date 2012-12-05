using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using System.Diagnostics;
using DayData.admin.pub.json.instances;
using DayData.admin.core.features.events.handlers.Updaters;

namespace DayData.config.handlers.timers.instances
{
    public class EventsUpdaterJob : IJob
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
            Updates.NextTimeUpdate_Events = TimerHandlers.convertUTC(context.NextFireTimeUtc.ToString());
            Debug.WriteLine("Updating the events next at: " + Updates.NextTimeUpdate_Events);
        }
        public void doWork()
        {
            Updater eventUpdater = GlobalHandlers.DatabaseHandler.getUpdater(handlers.instances.ViewerHandler.Feature.EVENTS);
            if (eventUpdater.Type_Id == "0")
            {
                List<Event> eventList = MissouriRiver.getEvents(eventUpdater.Link);
                GlobalHandlers.DatabaseHandler.updateEvents(eventList);
            }
        }
    }
}