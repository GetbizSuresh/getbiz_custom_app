using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_custom_app.Models
{
    public class custom_apps_update_timestamp
    {
        [Key]
        public int custom_app_id { get; set; }
        public DateTime custom_app_update_timestamp { get; set; }
    }
}
