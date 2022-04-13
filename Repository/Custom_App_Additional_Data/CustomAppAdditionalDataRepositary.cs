using getbiz_custom_app.Getbiz_DbContext;
using getbiz_custom_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_custom_app.Repository.Custom_App_Additional_Data
{
    public class CustomAppAdditionalDataRepositary : ICustomAppAdditionalDataRepositary
    {
        public readonly CustomApp_DbContext _DbContext;
        public CustomAppAdditionalDataRepositary(CustomApp_DbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public Response AddCustomAppAdditionalData(custom_app_additional_data custom_app_additional_data)
        {
            Response response = new Response();
            try
            {
                if (custom_app_additional_data.custom_app_id == 0)
                {
                    response.Message = "Enter User App Id !!";
                    response.Status = false;
                }
                else
                {
                    var obj = _DbContext.custom_app_additional_data.Add(custom_app_additional_data);
                    _DbContext.SaveChanges();
                    response.Message = "Data Saved successfully !!";
                    response.Status = true;

                }
            }
            catch (Exception ex)
            {
                response.Message = "User App Id Already Exist !!";
                response.Status = false;
            }
            return response;
        }

        public Response EditCustomAppAdditionalData(custom_app_additional_data custom_app_additional_data)
        {
            Response response = new Response();     
            try
            {
                custom_app_additional_data _custom_app_additional_data_Model = new custom_app_additional_data();
                _custom_app_additional_data_Model.can_this_custom_app_be_blocked_by_app_administrator = custom_app_additional_data.can_this_custom_app_be_blocked_by_app_administrator;
                _custom_app_additional_data_Model.does_this_app_have_configuration_data_specific_to_this_app = custom_app_additional_data.does_this_app_have_configuration_data_specific_to_this_app;
                //_custom_app_additional_data_Model.does_this_app_have_configuration_data_specific_to_this_app = custom_app_additional_data.does_this_app_have_configuration_data_specific_to_this_app;
                _custom_app_additional_data_Model.appsuitable_displayed_launchscreen_freeaccess_unregistered_users = custom_app_additional_data.appsuitable_displayed_launchscreen_freeaccess_unregistered_users;
                _custom_app_additional_data_Model.custom_app_id = custom_app_additional_data.custom_app_id;
                // _user_app_additional_data_Model.user_app_additional_data_id = user_app_additional_data.user_app_additional_data_id;

                _DbContext.Attach(_custom_app_additional_data_Model);
                _DbContext.Entry(_custom_app_additional_data_Model).Property(p => p.can_this_custom_app_be_blocked_by_app_administrator).IsModified = true;
                //_DbContext.Entry(_custom_app_additional_data_Model).Property(p => p.can_this_app_be_displayed_in_customerbizapp_launch_screen).IsModified = true;
                _DbContext.Entry(_custom_app_additional_data_Model).Property(p => p.does_this_app_have_configuration_data_specific_to_this_app).IsModified = true;
                _DbContext.Entry(_custom_app_additional_data_Model).Property(p => p.appsuitable_displayed_launchscreen_freeaccess_unregistered_users).IsModified = true;
                // _DbContext.Entry(_user_app_additional_data_Model).Property(p => p.user_app_id).IsModified = true;
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

        public Response GetALLCustomAppAdditionalData()
        {
            Response response = new Response();
            try
            {
                response.Data = (from master in _DbContext.custom_app_additional_data
                                 select new
                                 {
                                     //User_App_Additional_Data_Id = master.user_app_additional_data_id,
                                     custom_app_id = master.custom_app_id,
                                     can_this_custom_app_be_blocked_by_app_administrator = master.can_this_custom_app_be_blocked_by_app_administrator == true ? "Yes" : "No",
                                     can_this_app_be_displayed_in_customerbizapp_launch_screen = master.appsuitable_displayed_launchscreen_freeaccess_unregistered_users == true ? "Yes" : "No",
                                     does_this_app_have_configuration_data_specific_to_this_app = master.does_this_app_have_configuration_data_specific_to_this_app == true ? "Yes" : "No",
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

        public Response GetALLCustomAppAdditionalDataById(int custom_app_id)
        {
            Response response = new Response();
            try
            {
                response.Data = _DbContext.custom_app_additional_data.Where(z => z.custom_app_id == custom_app_id).ToList();
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



    }

}