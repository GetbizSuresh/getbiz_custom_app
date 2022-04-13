
using getbiz_custom_app.Getbiz_DbContext;
using getbiz_custom_app.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_custom_app.Repository.Custom_App_Cloud_File_Storage_Permissions
{
    public class CustomAppCloudFileStoragePermissionsRepository : ICustomAppCloudFileStoragePermissionsRepository
    {
        public readonly CustomApp_DbContext _DbContext;
        public CustomAppCloudFileStoragePermissionsRepository(CustomApp_DbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public Response AddCustomAppCloudFileStorage(custom_app_cloud_file_storage_permissions custom_app_cloud_file_storage_permissions)
        {
            Response response = new Response();
            try
            {
                if (custom_app_cloud_file_storage_permissions.custom_app_id == 0)
                {
                    response.Message = "Enter Custom App Id !!";
                    response.Status = false;
                }
                else
                {
                    var obj = _DbContext.custom_app_cloud_file_storage_permissions.Add(custom_app_cloud_file_storage_permissions);
                    _DbContext.SaveChanges();
                    response.Message = "Data Saved successfully !!";
                    response.Status = true;
                }
                
            }
            catch (Exception ex)
            {
                response.Message = "Custom App Id Already Exist!!";
                response.Status = false;
            }
            return response;
        }

        public Response EditCustomAppCloudFileStorage(custom_app_cloud_file_storage_permissions custom_app_cloud_file_storage_permissions)
        {
            Response response = new Response();
            try
            {
                custom_app_cloud_file_storage_permissions _custom_app_cloud_file_storage_permissions_Model = new custom_app_cloud_file_storage_permissions();
                _custom_app_cloud_file_storage_permissions_Model.delete_folder = custom_app_cloud_file_storage_permissions.delete_folder;
                _custom_app_cloud_file_storage_permissions_Model.delete_file = custom_app_cloud_file_storage_permissions.delete_file;
                _custom_app_cloud_file_storage_permissions_Model.copy_file = custom_app_cloud_file_storage_permissions.copy_file;
                _custom_app_cloud_file_storage_permissions_Model.custom_app_id = custom_app_cloud_file_storage_permissions.custom_app_id;
                //_custom_app_cloud_file_storage_permissions_Model.custom_app_cloud_file_storage_permissions_id = custom_app_cloud_file_storage_permissions.custom_app_cloud_file_storage_permissions_id;

                _DbContext.Attach(_custom_app_cloud_file_storage_permissions_Model);
                _DbContext.Entry(_custom_app_cloud_file_storage_permissions_Model).Property(p => p.delete_folder).IsModified = true;
                _DbContext.Entry(_custom_app_cloud_file_storage_permissions_Model).Property(p => p.delete_file).IsModified = true;
                _DbContext.Entry(_custom_app_cloud_file_storage_permissions_Model).Property(p => p.copy_file).IsModified = true;
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

        public Response GetALLCustomAppCloudFileStorage()
        {
            Response response = new Response();
            try
            {
                response.Data = (from master in _DbContext.custom_app_cloud_file_storage_permissions
                                 select new
                                 {
                                     //File_Storage_Permissions_Id = master.custom_app_cloud_file_storage_permissions_id,
                                     custom_app_id = master.custom_app_id,
                                     delete_folder = master.delete_folder == true ? "Yes" : "No",
                                     delete_file = master.delete_file == true ? "Yes" : "No",
                                     copy_file = master.copy_file == true ? "Yes" : "No",
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

        public Response GetALLCustomAppCloudFileStorageById(int custom_app_id)
        {
            Response response = new Response();
            try
            {
                response.Data = _DbContext.custom_app_cloud_file_storage_permissions.Where(z => z.custom_app_id == custom_app_id).ToList();
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
