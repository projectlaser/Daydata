using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DayData.admin.core.controls
{
    /// <summary>
    /// Summary description for File
    /// </summary>
    public class File : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string filename = context.Request.QueryString["File"];
            //Validate the file name and make sure it is one that the user may access
            context.Response.Buffer = true;
            context.Response.Clear();
            context.Response.AddHeader("content-disposition", "attachment; filename=" + filename);
            context.Response.ContentType = "octet/stream";

            context.Response.WriteFile("~/App_Data/" + filename);

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