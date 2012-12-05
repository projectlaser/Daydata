using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.IO;
using System.Diagnostics;

namespace DayData.config
{
    public class GlobalDebugger
    {
        public static GlobalDebugger create()
        {
            return new GlobalDebugger();
        }
        public GlobalDebugger()
        {

        }
        public bool write(string toWrite)
        {
            //this is going to write to a debugging file
            try
            {
                String file = HostingEnvironment.MapPath(@"/App_Data/Debug.txt");
                FileStream fs = new FileStream(file, FileMode.Append);
                StreamWriter writer = new StreamWriter(fs);
                string dateTime = "[" + DateTime.Now.ToString("G") + "]";
                writer.WriteLine(dateTime + ":[DAYDATA]: " + toWrite);
                Debug.WriteLine(dateTime + ":[DAYDATA]: " + toWrite);
                writer.Close();
                fs.Close();
                return true;
            }
            catch (Exception exp)
            {
                Debug.WriteLine(exp);
                return false;
            }
        }
    }
}