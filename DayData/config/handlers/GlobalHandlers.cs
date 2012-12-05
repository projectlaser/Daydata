using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DayData.config.handlers.instances;
using DayData.config.handlers.timers;
using DayData.config.handlers.tiles;
using DayData.config.handlers.features.powerschool;

namespace DayData.config
{
    public class GlobalHandlers
    {
        public static DatabaseHandler DatabaseHandler { get; set; }
        public static SessionHandler SessionHandler { get; set; }
        public static SettingHandler SettingHandler { get; set; }
        public static ProtectionHandler ProtectionHandler { get; set; }
        public static GlobalDebugger Debugger { get; set; }
        public static TimerHandlers TimerHandlers { get; set; }
        public static ViewerHandler ViewerHandler { get; set; }
        public static TileManager TileManager { get; set; }
        public static GCMHandler GCMHandler { get; set; }
        public static PowerschoolLoginHandler PowerschoolHandler { get; set; }
        public GlobalHandlers()
        {
            
        }
    }
    public abstract class Handler
    {
       
    }
}