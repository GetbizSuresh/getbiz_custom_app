using getbiz_custom_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_custom_app.Repository.Custom_App_Cloud_File_Storage_Permissions
{
    public interface ICustomAppCloudFileStoragePermissionsRepository 
    {
        Response GetALLCustomAppCloudFileStorage();
        Response GetALLCustomAppCloudFileStorageById(int custom_app_id);
        Response AddCustomAppCloudFileStorage(custom_app_cloud_file_storage_permissions custom_app_cloud_file_storage_permissions);
        Response EditCustomAppCloudFileStorage(custom_app_cloud_file_storage_permissions custom_app_cloud_file_storage_permissions);
    }
}
