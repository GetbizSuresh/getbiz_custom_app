using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_custom_app.Models
{
    public class custom_app_additional_data
    {
        [Key]
        public int custom_app_id { get; set; }
        public bool can_this_custom_app_be_blocked_by_app_administrator { get; set; }
        public bool does_this_app_have_configuration_data_specific_to_this_app { get; set; }
        public bool appsuitable_displayed_launchscreen_freeaccess_unregistered_users { get; set; }
    }
}
