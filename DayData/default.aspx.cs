using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Data.SqlClient;
using DayData.config;
using DayData.config.handlers.instances;

namespace DayData
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!GlobalHandlers.ProtectionHandler.isApplicationOK())
            {
                //we need to redirect TODO
              //  Server.Transfer("error.aspx?error=1", false);
                return;
            }
            if (Request.QueryString["app"] != null)
            {
                //lets find the app its wanting us to load.
                string appSelection = Request.QueryString["app"];
                switch (appSelection)
                {
                    case "lunch":
                        Server.Transfer("lunch.aspx", false);
                        break;
                    case "events":
                        Server.Transfer("events.aspx", false);
                        break;
                    default:
                        break;
                }
            }
            label1.Text = UserAgents.getType(Request.UserAgent).ToString();
            switch (UserAgents.getType(Request.UserAgent).ToString())
            {
                case "Mobile":
                    Response.Redirect("mobile/default.aspx", false);
                    break;
                case "Desktop":
                    Response.Redirect("desktop/default.aspx", false);
                    break;
                default:
                    Response.Redirect("desktop/default.aspx", false);
                    break;
            }
            // MySQLDatabase basex = MySQLDatabase.create("project-laser.com", "daydata", "daydata", "password123", "data_", Panel1);
            // List<Column> col = new List<Column>();
            // // Column c = Column.create("testcol1", Column.Type.TEXT, false, false, false, false);
            //  col.Add(c);
            // //  basex.dataSetter.createTable("tableid", col);
            //  basex.mySqlConnection.ConnectionString = basex.getConnectionString();
            //  basex.connect();

            //  if (basex.isConnected())
            //       Debug.WriteLine("Were connected!!");

            //  basex.dataSetter.createTables();
            //  Debug.WriteLine("Host: " + basex.Host + " Setter:"+basex.dataSetter);
            //  Constants.connection = new MySQLDatabase();
            //Session["thisisoursession"] = 
            //  SqlConnection sql = new SqlConnection();


        }
    }
}