using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using DayData.config.handlers.instances.item;
using DayData.admin.pub.json.instances;
using DayData.admin.core.features.events.handlers;
using DayData.config.handlers.timers;
using DayData.config.handlers.tiles.class_id;

namespace DayData.config.handlers.instances
{
    public class DatabaseHandler : Handler
    {
        public Type global_type { get; set; }
        public MySqlConnection MySqlConnection = null;
        public GlobalInformation globalInformation;
        public static DatabaseHandler create(Type type)
        {
            if (type == Type.MySQL)
                return new DatabaseHandler(Type.MySQL);

            return new DatabaseHandler(Type.MySQL);
        }
        public DatabaseHandler(Type type)
        {
            global_type = type;
            Debug.WriteLine("[DatabaseHandler]: Created database with type: " + global_type);
        }
        public List<Viewer> getViewers()
        {
            List<Viewer> viewers = new List<Viewer>();
            try
            {
                if (MySqlConnection.State == System.Data.ConnectionState.Open)
                {
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM `viewers`", MySqlConnection);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows == false)
                        {
                            reader.Close();
                            return new List<Viewer>();
                        }
                        while (reader.Read())
                        {
                            Viewer viewer = new Viewer();
                            viewer.id = reader["id"].ToString();
                            viewer.type = reader["type"].ToString();
                            viewer.tablet = reader["tablet"].ToString();
                            viewer.desktop = reader["desktop"].ToString();
                            viewer.mobile = reader["mobile"].ToString();
                            viewer.enabled = reader["enabled"].ToString();
                            viewers.Add(viewer);

                        }
                    }
                    return viewers;
                }
            }
            catch (Exception ee)
            {
                GlobalHandlers.Debugger.write(ee.ToString());
                return viewers;
            }
            return viewers;
        }
        public bool setEnabled(bool t)
        {
            try
            {
                if (MySqlConnection.State == System.Data.ConnectionState.Open)
                {
                    string valueToSet = String.Empty;
                    if (t)
                        valueToSet = "1";
                    else if (t == false)
                        valueToSet = "0";

                    MySqlCommand cmd = new MySqlCommand("UPDATE `settings` SET `value` = ?val WHERE `key` = 'enabled'", MySqlConnection);
                    cmd.Parameters.AddWithValue("?val", valueToSet);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (MySqlException exception)
            {
                GlobalHandlers.Debugger.write(exception.ToString());
                return false;
            }
            return false;
        }
        public bool updateAnnouncement(Announcement announcement)
        {
            try
            {
                if (MySqlConnection.State == System.Data.ConnectionState.Open)
                {
                    MySqlCommand cmd = new MySqlCommand("UPDATE `announcements` SET `text` = ?text, `title` = ?title, `locked` = ?locked WHERE `id` = ?id", MySqlConnection);
                    cmd.Parameters.AddWithValue("?text", announcement.Text);
                    cmd.Parameters.AddWithValue("?title", announcement.Title);
                    cmd.Parameters.AddWithValue("?locked", announcement.locked.ToString());
                    cmd.Parameters.AddWithValue("?id", announcement.ID.ToString());
                    var result = cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    if (!result.Equals(0))
                        return true;

                    return false;
                }
                return false;
            }
            catch (Exception eee)
            {
                Debug.WriteLine(eee);
            }
            return false;
        }
        public Filter getFilterFromLocation(string LatLong)
        {
            //we have to check all filters and see if we can get the lat and long from them
            Filter f = new Filter();
            foreach (Filter id in GlobalHandlers.DatabaseHandler.getFilters())
            {
                string lat = LatLong.Split(Char.Parse(","))[0];
                string longD = LatLong.Split(Char.Parse(","))[1];
                f.Lat = lat;
                f.Long = longD;
                if (id.Lat.Contains(lat) && id.Long.Contains(longD))
                {
                    return id;
                }
            }
            return f;
        }
        public Event getEventById(string id)
        {
            Event d = new Event();
            try
            {
                if (MySqlConnection.State == System.Data.ConnectionState.Open)
                {
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM `events` WHERE `eventid` = ?id", MySqlConnection);
                    cmd.Parameters.AddWithValue("?id", id);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows == false)
                        {
                            reader.Close();
                            cmd.Dispose();
                            return null;
                        }
                        while (reader.Read())
                        {
                            //lets get all the info we need.
                            d.Title = reader["title"].ToString();
                            d.Time = reader["time"].ToString();
                            d.Date = reader["date"].ToString();
                            d.Description = reader["description"].ToString();
                            d.Location = reader["location"].ToString();
                            d.From = reader["from"].ToString();
                        }
                    }
                    d.Filter = getFilterFromLocation(d.Location);
                    cmd.Dispose();
                    return d;
                }
                return null; //connection not open
            }
            catch (Exception eee)
            {
                GlobalHandlers.Debugger.write(eee.ToString());
                return null; //error
            }
        }
        public string[] getListOfItemsForTomorrow()
        {
            string tx = GlobalHandlers.DatabaseHandler.getFeatureValue("lunchmenu");
            if (tx != null)
            {
                List<LunchDay> days = new List<LunchDay>();
                tx = tx.Replace("{", "");
                tx = tx.Replace("}", "");
                string[] res = tx.Split(new string[] { ":::" }, StringSplitOptions.None);
                foreach (string stt in res)
                {
                    LunchDay newDay = new LunchDay();
                    //  if ((stt == "") || (stt == " ") || (stt == null))
                    //     return;
                    //ok now we should be seperated by 1,items/items/items/items/items
                    //we need to insert into the mysql DATABASE!!! TODO
             //      Debug.WriteLine("Stt: " + stt);
                    string[] xxx = stt.Split(new string[] { "," }, StringSplitOptions.None);

                    //first should date. then we can remove date and , for y: results
                    // Response.Write("Day: " + xxx[0]);

                //    Debug.WriteLine("Day: " + xxx[0]);
                    newDay.Day = xxx[0];
                    //   Response.Write(Environment.NewLine);

                    string items = stt.Replace(xxx[0] + ",", "");
                //    Debug.WriteLine("Items: " + items);
                    newDay.Items = items;
                    days.Add(newDay);


                }
                foreach (LunchDay day in days)
                {
                    string today = DateTime.Now.AddDays(1).Day.ToString();
                    if (day.Day == today)
                    {
                        List<String> str = new List<string>();
                        string[] list = day.Items.Split(Char.Parse("/"));
                      //  Debug.WriteLine("Found tomorrow: " + day.Day + " Items: " + day.Items);
                        return list;
                    }
                }
                return null;
            }
            return null;
        }
        public bool addEvent(Event d)
        {
            try
            {
                if (MySqlConnection.State == System.Data.ConnectionState.Open)
                {
                    //lets add it.
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO `events` (`title`,`time`,`date`,`description`,`location`,`from`)VALUES(?title,?time,?date,?desc,?location,?from);", MySqlConnection);
                    cmd.Parameters.AddWithValue("?title", d.Title);
                    cmd.Parameters.AddWithValue("?time", d.Time);
                    cmd.Parameters.AddWithValue("?desc", d.Description);
                    cmd.Parameters.AddWithValue("?location", d.Location);
                    cmd.Parameters.AddWithValue("?from", d.From);
                    cmd.Parameters.AddWithValue("?date", d.Date);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception eee)
            {
                GlobalHandlers.Debugger.write(eee.ToString());
                return false;
            }
            return false;
        }

        public string[] getListOfItemsForToday()
        {
            string tx = GlobalHandlers.DatabaseHandler.getFeatureValue("lunchmenu");
            if (tx != null)
            {
                List<LunchDay> days = new List<LunchDay>();
                tx = tx.Replace("{", "");
                tx = tx.Replace("}", "");
                string[] res = tx.Split(new string[] { ":::" }, StringSplitOptions.None);
                foreach (string stt in res)
                {
                    LunchDay newDay = new LunchDay();
                    //  if ((stt == "") || (stt == " ") || (stt == null))
                    //     return;
                    //ok now we should be seperated by 1,items/items/items/items/items
                    //we need to insert into the mysql DATABASE!!! TODO
                    Debug.WriteLine("Stt: " + stt);
                    string[] xxx = stt.Split(new string[] { "," }, StringSplitOptions.None);

                    //first should date. then we can remove date and , for y: results
                    // Response.Write("Day: " + xxx[0]);

                    Debug.WriteLine("Day: " + xxx[0]);
                    newDay.Day = xxx[0];
                    //   Response.Write(Environment.NewLine);

                    string items = stt.Replace(xxx[0] + ",", "");
                    Debug.WriteLine("Items: " + items);
                    newDay.Items = items;
                    days.Add(newDay);


                }
                foreach (LunchDay day in days)
                {
                    string today = DateTime.Now.Day.ToString();
                    if (day.Day == today)
                    {
                        //ok. this is the day we need, now lets split it up
                        List<String> str = new List<string>();
                        string[] list = day.Items.Split(Char.Parse("/"));
                        Debug.WriteLine("Found day: " + day.Day + " Items: " + day.Items);
                        return list;
                    }
                }
                return null;
            }
            return null;
        }
        public Filter getDefaultFilter()
        {
            try
            {
                Filter toReturn = new Filter();
                toReturn.Name = GlobalHandlers.DatabaseHandler.globalInformation.School_Name;
                string latlong = GlobalHandlers.SettingHandler.Settings["default_filter"].ToString();
                string[] splited = latlong.Split(Char.Parse(","));
                toReturn.Lat = splited[0].Replace(" ", "");
                toReturn.Long = splited[1].Replace(" ", "");

                return toReturn;
            }
            catch (Exception ee)
            {
                GlobalHandlers.Debugger.write(ee.ToString());
                return new Filter();
            }

        }
        public void updateEvents(List<Event> listOfEvents)
        {
            if (listOfEvents.Count < 1)
            {
                return;
            }
            try
            {
                if (MySqlConnection.State == System.Data.ConnectionState.Open)
                {
                    string commandText = "INSERT INTO `events` (`title`, `time`, `date`, `description`, `location`, `from`) VALUES ";
                    foreach (Event d in listOfEvents)
                    {
                        commandText += "('" + d.Title + "', '" + d.Time + "', '" + d.Date + "', '" + d.Description + "','" + d.Filter.Lat + "," + d.Filter.Long + "', '0'),";
                        //      commandText += "('(no title)', '" + d + "', 'False'),";
                    }
                    if (commandText.EndsWith(","))
                    {
                        commandText = commandText.Substring(0, commandText.Length - 1);
                        commandText += ";";
                    }
                    MySqlCommand cmd = new MySqlCommand(commandText, MySqlConnection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ecp)
            {
                GlobalHandlers.Debugger.write(ecp.ToString());
            }
        }
        public bool fillGlobalInformation()
        {
            if (globalInformation == null)
            {
                globalInformation = new GlobalInformation();
                if (MySqlConnection.State == System.Data.ConnectionState.Open)
                {
                    try
                    {
                        MySqlCommand command = new MySqlCommand("SELECT * FROM `info` LIMIT 1", MySqlConnection);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows == false)
                            {
                                GlobalHandlers.Debugger.write("Error reading first row in MySql Database. Perhaps no information...");
                                reader.Close();
                                return false;
                            }
                            while (reader.Read())
                            {
                                globalInformation.School_Name = reader["name"].ToString();
                                globalInformation.School_ID = reader["schoolid"].ToString();
                                globalInformation.District_Url = reader["districturl"].ToString();
                                globalInformation.Color = reader["color"].ToString();
                                globalInformation.DayData_Url = reader["url"].ToString();
                                globalInformation.District_Address = reader["districtaddress"].ToString();
                                globalInformation.District_ID = reader["districtid"].ToString();
                                globalInformation.District_Name = reader["districtname"].ToString();
                                globalInformation.SecondColor = reader["secondcolor"].ToString();

                            }
                            reader.Close();
                        }
                        return true;
                    }


                    catch (Exception exp)
                    {
                        GlobalHandlers.Debugger.write("MySQL Error: " + exp);
                    }
                }
            }
            return false;
        }
        public List<Filter> getFilters()
        {
            List<Filter> filterList = new List<Filter>();
            if (MySqlConnection.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM `filters`", MySqlConnection);
                   
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            cmd.Dispose();
                            reader.Close();
                            return filterList;
                        }
                        while (reader.Read())
                        {
                            string id = reader["id"].ToString();
                            string name = reader["filter_text"].ToString();
                            string longx = reader["long"].ToString();
                            string lat = reader["lat"].ToString();
                            Filter filter = new Filter();
                            filter.Id = id;
                            filter.Name = name;
                            filter.Long = longx;
                            filter.Lat = lat;
                            filterList.Add(filter);
                        }
                        reader.Close();
                    }
                    return filterList;
                }
                catch (MySqlException ecc)
                {
                    GlobalHandlers.Debugger.write(ecc.ToString());
                }
            }
            return filterList;
        }
        public bool connect()
        {
            if (MySqlConnection == null)
            {
                MySqlConnection = new MySqlConnection();
                MySqlConnection.ConnectionString = GlobalHandlers.SettingHandler.getMySQLConnectionString();
                try
                {
                    MySqlConnection.Open();
                    GlobalHandlers.Debugger.write("MySQL Connected Successfully");
                    return true;
                }
                catch (MySqlException ex)
                {
                    GlobalHandlers.Debugger.write(ex.ToString());
                    return false;
                }

            }
            return false;
        }
        public bool deleteAnnouncement(string id)
        {
            try
            {
                if (MySqlConnection.State == System.Data.ConnectionState.Open)
                {
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM `announcements` WHERE `id` = ?id", MySqlConnection);
                    cmd.Parameters.AddWithValue("?id", id);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    return true;
                }
            }
            catch (MySqlException exception)
            {
                GlobalHandlers.Debugger.write(exception.ToString());
                return false;
            }
            return false;
        }
        public bool deleteAnnouncements(bool deleteLocked)
        {
            try
            {
                if (MySqlConnection.State == System.Data.ConnectionState.Open)
                {
                    string cmdText = (deleteLocked) ? "DELETE FROM `announcements`" : "DELETE FROM `announcements` WHERE locked='false'";
                    MySqlCommand cmd = new MySqlCommand(cmdText, MySqlConnection);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    return true;
                }
                return false;
            }
            catch (MySqlException expp)
            {
                GlobalHandlers.Debugger.write(expp.ToString());
                return false;
            }
        }
        public bool setupAnnouncements(List<string> list)
        {
            try
            {
                string commandText = "INSERT INTO `announcements` (`title`, `text`, `locked`) VALUES ";
                foreach (string d in list)
                {
                    commandText += "('(no title)', '" + d + "', 'False'),";
                }
                if (commandText.EndsWith(","))
                {
                    commandText = commandText.Substring(0, commandText.Length - 1);
                    commandText += ";";
                }
                if (MySqlConnection.State == System.Data.ConnectionState.Open)
                {
                    MySqlCommand cmd = new MySqlCommand(commandText, MySqlConnection);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                return false;
            }
            catch (Exception eee)
            {
                GlobalHandlers.Debugger.write(eee.ToString());
                return false;
            }

        }

        public Updater getUpdater(ViewerHandler.Feature feature)
        {
            try
            {
                if (MySqlConnection.State == System.Data.ConnectionState.Open)
                {
                    string command = "SELECT * FROM `updaters` WHERE `featureid` = '" + (int)feature + "' LIMIT 1";
                    MySqlCommand cmd = new MySqlCommand(command, MySqlConnection);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows == false)
                        {
                            reader.Close();
                            return null;
                        }
                        Updater updater = new Updater();
                        while (reader.Read())
                        {
                            updater.ID = reader["updaterid"].ToString();
                            updater.Feature_Id = reader["featureid"].ToString();
                            updater.Type_Id = reader["typeid"].ToString();
                            updater.Updater_Name = reader["updater_name"].ToString();
                            updater.Link = reader["link"].ToString();
                            updater.Type = reader["type"].ToString();
                        }
                        reader.Close();
                        return updater;
                    }
                }
                return null;
            }
            catch (MySqlException expp)
            {
                GlobalHandlers.Debugger.write(expp.ToString());
                return null;
            }
        }
        public bool deleteAnnouncementsOnUpdate()
        {
            try
            {
                if (MySqlConnection.State == System.Data.ConnectionState.Open)
                {
                    int returned;
                    string ret = string.Empty;
                    MySqlCommand cmd = new MySqlCommand("select * FROM `settings` where `key` = 'delete_announcements_on_update'", MySqlConnection);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows == false)
                        {
                            //hmm.. thats a problem.
                            reader.Close();
                            return false;
                        }
                        while (reader.Read())
                        {
                            ret = reader["value"].ToString();
                        }
                        reader.Close();
                    }
                    
                    if (ret != null && ret.Length < 2)
                    {
                        //ok lets parse to a int
                        Int32.TryParse(ret, out returned);
                        if (returned == 1)
                        {
                            return true;
                        }
                        else if (returned == 0)
                        {
                            return false;
                        }
                    }
                    return false;
                }
                return false;
            }
            catch (MySqlException expp)
            {
                GlobalHandlers.Debugger.write(expp.ToString());
                return false;
            }
        }
        public bool DayDataEnabled()
        {
            try
            {
                if (MySqlConnection.State == System.Data.ConnectionState.Open)
                {
                    int returned;
                    string ret = string.Empty;
                    MySqlCommand cmd = new MySqlCommand("select * FROM `settings` where `key` = 'enabled'", MySqlConnection);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows == false)
                        {
                            reader.Close();
                            return false;
                        }
                        while (reader.Read())
                        {
                            ret = reader["value"].ToString();
                        }
                        reader.Close();
                    }
                    
                    if (ret != null && ret.Length < 2)
                    {
                        //ok lets parse to a int
                        Int32.TryParse(ret, out returned);
                        if (returned == 1)
                        {
                            return true;
                        }
                        else if (returned == 0)
                        {
                            return false;
                        }
                    }
                    cmd.Dispose();
                    return false;
                }
                return false;
            }
            catch (MySqlException expp)
            {
                GlobalHandlers.Debugger.write(expp.ToString());
                return false;
            }
        }
        public bool submitAnnouncementUpdater(string update_method, string link, string doc_id, string often, string often_at)
        {
            try
            {
                if (MySqlConnection.State == System.Data.ConnectionState.Open)
                {
                    int featureId;
                    string typed = String.Empty;
                    if (update_method == "google_docs")
                    {
                        featureId = 0;
                    }
                    else
                    {
                        featureId = 5;
                    }
                    if (often == "Every 24 hours")
                    {
                        typed = "24:" + often_at;
                    }
                    else if (often == "Every hour")
                    {
                        typed = "1";
                    }
                    else if (often == "Every 5 hours")
                    {
                        typed = "5";
                    }
                    MySqlCommand removeAll = new MySqlCommand("DELETE FROM `updaters` WHERE typeid = 0", MySqlConnection);
                    removeAll.ExecuteNonQuery();

                    MySqlCommand cmd = new MySqlCommand("INSERT into `updaters` (`featureid`, `typeid`, `updater_name`, `link`, `type`, `seperator`) VALUES(?featureid, ?typeid, ?updatename, ?link, ?type, ?sep)", MySqlConnection);
                    cmd.Parameters.AddWithValue("?featureid", featureId);
                    cmd.Parameters.AddWithValue("?typeid", 0);
                    cmd.Parameters.AddWithValue("?updatename", update_method);
                    cmd.Parameters.AddWithValue("?link", doc_id);
                    cmd.Parameters.AddWithValue("?type", typed);
                    cmd.Parameters.AddWithValue("?sep", "");
                    cmd.ExecuteNonQuery();
                    return true;
                }
                return false;
            }
            catch (Exception ee)
            {
                GlobalHandlers.Debugger.write(ee.ToString());
                return false;
            }
        }
        public bool announcementUpdaterAlreadyExists()
        {
            try
            {
                if (MySqlConnection.State == System.Data.ConnectionState.Open)
                {
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM `updaters` WHERE typeid = '0'", MySqlConnection);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Close();
                            return true;
                        }
                        else
                        {
                            reader.Close();
                            return false;
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                GlobalHandlers.Debugger.write(ee.ToString());
                return true;
            }
            return true;
        }

        public string getTypeById(string id)
        {
            try
            {
                if (MySqlConnection.State == System.Data.ConnectionState.Open)
                {
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM `updaters` WHERE `updaterid` = ?id", MySqlConnection);
                    cmd.Parameters.AddWithValue("?id", id);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows == false)
                        {
                            reader.Close();
                            cmd.Dispose();
                            return "Unknown";
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                string type = reader["featureid"].ToString();
                                string toReturn = String.Empty;
                                if (type == "0")
                                    toReturn = "announcements";
                                else if (type == "1")
                                    toReturn = "events";
                                else
                                    toReturn = "unknown";
                                reader.Close();
                                cmd.Dispose();
                                return toReturn;
                            }

                        }
                    }

                }
            }
            catch (MySqlException exception)
            {
                GlobalHandlers.Debugger.write(exception.ToString());
            }
            return "Unknown";

        }

        public bool sessionToDatabase(SessionItem session)
        {
            Debug.WriteLine("Accessesd by Database handler: ip: " + session.getSession()["ipaddress"] + " id:" + session.getSession().SessionID);
            try
            {
                if (MySqlConnection.State == System.Data.ConnectionState.Open)
                {
                    MySqlCommand command = new MySqlCommand("INSERT INTO sessions (sessionid, ipaddress, username) VALUES(?id, ?ip, ?user);", MySqlConnection);
                    command.Parameters.AddWithValue("?id", session.getSession().SessionID);
                    command.Parameters.AddWithValue("?ip", HttpContext.Current.Session["ipaddress"]);
                    command.Parameters.AddWithValue("?user", HttpContext.Current.Session["username"]);
                    command.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    MySqlCommand command = new MySqlCommand("INSERT INTO sessions (sessionid, ipaddress, username) VALUES(?id, ?ip, ?user);", MySqlConnection);
                    command.Parameters.AddWithValue("?id", session.getSession().SessionID);
                    command.Parameters.AddWithValue("?ip", session.getSession()["ipaddress"].ToString());
                    command.Parameters.AddWithValue("?user", HttpContext.Current.Session["username"]);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    return true;

                }

            }
            catch (MySqlException exp)
            {
                GlobalHandlers.Debugger.write(exp.ToString());
                return false;
            }
        }
        public bool removeSessionFromDatabase(string key)
        {
            Debug.WriteLine("Attempting to remove session.");
            try
            {
                if (MySqlConnection.State == System.Data.ConnectionState.Open)
                {
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM sessions WHERE sessionid=?key", MySqlConnection);
                    cmd.Parameters.AddWithValue("?key", key);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM sessions WHERE sessionid=?key", MySqlConnection);
                    cmd.Parameters.AddWithValue("?key", key);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (MySqlException exp)
            {
                GlobalHandlers.Debugger.write(exp.ToString());
                return false;
            }
        }
        public bool removeAllSessionsFromDatabase()
        {
            Debug.WriteLine("REmoving all sessions");
            try
            {
                if (MySqlConnection.State == System.Data.ConnectionState.Open)
                {
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM `sessions`", MySqlConnection);
                    cmd.ExecuteNonQuery();
                    return true;

                }
                else
                {
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM `sessions`", MySqlConnection);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (MySqlException exxp)
            {
                GlobalHandlers.Debugger.write(exxp.ToString());
                return false;
            }
        }
        public List<Event> getEvents(bool justToday)
        {
            List<Event> events = new List<Event>();
            if (MySqlConnection.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = MySqlConnection;
                    if (justToday == true)
                    {
                        string dateToday = DateTime.Now.ToString("MM/dd/yyyy");
                        Debug.WriteLine("dateToday: " + dateToday);
                        cmd.CommandText = "SELECT * FROM `events` WHERE `date` = '" + dateToday + "';";
                    }
                    else if (justToday == false)
                    {
                        cmd.CommandText = "SELECT * FROM `events`";
                    }
                    using(MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows == false)
                        {
                            reader.Close();
                            cmd.Dispose();
                            Debug.WriteLine("no events returned");
                            return events;
                        }
                        while (reader.Read())
                        {
                            string id = reader["eventid"].ToString();
                            string title = reader["title"].ToString();
                            string time = reader["time"].ToString();
                            string date = reader["date"].ToString();
                            string desc = reader["description"].ToString();
                            string loc = reader["location"].ToString();
                            string from = reader["from"].ToString();
                            Event eventx = new Event();
                            eventx.ID = id;
                            eventx.Title = title;
                            eventx.Time = time;
                            eventx.Date = date;
                            eventx.Description = desc;
                            eventx.Location = loc;
                            eventx.From = from;
                            events.Add(eventx);

                        }
                        reader.Close();
                    }
                    return events;
                }
                catch (MySqlException Ex)
                {
                    GlobalHandlers.Debugger.write(Ex.ToString());
                    return events;

                }
            }
            return events;
        }
        public List<Announcement> getAnnouncements()
        {
            List<Announcement> n = new List<Announcement>();
            if (MySqlConnection.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM `announcements`", MySqlConnection);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows == false)
                        {
                            reader.Close();
                            cmd.Dispose();
                            return n;
                        }
                        while (reader.Read())
                        {
                            string txt = reader["text"].ToString().HtmlDecode();
                            string title = reader["title"].ToString();
                            int id = Int32.Parse(reader["id"].ToString());
                            string locked = reader["locked"].ToString();

                            Announcement ac = new Announcement();
                            ac.Text = txt;
                            ac.ID = id;
                            ac.Title = title;
                            if (locked == "True")
                                ac.locked = true;
                            n.Add(ac);
                        }
                        reader.Close();
                        return n;
                    }

                }
                catch (MySqlException expc)
                {
                    GlobalHandlers.Debugger.write(expc.ToString());
                }
            }
            return n;
        }
        public string getFeatureValue(string feature)
        {
            if (MySqlConnection.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    MySqlCommand command = new MySqlCommand("SELECT * FROM `features` WHERE `name` = '" + feature + "'", MySqlConnection);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows == false)
                        {
                            reader.Close();
                            command.Dispose();
                            return "";
                        }
                        while (reader.Read())
                        {
                            //lets get the feature value...o
                            string r = reader["value"].ToString();
                            reader.Close();
                            return r;
                        }
                    }
                }
                catch (MySqlException exc)
                {
                    GlobalHandlers.Debugger.write(exc.ToString());
                }
            }
            return "";
        }

        public string getUsernameFromSessionID()
        {
            if (GlobalHandlers.SessionHandler.isLoggedIn())
            {
                return HttpContext.Current.Session["username"].ToString();
            }
            else
            {
                return "";
            }
        }
        public LoginResult login(string username, string password)
        {
            string saltFromDatabase = "";
            string passwordHashedWithSalt = "";
            string passwordFromDatabase = "";
            try
            {
                if (MySqlConnection.State == System.Data.ConnectionState.Open)
                {
                    MySqlCommand command = new MySqlCommand("SELECT * FROM users WHERE username=?username", MySqlConnection);
                    command.Parameters.AddWithValue("?username", username);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows == false)
                        {
                            reader.Close();
                            return LoginResult.UserDoesNotExist;
                        }

                        while (reader.Read())
                        {
                            saltFromDatabase = reader["salt"].ToString();
                            passwordHashedWithSalt = MD5Helper.getMD5Hash(password, saltFromDatabase);
                            passwordFromDatabase = reader["password"].ToString();
                            //  Debug.WriteLine("our output result: salt[" + saltFromDatabase + "] passFromDatabase: [" + passwordFromDatabase + "] ourGeneratedPass: [" + passwordHashedWithSalt + "]");
                            if (passwordFromDatabase == passwordHashedWithSalt)
                            {
                                reader.Close();
                                return LoginResult.SUCCESSFUL;
                            }
                            else if (passwordHashedWithSalt != passwordFromDatabase)
                            {
                                reader.Close();
                                return LoginResult.PasswordIncorrect;
                            }
                        }
                        reader.Close();
                    }
                  // MySqlDataReader reader = command.ExecuteReader();

                }
                else
                {
                    MySqlCommand command = new MySqlCommand("SELECT * FROM users WHERE username=?username", MySqlConnection);
                    command.Parameters.AddWithValue("?username", username);
                    command.Connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows == false)
                    {
                        reader.Close();
                        return LoginResult.UserDoesNotExist;

                    }
                    while (reader.Read())
                    {
                        saltFromDatabase = reader["salt"].ToString();
                        passwordHashedWithSalt = MD5Helper.getMD5Hash(password, saltFromDatabase);
                        passwordFromDatabase = reader["password"].ToString();
                        if (passwordFromDatabase == passwordHashedWithSalt)
                        {
                            reader.Close();
                            return LoginResult.SUCCESSFUL;
                        }
                        else if (passwordHashedWithSalt != passwordFromDatabase)
                        {
                            reader.Close();
                            return LoginResult.PasswordIncorrect;
                        }
                    }
                    reader.Close();
                }
                return LoginResult.Unknown;
            }
            catch (MySqlException exp)
            {
                GlobalHandlers.Debugger.write(exp.ToString());

                return LoginResult.Unknown;
            }
        }

        internal admin.core.features.announcements.NotificationType addAnnouncement(string title, string content, bool locked)
        {
            try
            {
                if (MySqlConnection.State == System.Data.ConnectionState.Open)
                {
                    MySqlCommand cmd = new MySqlCommand("INSERT into `announcements` (`title`, `text`, `locked`) VALUES(?title, ?content, ?locked);", MySqlConnection);
                    cmd.Parameters.AddWithValue("?title", title);
                    cmd.Parameters.AddWithValue("?content", content);
                    cmd.Parameters.AddWithValue("?locked", locked.ToString());
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    return admin.core.features.announcements.NotificationType.Successful;
                }
                else
                {

                    return admin.core.features.announcements.NotificationType.Error;
                }
            }
            catch (Exception eee)
            {
                GlobalHandlers.Debugger.write(eee.ToString());
                return admin.core.features.announcements.NotificationType.Error;
            }
        }

        internal Dictionary<string, string> getSettings()
        {
            Dictionary<string, string> toReturn = new Dictionary<string, string>();
            try
            {
                if (MySqlConnection.State == System.Data.ConnectionState.Open)
                {
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM `settings`", MySqlConnection);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows == false)
                        {
                            reader.Close();
                            return toReturn;
                        }
                        while (reader.Read())
                        {
                            string value = reader["value"].ToString();
                            string key = reader["key"].ToString();
                            toReturn.Add(key, value);
                        }
                        reader.Close();
                        return toReturn;
                    }
                }
                return toReturn;
            }
            catch (MySqlException eee)
            {
                //  GlobalHandlers.Debugger.write(eee.ToString());
                return toReturn;
            }
        }

        internal List<Tile> loadTiles()
        {
            List<Tile> filterList = new List<Tile>();
            if (MySqlConnection.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM `tiles`", MySqlConnection);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            cmd.Dispose();
                            reader.Close();
                            return filterList;
                        }
                        while (reader.Read())
                        {
                            string id = reader["tile_id"].ToString();
                            string name = reader["name"].ToString();
                            string color = reader["color"].ToString();
                            string size = reader["size"].ToString();
                            string label = reader["label"].ToString();
                            string iconSrc = reader["iconSrc"].ToString();
                            string appTitle = reader["appTitle"].ToString();
                            string appUrl = reader["appUrl"].ToString();
                            string iconSize = reader["iconSize"].ToString();
                            Tile t = new Tile();
                            t.unique_id = id;
                            t.name = name;
                            t.color = color;
                            t.size = size;
                            t.label = label;
                            t.iconSrc = iconSrc;
                            t.appTitle = appTitle;
                            t.appUrl = appUrl;
                            t.iconSize = iconSize;
                            filterList.Add(t);

                        }
                        reader.Close();
                        return filterList;
                    }
                }
                catch (MySqlException ecc)
                {
                    GlobalHandlers.Debugger.write(ecc.ToString());
                }
            }
            return filterList;
        }

        public string[] getListOfItemsForADay(string loadDate)
        {
            string tx = GlobalHandlers.DatabaseHandler.getFeatureValue("lunchmenu");
            if (tx != null)
            {
                List<LunchDay> days = new List<LunchDay>();
                tx = tx.Replace("{", "");
                tx = tx.Replace("}", "");
                string[] res = tx.Split(new string[] { ":::" }, StringSplitOptions.None);
                foreach (string stt in res)
                {
                    LunchDay newDay = new LunchDay();
                    string[] xxx = stt.Split(new string[] { "," }, StringSplitOptions.None);
                    newDay.Day = xxx[0];
                    string items = stt.Replace(xxx[0] + ",", "");
                    newDay.Items = items;
                    days.Add(newDay);
                }
                foreach (LunchDay day in days)
                {
                    string today = loadDate;
                    if (day.Day == today)
                    {
                        List<String> str = new List<string>();
                        string[] list = day.Items.Split(Char.Parse("/"));
                        return list;
                    }
                }
                return null;
            }
            return null;
        
        }
    }


    public enum Type
    {
        MySQL, MsSQL
    }
    public enum LoginResult
    {
        SUCCESSFUL, UserDoesNotExist, PasswordIncorrect, Unknown
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