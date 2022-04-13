using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_custom_app.Models
{
    public class custom_apps_audit_trail
    {
        [Key]
        public int custom_apps_audit_trail_id { get; set; }
        public int custom_app_id { get; set; }
        public string user_app_activity { get; set; }
        public int custom_app_activity_by_user_id { get; set; }
        public DateTime custom_app_activity_timestamp { get; set; }

    }
}
