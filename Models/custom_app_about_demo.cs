using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_custom_app.Models
{
    public class custom_app_about_demo
    {
        [Key]
        public int custom_app_about_demo_id { get; set; }

        public int custom_app_id { get; set; }
        public string custom_app_demo_video_file { get; set; }
       // public string custom_app_time_stamp_title { get; set; }
        public string custom_app_demo_video_timestamp_description_file { get; set; }

        //public  user_app_time_stamp_description { get; set; }
        public string custom_app_attachments_file { get; set; }

        //public string custom_app_communication { get; set; }
    }
}
