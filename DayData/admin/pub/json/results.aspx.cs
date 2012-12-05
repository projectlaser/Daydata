using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DayData.admin.pub.json.instances;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;
using DayData.config;
using System.Diagnostics;
using DayData.admin.core.features.lunchmenu.classes;
using System.Net;
using HtmlAgilityPack;
using DayData.admin.core.features.events.handlers;
using PowerschoolParser;
using Book_Search;

namespace DayData.admin.pub.json
{
    public partial class results : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["info"] == null)
                {

                }
                else
                {
                    string request = Request.QueryString["info"];
                    //possible:
                    //announcements
                    //lunchmenu
                    //events
                    if (request == "announcements")
                    {
                        //return the announcements
                        //get all from database
                        //lets get the announcement value from database.. should be in format: {a,b,c};

                        string tx = GlobalHandlers.DatabaseHandler.getFeatureValue("announcements");
                        List<Announcement> list = GlobalHandlers.DatabaseHandler.getAnnouncements();
                        var serializer = new JavaScriptSerializer();
                        Response.Write(serializer.Serialize(list));
                    }
                    else if (request == "lunchmenu")
                    {
                        //example {::1,French Fries/Item 2/Item 3/Item 4/Item 5::2,IdontKnowWhatTOPutHere/ItemTwo/ItemThree/ItemFour/ItemFive}

                        if (Request.QueryString["date"] != null)
                        {
                            string[] dayItems = GlobalHandlers.DatabaseHandler.getListOfItemsForADay(Request.QueryString["date"].ToString());
                            if (dayItems != null)
                            {
                                CustomLunchDay d = new CustomLunchDay();
                                d.Items = dayItems.ToList();
                                try
                                {
                                    DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, Convert.ToInt32(Request.QueryString["date"].ToString()));
                                    d.Day = date.ToString();
                                }
                                catch (Exception eeee)
                                {


                                }
                                var serializer = new JavaScriptSerializer();

                                Response.Write(serializer.Serialize(d));
                            }


                        }
                        else if (Request.QueryString["date"] == null)
                        {
                            string[] days = GlobalHandlers.DatabaseHandler.getListOfItemsForToday();
                            CustomLunchDay d = new CustomLunchDay();
                            d.Items = days.ToList();
                            d.Day = DateTime.Now.Day.ToString();
                            var serializer = new JavaScriptSerializer();

                            Response.Write(serializer.Serialize(d));
                        }

                    }
                    else if (request == "events")
                    {
                        List<Event> listOfEvents = GlobalHandlers.DatabaseHandler.getEvents(true);
                        //now we have todays events. lets send them out.
                        var lizer = new JavaScriptSerializer();
                        Response.Write(lizer.Serialize(listOfEvents));
                    }
                    else if (request == "booksearch")
                    {
                        if (Request.QueryString["query"] != null)
                        {
                            string query = Request.QueryString["query"];
                            string readyQuery = query.Replace(" ", "+");

                            BookResults results = Booksearcher.search(readyQuery, School.Thomas_Jefferson_High_School);
                            if (results != null)
                            {
                                var serializer = new JavaScriptSerializer();
                                Response.Write(serializer.Serialize(results));
                            }
                            else
                            {
                                Response.Write("Error");
                            }

                        }
                        else
                        {
                            Response.Write("No query");
                        }
                    }
                    else if (request == "grades")
                    {
                        PowerschoolParser.Powerschool ps = new PowerschoolParser.Powerschool();
                        string password = "";
                        string username = "";
                        if (Request.QueryString["username"] != null)
                        {
                            username = Request.QueryString["username"].ToString();
                        }
                        if (Request.QueryString["password"] != null)
                        {
                            password = Request.QueryString["password"].ToString();
                        }
                        var seria = new JavaScriptSerializer();
                        if (password == "" || username == "")
                        {
                            Error t = new Error();
                            t.Text = "Incorrect username or password";
                            t.Code = "1";
                            Response.Write(seria.Serialize(t));
                            return;
                        }
                        Return returned = ps.login(username, password);
                        if (returned.getCodeResult() == Return.ResultCode.LOGIN_CREDS_INCORRECT)
                        {
                            Error t = new Error();
                            t.Text = "Incorrect username or password";
                            t.Code = "1";
                            Response.Write(seria.Serialize(t));
                            return;
                        }
                        else if (returned.getCodeResult() == Return.ResultCode.GOOD)
                        {
                            if (returned.getStudentResult() != null)
                            {
                                Response.Write(seria.Serialize(returned.getStudentResult()));
                            }
                        }
                    }
                    else if (request == "filter")
                    {
                        string latlng = String.Empty;

                        if (Request.QueryString["latlong"] != null)
                        {
                            latlng = Request.QueryString["latlong"].ToString().Replace(" ", "");
                        }
                        Filter filt = GlobalHandlers.DatabaseHandler.getFilterFromLocation(latlng);
                        var serializer = new JavaScriptSerializer();

                        Response.Write(serializer.Serialize(filt));
                    }
                    else if (request == "filters")
                    {
                        List<Filter> filterList = GlobalHandlers.DatabaseHandler.getFilters();
                        var ser = new JavaScriptSerializer();
                        Response.Write(ser.Serialize(filterList));
                    }
                }
            }
            catch (Exception eeee)
            {
                Debug.WriteLine("JSON Result Error: " + eeee);
            }
        }
    }
}