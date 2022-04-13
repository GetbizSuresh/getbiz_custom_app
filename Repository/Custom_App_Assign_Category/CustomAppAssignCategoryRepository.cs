using getbiz_custom_app.Getbiz_DbContext;
using getbiz_custom_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_custom_app.Repository.Custom_App_Assign_Category
{
    public class CustomAppAssignCategoryRepository : ICustomAppAssignCategoryRepository
    {
        public readonly CustomApp_DbContext _DbContext;

        GetSetDatabase getSetDatabase = new GetSetDatabase();
        public CustomAppAssignCategoryRepository(CustomApp_DbContext DbContext)
        {
            _DbContext = DbContext;
        }
        public Response2 CustomAppAssignCategory(string user_app_category_id, int custom_app_id, int user_app_category_location)
        {
            Response2 response = new Response2();
            response = getSetDatabase.UpdateCustomId_CategoryLocation(custom_app_id, "Add_Cateogry", user_app_category_id, user_app_category_location);
            return response;
        }

        public Response2 GetCustomAppCategory()
        {
            Response2 response = new Response2();
                response = getSetDatabase.UpdateCustomId_CategoryLocation(0, "GetCustomAppCategory", "", 0);
            return response;
        }
    }
}
