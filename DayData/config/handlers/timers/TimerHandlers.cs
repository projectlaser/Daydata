using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;
using Quartz.Core;
using DayData.config.handlers.timers.instances;
using System.Diagnostics;

namespace DayData.config.handlers.timers
{
    public class TimerHandlers
    {
        public Updater announcement_updater;
        public Updater event_updater;

        private static IScheduler _scheduler;
        public static TimerHandlers create()
        {
            return new TimerHandlers();
        }
        public IScheduler getScheduler()
        {
            return _scheduler;
        }
        public TimerHandlers()
        {
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            _scheduler = schedulerFactory.GetScheduler();

            _scheduler.Start();
            GlobalHandlers.Debugger.write("Started Scheduler Factory");
        }
        public void startAllTimers()
        {
            startAnnouncementTimers();
            startEventTimers();
        }
        public void startAnnouncementTimers()
        {
            Updater d = GlobalHandlers.DatabaseHandler.getUpdater(handlers.instances.ViewerHandler.Feature.ANNOUNCEMENTS);
            string timeSelection = d.Type;
            Update_Times updateTimes;
            string mayBeUnused = string.Empty;
            string cron = string.Empty;
            if (timeSelection == "1")
            {
                //every hour.
                updateTimes = Update_Times.Every_Hour;
                cron = "0 0/60 * ? * MON-FRI";
            }
            else if (timeSelection == "5")
            {
                updateTimes = Update_Times.Every_Five_Hours;
                cron = "0 * 0/5 ? * MON-FRI";
            }
            else if (timeSelection.StartsWith("24:"))
            {
                string timeAt = timeSelection.Replace("24:", "");
                mayBeUnused = timeAt;
                updateTimes = Update_Times.Every_24_Hours;
                cron = "0 0 " + mayBeUnused + " ? * MON-FRI";
            }
            IJobDetail job = JobBuilder.Create<AnnouncementUpdaterJob>().WithIdentity("announcements", "main").Build();
            CronScheduleBuilder builder = CronScheduleBuilder.CronSchedule(cron);
            builder.Build();
            ITrigger trigger = TriggerBuilder.Create().
                WithIdentity("announcements").
                StartNow()
                .WithSchedule(builder).Build();
            _scheduler.ScheduleJob(job, trigger);
            Debug.WriteLine("Announcements trigger and job setup. Next Fire: " + convertUTC(trigger.GetNextFireTimeUtc().ToString()));
            Updates.NextTimeUpdate_Announcements = convertUTC(trigger.GetNextFireTimeUtc().ToString());
        }
        public void startEventTimers()
        {
            Updater updater = GlobalHandlers.DatabaseHandler.getUpdater(handlers.instances.ViewerHandler.Feature.EVENTS);
            if (updater == null)
            {
                //no updater found
                GlobalHandlers.Debugger.write("There is no event updater setup.");
                return;
            }
            string timeSelection = updater.Type;
            Update_Times updateTimes;
            string mayBeUnused = String.Empty;
            string cronJob = String.Empty;

            if (timeSelection == "1")
            {
                updateTimes = Update_Times.Every_24_Hours;
                cronJob = "0 0 8 ? * *";
            }
            IJobDetail job = JobBuilder.Create<EventsUpdaterJob>().WithIdentity("events", "main").Build();
            CronScheduleBuilder builder = CronScheduleBuilder.CronSchedule(cronJob);
            builder.Build();
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("events")
                .StartNow()
                .WithSchedule(builder).Build();
            _scheduler.ScheduleJob(job, trigger);
            Updates.NextTimeUpdate_Events = convertUTC(trigger.GetNextFireTimeUtc().ToString());
            GlobalHandlers.Debugger.write("Events trigger and job setup. Next fire is at: " + convertUTC(trigger.GetNextFireTimeUtc().ToString()));


        }
        public static DateTime convertUTC(string utc)
        {
            DateTime convertDate = DateTime.SpecifyKind(DateTime.Parse(utc), DateTimeKind.Utc);
            return convertDate;
        }
        public static DateTime getCentralTime(DateTime t)
        {
            try
            {
                TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
                DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(t, cstZone);
                return cstTime;
            }
            catch (TimeZoneNotFoundException)
            {
                Console.WriteLine("The registry does not define the Central Standard Time zone.");
            }
            catch (InvalidTimeZoneException)
            {
                Console.WriteLine("Registry data on the Central STandard Time zone has been corrupted.");
            }
            catch (Exception ee)
            {
                return t;
            }
            return t;
        }
    }
    public enum Update_Times
    {
        Every_Hour, Every_Five_Hours, Every_24_Hours


    }
}