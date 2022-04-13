
using getbiz_custom_app.Getbiz_DbContext;
using getbiz_custom_app.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_custom_app.Repository.Custom_App_Names
{
    public class CustomAppNamesRepository : ICustomAppNamesRepository
    {
        public readonly CustomApp_DbContext _DbContext;
        public CustomAppNamesRepository(CustomApp_DbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public Response AddCustomAppNames(custom_app_names custom_app_names_Model)
        {
            Response response = new Response();
            try
            {
                if (custom_app_names_Model.custom_app_id == 0)
                {
                    var obj = _DbContext.custom_app_names.Add(custom_app_names_Model);
                    _DbContext.SaveChanges();

                    response.Message = "Data Saved successfully !!";
                    response.Status = true;
                }
            }
            catch (Exception ex)
            {
                response.Message = "Data Saved to failed !!";
                response.Status = false;
            }
            return response;
        }

        public Response EditCustomAppNames(custom_app_names custom_app_names)
        {
            Response response = new Response();
            try
            {
                custom_app_names _custom_app_names_Model = new custom_app_names();
                _custom_app_names_Model.custom_app_id = custom_app_names.custom_app_id;
                //_custom_app_names_Model.custom_app_names_id = custom_app_names.custom_app_names_id;
                _custom_app_names_Model.custom_app_name = custom_app_names.custom_app_name;
                _custom_app_names_Model.custom_app_web_link = custom_app_names.custom_app_web_link;
               // _custom_app_names_Model.user_app_title_bar_name = custom_app_names.user_app_title_bar_name;
                _custom_app_names_Model.custom_app_icon_name = custom_app_names.custom_app_icon_name;
               // _custom_app_names_Model.custom_app_icon_image_path = custom_app_names.custom_app_icon_image_path;

                _DbContext.Attach(_custom_app_names_Model);
               // _DbContext.Entry(_custom_app_names_Model).Property(p => p.custom_app_id).IsModified = true;
                _DbContext.Entry(_custom_app_names_Model).Property(p => p.custom_app_name).IsModified = true;
                _DbContext.Entry(_custom_app_names_Model).Property(p => p.custom_app_web_link).IsModified = true;
               // _DbContext.Entry(_custom_app_names_Model).Property(p => p.user_app_title_bar_name).IsModified = true;
                _DbContext.Entry(_custom_app_names_Model).Property(p => p.custom_app_icon_name).IsModified = true;
               // _DbContext.Entry(_custom_app_names_Model).Property(p => p.custom_app_icon_image_path).IsModified = true;
                _DbContext.SaveChanges();
                 
                response.Message = "Data updated successfully !!";
                response.Status = true;
            }
            catch (Exception)
            {
                response.Message = "Data updation failed !!";
                response.Status = false;
            }
            return response;
        }

        public Response GetALLCustomAppNames()
        {
            Response response = new Response();
            try
            {
                response.Data = (from master in _DbContext.custom_app_names
                                 select new
                                 {
                                     custom_app_id = master.custom_app_id,
                                     custom_app_name = master.custom_app_name,
                                     custom_app_web_link = master.custom_app_web_link,
                                     //User_App_Title_Bar_Name = master.user_app_title_bar_name,
                                     custom_app_icon_name = master.custom_app_icon_name,
                                     //custom_app_icon_image_Path = master.custom_app_icon_image_path,
                                 }).ToList();
                response.Message = "Data Fetch successfully !!";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Message = "Error, while fetching the data !!";
                response.Status = false;
            }
            return response;
        }
    }
}
