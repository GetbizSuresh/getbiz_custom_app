using getbiz_custom_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_custom_app.Repository.Custom_App_Master
{
    public interface ICustomAppMasterRepository
    {
        Response2 GetCustomAppData();
        Response AddCustomAppData(custom_app_master_Fetchdata _custom_app_master);
        Response EditCustomAppData(custom_app_master_Fetchdata _custom_app_master);
        Response GetCustomAppDataById(int GetCustomAppDataById);
        Response UpdateCustomAppDevelopmentStatus(int customAppId, bool developmentStatus);

        Response GetAllCustomAppsAuditTrail();
        Response AddCustomapps_Customerslist(custom_apps_customers_list Objcustomlist);

        Response GetCustomapps_Customerslist();
        Response DeleteCustomapps_Customerslist(string customer_id);



    }
}
