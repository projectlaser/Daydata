using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DayData.config
{
    public class ConstantManager
    {
        #region version-constants
        public static string Version_Name = "Beta Release";
        public static int Main_Revision = 0;
        public static double Minor_Revision = 0.29;
        public static double Total_Version
        {
            get
            {
                return Main_Revision + Minor_Revision;
            }
        }
        #endregion
    }
}