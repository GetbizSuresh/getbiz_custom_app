using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_custom_app.Models
{

    public class custom_app_master_parent
    {
        public custom_app_master custom_app_master { get; set; }
        //public custom_apps_customers_list custom_apps_customers_list { get; set; }
    }
    public class custom_app_master
    {
        [Key]
        public int custom_app_id { get; set; }
        public string custom_app_icon_name { get; set; }
        public string custom_app_title_bar_name { get; set; }
        public string custom_app_icon_image { get; set; }
        public string custom_app_full_name { get; set; }
        public bool custom_app_development_status { get; set; }

       // public string user_app_category_name { get; set; }
    }

    public class custom_app_master_Fetchdata
    {
        [Key]
        public int custom_app_id { get; set; }
        public string custom_app_icon_name { get; set; }
        public string custom_app_title_bar_name { get; set; }
        public string custom_app_icon_image { get; set; }
        public string custom_app_full_name { get; set; }
        public IFormFile customapp_upload_image { get; set; }

        public bool custom_app_development_status { get; set; }

        // public string user_app_category_name { get; set; }
    }

    public class custom_apps_customers_list
    {
        public string custom_app_id { get; set; }
        public string custom_apps_customers_list_id { get; set; }
        public string customer_id { get; set; }
        public string user_apps_to_be_hidden { get; set; }
        public string custom_app_update_utc_timestamp { get; set; }




    }
}
