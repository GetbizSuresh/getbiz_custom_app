using getbiz_custom_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_custom_app.Getbiz_DbContext
{
    public class CustomApp_DbContext : DbContext
    {
        public CustomApp_DbContext(DbContextOptions<CustomApp_DbContext> dbContextOptions) : base(dbContextOptions)
        { }
       

        public DbSet<custom_app_about_demo> custom_app_about_demo { get; set; }
        public DbSet<custom_app_cloud_file_storage_permissions> custom_app_cloud_file_storage_permissions { get; set; }
        public DbSet<custom_app_comment> custom_app_comment { get; set; }
        public DbSet<custom_app_communication> custom_app_communication { get; set; }
        public DbSet<custom_app_master> custom_app_master { get; set; }
        public DbSet<custom_app_names> custom_app_names { get; set; }
        //public DbSet<custom_apps_customers_list> custom_apps_customers_list { get; set; }
        public DbSet<custom_app_additional_data> custom_app_additional_data { get; set; }
        public DbSet<custom_apps_update_timestamp> custom_apps_update_timestamp { get; set; }

        public DbSet<custom_apps_audit_trail> custom_apps_audit_trail { get; set; }
    }

}

    

