using getbiz_custom_app.Models;
using getbiz_custom_app.Repository.Custom_App_Cloud_File_Storage_Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_custom_app.Controllers
{
  
    [ApiController]
    public class CustomAppCloudFileStoragePermissionsController : ControllerBase
    {
        private ICustomAppCloudFileStoragePermissionsRepository customAppCloudFileStoragePermissionsRepository;
        public CustomAppCloudFileStoragePermissionsController(ICustomAppCloudFileStoragePermissionsRepository _customAppCloudFileStoragePermissionsRepository)
        {
            customAppCloudFileStoragePermissionsRepository = _customAppCloudFileStoragePermissionsRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/AddCustomAppCloudFileStorage")]
        public IActionResult AddCustomAppCloudFileStorage(custom_app_cloud_file_storage_permissions custom_app_cloud_file_storage_permissions)
        {
            try
            {
                var messages = customAppCloudFileStoragePermissionsRepository.AddCustomAppCloudFileStorage(custom_app_cloud_file_storage_permissions);
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/EditCustomAppCloudFileStorage")]
        public IActionResult EditCustomAppCloudFileStorage(custom_app_cloud_file_storage_permissions custom_app_cloud_file_storage_permissions)
        {
            try
            {
                var messages = customAppCloudFileStoragePermissionsRepository.EditCustomAppCloudFileStorage(custom_app_cloud_file_storage_permissions);
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [AllowAnonymous]
        [HttpGet]
        [Route("api/GetALLCustomAppCloudFileStorage")]
        public IActionResult GetALLCustomAppCloudFileStorage()
        {
            try
            {
                var messages = customAppCloudFileStoragePermissionsRepository.GetALLCustomAppCloudFileStorage();
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }   
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/GetALLCustomAppCloudFileStorageById")]
        public IActionResult GetALLCustomAppCloudFileStorageById(int custom_app_id)
        {
            try
            {
                var messages = customAppCloudFileStoragePermissionsRepository.GetALLCustomAppCloudFileStorageById(custom_app_id);
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }



    }
}
