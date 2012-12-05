using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace DayData.admin.core.features.announcements.classes
{
    public class GoogleDocsHandler
    {
        public static List<string> downloadFileGetList(string id)
        {
            List<string> returns = new List<string>();
            HttpWebRequest d = (HttpWebRequest)WebRequest.Create("https://docs.google.com/document/export?format=txt&id=" + id);
            HttpWebResponse r =
                (HttpWebResponse)d.GetResponse();

            StreamReader reader = new StreamReader(r.GetResponseStream());
            string file = reader.ReadToEnd();
            reader.Close();
            r.Close();

            string[] split = file.Split(Environment.NewLine.ToCharArray());
            foreach (string p in split)
            {
                if ((p == "") || (p == " "))
                {

                }
                else
                {
                    returns.Add(p.HtmlEncode());
                }
            }
            return returns;

        }
        public static string getGoogleDocID(string link)
        {
            string returnString = GetStringInBetween("https://docs.google.com/document/d/", "/edit", link, false, false)[0];
            return returnString;
        }
        public static string[] GetStringInBetween(string strBegin,
string strEnd, string strSource,
bool includeBegin, bool includeEnd)
        {
            string[] result = { "", "" };
            int iIndexOfBegin = strSource.IndexOf(strBegin);
            if (iIndexOfBegin != -1)
            {
                // include the Begin string if desired
                if (includeBegin)
                    iIndexOfBegin -= strBegin.Length;
                strSource = strSource.Substring(iIndexOfBegin
                    + strBegin.Length);
                int iEnd = strSource.IndexOf(strEnd);
                if (iEnd != -1)
                {
                    // include the End string if desired
                    if (includeEnd)
                        iEnd += strEnd.Length;
                    result[0] = strSource.Substring(0, iEnd);
                    // advance beyond this segment
                    if (iEnd + strEnd.Length < strSource.Length)
                        result[1] = strSource.Substring(iEnd
                            + strEnd.Length);
                }
            }
            else
                // stay where we are
                result[1] = strSource;
            return result;
        }
    }
    public static class Extensions
    {
        public static string HtmlEncode(this string s)
        {
            return HttpUtility.HtmlEncode(s);
        }
        public static string HtmlDecode(this string s)
        {
            return HttpUtility.HtmlDecode(s);
        }
    }
}