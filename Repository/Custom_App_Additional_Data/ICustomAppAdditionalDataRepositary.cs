using getbiz_custom_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_custom_app.Repository.Custom_App_Additional_Data
{
    public interface ICustomAppAdditionalDataRepositary
    {
        Response AddCustomAppAdditionalData(custom_app_additional_data custom_app_additional_data);
        Response EditCustomAppAdditionalData(custom_app_additional_data custom_app_additional_data);
        Response GetALLCustomAppAdditionalData();
        Response GetALLCustomAppAdditionalDataById(int user_app_id);
    }
}
