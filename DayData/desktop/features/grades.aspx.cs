using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DayData.config;
using DayData.config.handlers.features.powerschool;
using PowerschoolParser;

namespace DayData.desktop.features
{
    public partial class grades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string name = "[ERROR]";
            GlobalHandlers.SettingHandler.Settings.TryGetValue("name", out name);
            this.Title = "Grades: " + name;
            name_label.Text = name;
            top_image.ImageUrl = "../../required/css/images/iconready.png";
            top_image.AlternateText = GlobalHandlers.DatabaseHandler.globalInformation.School_Name;
            top_image.Style.Add("max-height", "30px");

            if (Request.QueryString["class"] == null)
            {
                try
                {
                    Student st = GlobalHandlers.PowerschoolHandler.getSessionBySessionID(HttpContext.Current.Session.SessionID).getStudent();
                    if (st != null)
                    {
                        //then if the class is not there, lets see if they're already logged in?
                        login_box.Style.Add("display", "none"); /* hide the login box */
                        //    logout_box.Style.Remove("display");

                        string markup = @"<div class=""box center"" style=""width: 50%""><div class=""box-header""><h1>Grades for ?studentname</h1></div><ul class=""statistics"">?classes</ul></div>";
                        string classMarkup = @"<li style=""font-size: 15px;""><a href=""grades.aspx?class=?classid""><span>?maingrade</span>?classname with ?teachername</a></li>";

                        string toAddClasses = "";


                        foreach (SchoolClass cl in st.Classes)
                        {
                            string toAddTemp = classMarkup;
                            toAddTemp = toAddTemp.Replace("?classid", cl.getID());
                            toAddTemp = toAddTemp.Replace("?maingrade", cl.getSetGrade());
                            toAddTemp = toAddTemp.Replace("?classname", cl.getClassName());
                            toAddTemp = toAddTemp.Replace("?teachername", cl.getTeacherName());
                            toAddClasses += toAddTemp;
                        }

                        string toadd = markup;
                        toadd = toadd.Replace("?studentname", st.Name);
                        toadd = toadd.Replace("?classes", toAddClasses);
                        gradeShower.Controls.Add(new LiteralControl(toadd));
                        GlobalHandlers.PowerschoolHandler.addToSessionList(new PSSession(HttpContext.Current.Session, st));
                    }
                }
                catch (Exception eee)
                {

                }
            }

            if (Request.QueryString["class"] != null)
            {
                GlobalHandlers.Debugger.write("class is not null");
                string classId = Request.QueryString["class"];
                //got the class id, lets get the session and student
                Student st = GlobalHandlers.PowerschoolHandler.getSessionBySessionID(HttpContext.Current.Session.SessionID).getStudent();
                if (st != null)
                {
                    login_box.Style.Add("display", "none");
                    foreach (SchoolClass clas in st.Classes)
                    {
                        if (clas.getID().Equals(classId))
                        {
                            string markup = @"<div class=""box center"" style=""width: 65%""><div class=""box-header""><h1>Assignments for ?classname</h1></div><table class=""datatable""><thead><tr><th>Category</th><th>Assignment</th><th>Score</th><th>Grade</th><th>Due Date</th><th>Codes</th></thead><tbody>?assignmentList</tbody></table></div>";
                            string perAssignmentMarkup = @"<tr><td>?category</td><td>?assignment</td><td>?score</td><td>?grade</td><td>?duedate</td><td>?codes</td></tr>";

                            string toAddMarkup = markup;

                            string assignmentList = "";

                            foreach (Assignment assign in clas.getAssignments())
                            {
                                string temp = perAssignmentMarkup;
                                temp = temp.Replace("?category", assign.CATEGORY);
                                temp = temp.Replace("?assignment", assign.ASSIGNMENT);
                                temp = temp.Replace("?score", assign.SCORE);
                                temp = temp.Replace("?grade", assign.GRADE);
                                temp = temp.Replace("?duedate", assign.DUE_DATE);
                                temp = temp.Replace("?codes", assign.CODES);
                                assignmentList += temp;
                            }
                            toAddMarkup = toAddMarkup.Replace("?classname", clas.getClassName());
                            toAddMarkup = toAddMarkup.Replace("?assignmentList", assignmentList);

                            gradeShower.Controls.Add(new LiteralControl(toAddMarkup));
                            GlobalHandlers.Debugger.write("Class found: " + clas.getClassName());
                            backbutton.HRef = "grades.aspx";
                        }
                    }
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //   string username = username
            string username = usernameBox.Text;
            string password = passwordBox.Text;
            Return returned = null;
            try
            {
                PowerschoolParser.Powerschool ps = new PowerschoolParser.Powerschool();
                returned = ps.login(username, password);
            }
            catch (Exception ee)
            {
                //if this is activated, lets throw an error message.
                error_messages.Controls.Add(new LiteralControl(@"<p style=""color:#CE0A31;""><b>Error. Perhaps <a href=""http://ps.cbcsd.org"">PowerSchool</a> is not responding?</b></p>"));

            }
            if (returned == null)
            {
                return;

            }
            if (returned.getCodeResult() == Return.ResultCode.LOGIN_CREDS_INCORRECT)
            {
                error_messages.Controls.Add(new LiteralControl(@"<p style=""color:#CE0A31;""><b>Incorrect username or password. Please try again.</b></p>"));

            }
            else if (returned.getCodeResult() == Return.ResultCode.GOOD)
            {
                login_box.Style.Add("display", "none"); /* hide the login box */
                // logout_box.Style.Remove("display"); /* show the logout box */

                string markup = @"<div class=""box center"" style=""width: 50%""><div class=""box-header""><h1>Grades for ?studentname</h1></div><ul class=""statistics"">?classes</ul></div>";
                string classMarkup = @"<li style=""font-size: 15px;""><a href=""grades.aspx?class=?classid""><span>?maingrade</span>?classname with ?teachername</a></li>";

                string toAddClasses = "";


                foreach (SchoolClass cl in returned.getStudentResult().Classes)
                {
                    string toAddTemp = classMarkup;
                    toAddTemp = toAddTemp.Replace("?classid", cl.getID());
                    toAddTemp = toAddTemp.Replace("?maingrade", cl.getSetGrade());
                    toAddTemp = toAddTemp.Replace("?classname", cl.getClassName());
                    toAddTemp = toAddTemp.Replace("?teachername", cl.getTeacherName());
                    toAddClasses += toAddTemp;
                }

                string toadd = markup;
                toadd = toadd.Replace("?studentname", returned.getStudentResult().Name);
                toadd = toadd.Replace("?classes", toAddClasses);
                //      toadd = toadd.Replace(returned.getStudentResult().Name, HttpContext.Current.Session.SessionID);

                gradeShower.Controls.Add(new LiteralControl(toadd));
                GlobalHandlers.PowerschoolHandler.addToSessionList(new PSSession(HttpContext.Current.Session, returned.getStudentResult()));
            }


        }

        protected void logout_button_Click(object sender, EventArgs e)
        {
            //logout
            if (GlobalHandlers.PowerschoolHandler.removeFromSessionList(HttpContext.Current.Session.SessionID))
            {
                //true if deleted
                HttpContext.Current.Session.Abandon();
                error_messages.Controls.Add(new LiteralControl(@"<p style=""color:#9ED54C;""><b>You have successfully logged out!</b></p>"));
                login_box.Style.Remove("display");
                gradeShower.Visible = false;
                GlobalHandlers.Debugger.write("Removed");

            }
            else
            {
                GlobalHandlers.Debugger.write("Failed to log out");
            }
        }
    }
}