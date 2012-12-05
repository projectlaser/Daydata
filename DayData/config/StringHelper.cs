using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DayData.config
{
    public static class StringHelper
    {
        public static string[] GetStringInBetween(this string strSource, string strBegin, string strEnd, bool includeBegin, bool includeEnd)
        {
            string[] result = { "", "" };
            int iIndexOfBegin = strSource.IndexOf(strBegin);
            if (iIndexOfBegin != -1)
            {
                if (includeBegin)
                    iIndexOfBegin -= strBegin.Length;

                strSource = strSource.Substring(iIndexOfBegin + strBegin.Length);
                int iEnd = strSource.IndexOf(strEnd);

                if (iEnd != -1)
                {
                    if (includeEnd)
                        iEnd += strEnd.Length;

                    result[0] = strSource.Substring(0, iEnd);
                    if (iEnd + strEnd.Length < strSource.Length)
                        result[1] = strSource.Substring(iEnd + strEnd.Length);

                }

            }

            else
                result[1] = strSource;

            return result;

        }
    }

}