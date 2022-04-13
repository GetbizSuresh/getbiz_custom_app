using getbiz_custom_app.Models;
using getbiz_custom_app.Repository.Custom_App_Master;
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
    public class CustomAppMasterController : ControllerBase
    {
        private ICustomAppMasterRepository customAppMasterRepository;
        public CustomAppMasterController(ICustomAppMasterRepository _customAppMasterRepository)
        {
            customAppMasterRepository = _customAppMasterRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/AddCustomAppData")]
        public IActionResult AddCustomAppData([FromForm] custom_app_master_Fetchdata _custom_app_master)
        {
            try
            {
                string getimagename = _custom_app_master.customapp_upload_image.FileName;
                _custom_app_master.custom_app_icon_image = getimagename;
                var messages = customAppMasterRepository.AddCustomAppData(_custom_app_master);
                
              
                
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
        [Route("api/EditCustomAppData")]
        public IActionResult EditCustomAppData([FromForm] custom_app_master_Fetchdata _custom_app_master)
        {
            try
            {
                string getimagename = _custom_app_master.customapp_upload_image.FileName;
                _custom_app_master.custom_app_icon_image = getimagename;
                var messages = customAppMasterRepository.EditCustomAppData(_custom_app_master);
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
        [Route("api/GetCustomAppData")]
        public IActionResult GetCustomAppData()
        {
            try
            {
                var messages = customAppMasterRepository.GetCustomAppData();
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
        [Route("api/GetCustomAppDataById")]
        public IActionResult GetCustomAppDataById(int GetCustomAppDataById)
        {
            try
            {
                var messages = customAppMasterRepository.GetCustomAppDataById(GetCustomAppDataById);
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




        [HttpPost]
        [Route("api/UpdateCustomAppDevelopmentStatus")]
        public IActionResult UpdateCustomAppDevelopmentStatus(int customAppId, bool publishKey)
        {
            try
            {
                var messages = customAppMasterRepository.UpdateCustomAppDevelopmentStatus(customAppId, publishKey);
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [AllowAnonymous]
        [HttpGet]
        [Route("api/GetAllCustomAppsAuditTrail")]
        public IActionResult GetAllCustomAppsAuditTrail()
        {
            try
            {
                var messages = customAppMasterRepository.GetAllCustomAppsAuditTrail();
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

        [HttpPost]
        [Route("api/AddCustomapps_Customerslist")]
        public IActionResult AddCustomapps_Customerslist(custom_apps_customers_list Objcustomlist)
        {
            try
            {
                var messages = customAppMasterRepository.AddCustomapps_Customerslist(Objcustomlist);
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("api/GetCustomapps_Customerslist")]
        public IActionResult GetCustomapps_Customerslist()
        {
            try
            {
                var messages = customAppMasterRepository.GetCustomapps_Customerslist();
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("api/DeleteCustomapps_Customerslist")]
        public IActionResult DeleteCustomapps_Customerslist(string customer_id)
        {
            try
            {
                var messages = customAppMasterRepository.DeleteCustomapps_Customerslist(customer_id);
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }




    }
}
