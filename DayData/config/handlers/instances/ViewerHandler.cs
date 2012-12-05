using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DayData.config.handlers.instances.item;
using System.Diagnostics;

namespace DayData.config.handlers.instances
{
    public class ViewerHandler : Handler
    {
        List<Viewer> view_list;
        public static ViewerHandler create()
        {
            return new ViewerHandler();
        }
        public ViewerHandler()
        {
            view_list = new List<Viewer>();
        }
        public void populateList(List<Viewer> view)
        {
            view_list = view;
        }
        public Viewer getViewerByFeature(Feature feat)
        {
            foreach (Viewer d in view_list)
            {
                int typeParsed;
                Int32.TryParse(d.type, out typeParsed);
                if (typeParsed == (int)feat)
                {
                    return d;
                }
            }
            return null;
        }
        public Status getViewerTypeStatus(ViewerType type, Feature feature)
        {
            Viewer viewer = getViewerByFeature(feature);
            if (type == ViewerType.DESKTOP)
            {
                return (viewer.desktop == "1") ? Status.ENABLED : Status.DISABLED; 
            }
            else if (type == ViewerType.MOBILE)
            {
                return (viewer.mobile == "1") ? Status.ENABLED : Status.DISABLED; 
            }
            else if (type == ViewerType.TABLET)
            {
                return (viewer.tablet == "1") ? Status.ENABLED : Status.DISABLED;
            }
            return Status.DISABLED;
        }
        public enum Status
        {
            DISABLED = 0, ENABLED = 1
        }
        public enum Feature
        {
            ANNOUNCEMENTS = 0,
            EVENTS = 1
        }
        public enum ViewerType
        {
            MOBILE, TABLET, DESKTOP
        }


    }
}