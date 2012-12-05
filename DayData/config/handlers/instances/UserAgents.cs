using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace DayData.config.handlers.instances
{
    public class UserAgents
    {
        public static TypeOfDevice getType(string user_agent)
        {
            TypeOfDevice? toReturn = null;

            GlobalHandlers.Debugger.write("user agent: " + user_agent);

            if (user_agent.Contains("desktop"))
                toReturn = TypeOfDevice.Desktop;
            else if (user_agent.Contains("mobile"))
                toReturn = TypeOfDevice.Mobile;
            else if (user_agent.Contains("tablet"))
                toReturn = TypeOfDevice.Tablet;
            else if (user_agent.Contains("tv"))
                toReturn = TypeOfDevice.TV;

            if (toReturn == null)
            {
                if (Regex.IsMatch(user_agent, @"GoogleTV|SmartTV|Internet.TV|NetCast|NETTV|AppleTV|boxee|Kylo|Roku|DLNADOC|CE\-HTML"))
                    toReturn = TypeOfDevice.TV;
                else if (Regex.IsMatch(user_agent, @"Xbox|PLAYSTATION.3|Wii"))
                    toReturn = TypeOfDevice.TV;
                else if (Regex.IsMatch(user_agent, @"iP(a|ro)d") || Regex.IsMatch(user_agent, @"tablet") && Regex.IsMatch(user_agent, @"RX-34") || Regex.IsMatch(user_agent, @"FOLIO"))
                    toReturn = TypeOfDevice.Tablet;
                else if (Regex.IsMatch(user_agent, @"Linux") && Regex.IsMatch(user_agent, @"Android") && Regex.IsMatch(user_agent, @"Fennec|mobi|HTC.Magic|HTCX06HT|Nexus.One|SC-02B|fone.945"))
                    toReturn = TypeOfDevice.Tablet;
                else if (Regex.IsMatch(user_agent, @"Kindle") || Regex.IsMatch(user_agent, @"Mac.OS") && Regex.IsMatch(user_agent, @"Silk"))
                    toReturn = TypeOfDevice.Tablet;
                else if (Regex.IsMatch(user_agent, @"GT-P10|SC-01C|SHW-M180S|SGH-T849|SCH-I800|SHW-M180L|SPH-P100|SGH-I987|zt180|HTC(.Flyer|Flyer)|Sprint.ATP51|ViewPad7|pandigital(sprnova|nova)|Ideos.S7|Dell.Streak.7|Advent.Vega|A101IT|A70BHT|MID7015|Next2|nook") || Regex.IsMatch(user_agent, @"MB511") && Regex.IsMatch(user_agent, @"RUTEM"))
                    toReturn = TypeOfDevice.Tablet;
                else if (Regex.IsMatch(user_agent, @"BOLT|Fennec|Iris|Maemo|Minimo|Mobi|mowser|NetFront|Novarra|Prism|RX-34|Skyfire|Tear|XV6875|XV6975|Google.Wireless.Transcoder"))
                    toReturn = TypeOfDevice.Mobile;
                else if (Regex.IsMatch(user_agent, @"Opera") && Regex.IsMatch(user_agent, @"Windows.NT.5") && Regex.IsMatch(user_agent, @"HTC|Xda|Mini|Vario|SAMSUNG\-GT\-i8000|SAMSUNG\-SGH\-i9"))
                    toReturn = TypeOfDevice.Mobile;
                else if ((Regex.IsMatch(user_agent, "Windows.(NT|XP|ME|9)") && (!Regex.IsMatch(user_agent, "Phone")) || Regex.IsMatch(user_agent, "Win(9|.9|NT)")))
                    toReturn = TypeOfDevice.Desktop;
                else if (Regex.IsMatch(user_agent, @"Macintosh|PowerPC") || Regex.IsMatch(user_agent, @"Silk"))
                    toReturn = TypeOfDevice.Desktop;
                else if (Regex.IsMatch(user_agent, @"Linux") && Regex.IsMatch(user_agent, "X11"))
                    toReturn = TypeOfDevice.Desktop;
                else if (Regex.IsMatch(user_agent, @"Solaris|SunOS|BSD"))
                    toReturn = TypeOfDevice.Desktop;
                else if (Regex.IsMatch(user_agent, @"Bot|Crawler|Spider|Yahoo|ia_archiver|Covario-IDS|findlinks|DataparkSearch|larbin|Mediapartners-Google|NG-Search|Snappy|Teoma|Jeeves|TinEye") && !Regex.IsMatch(user_agent, "Mobile"))
                    toReturn = TypeOfDevice.Desktop;
                else if (Regex.IsMatch(user_agent, @"CrOS"))
                    toReturn = TypeOfDevice.Desktop;
                else
                    toReturn = TypeOfDevice.Mobile;
            }
                return (TypeOfDevice) toReturn;
           
        }
    }
    public enum TypeOfDevice
    {
        Mobile, Desktop, Tablet, TV
    }
}