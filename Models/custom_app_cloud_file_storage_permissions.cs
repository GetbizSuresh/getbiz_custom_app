using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_custom_app.Models
{
    public class custom_app_cloud_file_storage_permissions
    {
        [Key]
        public int custom_app_id { get; set; }
        public bool delete_folder { get; set; }
        public bool delete_file { get; set; }
        public bool copy_file { get; set; }

        
        //0 for by Default NO
        //1 for Yes
         
    }
}
