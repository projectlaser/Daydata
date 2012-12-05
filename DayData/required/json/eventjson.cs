using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DayData.required.json
{
    public class eventjson
    {
        public string title { get; set; }
        public string id { get; set; }
        public string start
        {
            get
            {
                return ConvertToTimestamp(startTime).ToString();
                //return startTime.ToString("u").Replace("Z", "");
            }
        }
        private DateTime startTime;
        private DateTime endTime;
        public string end
        {
            get
            {
                return ConvertToTimestamp(endTime).ToString();
                return endTime.ToString("u").Replace("Z", "");
            }
        }
        public bool allDay { get; set; }
        public string description { get; set; }

        public void setStartTime(DateTime start)
        {
            startTime = start;
        }
        public void setEndTime(DateTime endT)
        {
            endTime = endT;
        }
        private long ConvertToTimestamp(DateTime value)
        {

            //Debug.WriteLine("converting: " + value);
            long epoch = (value.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
            return epoch;

        }
    }


}