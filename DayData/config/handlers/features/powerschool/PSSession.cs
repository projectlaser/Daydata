using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using PowerschoolParser;

namespace DayData.config.handlers.features.powerschool
{
    public class PSSession
    {
        HttpSessionState session;
        Student student;
        public PSSession(HttpSessionState ses, Student stud)
        {
            session = ses;
            student = stud;
        }
        public HttpSessionState getSession()
        {
            return session;
        }
        public Student getStudent()
        {
            return student;
        }

    }
}