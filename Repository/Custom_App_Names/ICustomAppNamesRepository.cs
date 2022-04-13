using getbiz_custom_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_custom_app.Repository.Custom_App_Names
{
    public interface ICustomAppNamesRepository
    {
        Response GetALLCustomAppNames();
        Response AddCustomAppNames(custom_app_names custom_app_names);
        Response EditCustomAppNames(custom_app_names custom_app_names);
    }
}
