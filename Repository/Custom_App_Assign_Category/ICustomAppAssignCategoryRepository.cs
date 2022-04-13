using getbiz_custom_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_custom_app.Repository.Custom_App_Assign_Category
{
    public interface ICustomAppAssignCategoryRepository
    {
        
        Response2 CustomAppAssignCategory(string user_app_category_id, int custom_app_id, int user_app_category_location);
        Response2 GetCustomAppCategory();
    }
}
