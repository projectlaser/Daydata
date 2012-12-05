using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DayData.config;
using DayData.admin.pub.json.instances;
using Cliver;
using System.Diagnostics;
using System.Web.Script.Serialization;

namespace DayData.required.json
{
    /// <summary>
    /// Summary description for EventJson
    /// </summary>
    public class EventJson : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            string jsonReturn = String.Empty;

            jsonReturn += "[";

            foreach (Event d in GlobalHandlers.DatabaseHandler.getEvents(false))
            {
                jsonReturn += getEventJsonFromEvent(d);
                //idList.Add(cevent.id);
            }
            Debug.WriteLine(jsonReturn);
            if (jsonReturn.EndsWith(","))
            {
                jsonReturn = jsonReturn.Substring(0, jsonReturn.Length - 1);
                Debug.WriteLine("activated with a ,");
            }

            jsonReturn += "]";
            context.Response.Write(jsonReturn);
        }
        public string getEventJsonFromEvent(Event d)
        {
            eventjson jsonEvent = new eventjson();
            jsonEvent.title = d.Title;
            jsonEvent.id = d.ID;
            jsonEvent.description = d.Description;

            bool allDay = false;
            DateTime start = new DateTime(2012, 7, 18, 20, 25, 26, 0);
            DateTime end = new DateTime(2012, 7, 18, 20, 26, 26, 0);
            bool noEnd = false;
            if (d.Time == "allday")
            {
                allDay = true;
            }
            else
            {
                //is not all day, parse the times.
                try
                {
                    if (!d.Time.Contains("-"))
                    {
                        //its only the start
                        //then lets just parse the start.
                        noEnd = true;
                        end = getTime(d.Time, d.Date);
                        jsonEvent.setEndTime(end);
                     //   jsonEvent.end = end;
                    }
                    string[] splitted = d.Time.Split(char.Parse("-"));
                    if (splitted.Length == 2)
                    {
                        string firstTime = splitted[0];
                        start = getTime(firstTime, d.Date);
                        string endTime = splitted[1];
                        end = getTime(endTime, d.Date);
                        jsonEvent.setEndTime(end);
                        jsonEvent.setStartTime(start);
                    }

                }
                catch (Exception ee)
                {
                    Debug.WriteLine(ee);
                }
            }
            if (noEnd)
            {
                return "";
                //jsonEvent.end = jsonEvent.start;
            }
            else
            {
                var serializer = new JavaScriptSerializer();
                return serializer.Serialize(jsonEvent) + ",";
                //Response.Write(serializer.Serialize(list));
            }
        }
        public DateTime getTime(string time, string date)
        {
            DateTime toReturn;
            if(DateTimeRoutines.TryParseDateTime(date+" "+time, DateTimeRoutines.DateTimeFormat.USA_DATE, out toReturn))
            {
                //this equals true..
                return toReturn;
            }
            return new DateTime(2012, 7, 18, 20, 25, 26, 0);
        }
        private long ConvertToTimestamp(DateTime value)
        {

            Debug.WriteLine("converting: " + value);
            long epoch = (value.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
            return epoch;

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}