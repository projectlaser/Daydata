using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DayData.config.handlers;

namespace DayData.admin.core.features.announcements.classes
{
    public class AnnouncementUpdater
    {
        public string updater_id { get; set; }
        private string feature_id { get; set; }
        public string FeatureName
        {
            get
            {
                return TextByIds.getFeatureTypeByID(feature_id);
            }
        }
        public string updater_name
        {
            get;
            set;
        }
        public string link { get; set; }
        public string type { get; set; }
        public string seperator { get; set; }
    }
}