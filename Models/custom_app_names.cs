using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_custom_app.Models
{
    public class custom_app_names
    {
        [Key]
       
        public int custom_app_id { get; set; }
        public string custom_app_name { get; set; }
        //public string custom_app_title_bar_name { get; set; }

        //public int custom_app_names_id { get; set; }
        public string custom_app_icon_name { get; set; }
        //public string custom_app_icon_image_path { get; set; }
        public string custom_app_web_link { get; set; }
    }
}
