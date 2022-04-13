
using getbiz_custom_app.Getbiz_DbContext;
using getbiz_custom_app.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_custom_app.Repository.Custom_App_About_Demo
{
    public class CustomAppAboutDemoRepository : ICustomAppAboutDemoRepository
    {
       public readonly CustomApp_DbContext _DbContext;
        public CustomAppAboutDemoRepository(CustomApp_DbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public Response AddCustomAppAboutDemo(custom_app_about_demo custom_app_about_demo)
        {
            Response response = new Response();
            try
            {
                if (custom_app_about_demo.custom_app_about_demo_id == 0)
                {
                    //custom_app_about_demo.custom_app_demo_video_timestamp_description_file = DateTime.UtcNow;
                    var obj = _DbContext.custom_app_about_demo.Add(custom_app_about_demo);
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

        public Response EditCustomAppAboutDemo(custom_app_about_demo custom_app_about_demo)
        {
            Response response = new Response();
            try
            {
                custom_app_about_demo _custom_app_about_demo_Model = new custom_app_about_demo();

                _custom_app_about_demo_Model.custom_app_about_demo_id = custom_app_about_demo.custom_app_about_demo_id;
                _custom_app_about_demo_Model.custom_app_id = custom_app_about_demo.custom_app_id;
                _custom_app_about_demo_Model.custom_app_demo_video_file = custom_app_about_demo.custom_app_demo_video_file;
                _custom_app_about_demo_Model.custom_app_demo_video_timestamp_description_file = custom_app_about_demo.custom_app_demo_video_timestamp_description_file;
                _custom_app_about_demo_Model.custom_app_attachments_file = custom_app_about_demo.custom_app_attachments_file;
              
                _DbContext.Attach(_custom_app_about_demo_Model);
                _DbContext.Entry(_custom_app_about_demo_Model).Property(p => p.custom_app_demo_video_file).IsModified = true;
                _DbContext.Entry(_custom_app_about_demo_Model).Property(p => p.custom_app_demo_video_timestamp_description_file).IsModified = true;
                _DbContext.Entry(_custom_app_about_demo_Model).Property(p => p.custom_app_attachments_file).IsModified = true;
              
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

        public Response GetALLCustomAppAboutDemo()
        {
            Response response = new Response();
            try
            {
                response.Data = (from master in _DbContext.custom_app_about_demo
                                 select new
                                 {
                                     custom_app_id = master.custom_app_id,
                                     custom_app_demo_video_file = master.custom_app_demo_video_file,
                                     custom_app_demo_video_timestamp_description_file = master.custom_app_demo_video_timestamp_description_file,
                                     custom_app_attachments_file = master.custom_app_attachments_file,
                                    
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


        public Response GetCustomAppAboutDemoById(int custom_app_id)
        {
            Response response = new Response();
            try
            {
                
                    response.Data = _DbContext.custom_app_about_demo.Where(z => z.custom_app_id == custom_app_id).ToList();
                   
                    response.Message = "Data Fetch successfully !!";
                    response.Status = true;
                
            }
            catch (Exception ex)
            {
                response.Message = "Error occured ! While Fetching  the data !!";
                response.Status = false;
            }
            return response;
        }

        public Response CustomAppAboutDemoDeleteById(int custom_app_id)
        {
            Response response = new Response();
            try
            {
                var customappdelete= _DbContext.custom_app_about_demo.Where(z => z.custom_app_id == custom_app_id).FirstOrDefault();
                _DbContext.custom_app_about_demo.Remove(customappdelete);
                _DbContext.SaveChanges();

                response.Message = "Data Deleted successfully !!";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Message = "Error occured ! While Fetching  the data !!";
                response.Status = false;
            }
            return response;
        }


    }
}
