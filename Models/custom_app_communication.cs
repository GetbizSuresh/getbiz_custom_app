using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_custom_app.Models
{
    public class custom_app_communication
    {

        [Key]
        public int communication_id { get; set; }
        public string communication_timestamp { get; set; }
        public int custom_AppId { get; set; }
        public string communication_text { get; set; }

    }
}
