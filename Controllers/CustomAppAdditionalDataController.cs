using getbiz_custom_app.Models;
using getbiz_custom_app.Repository.Custom_App_Additional_Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_custom_app.Controllers
{
    [ApiController]
    public class CustomAppAdditionalDataController: ControllerBase
    {
        private ICustomAppAdditionalDataRepositary customAppAdditionalDataRepositary;
        public CustomAppAdditionalDataController(ICustomAppAdditionalDataRepositary _customAppAdditionalDataRepositary)
        {
            customAppAdditionalDataRepositary = _customAppAdditionalDataRepositary;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("api/AddCustomAppAdditionalData")]
        public IActionResult AddCustomAppAdditionalData(custom_app_additional_data custom_app_additional_data)
        {
            try
            {
                var messages = customAppAdditionalDataRepositary.AddCustomAppAdditionalData(custom_app_additional_data);
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
        [Route("api/EditCustomAppAdditionalData")]
        public IActionResult EditCustomAppAdditionalData(custom_app_additional_data custom_app_additional_data)
        {
            try
            {
                var messages = customAppAdditionalDataRepositary.EditCustomAppAdditionalData(custom_app_additional_data);
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
        [Route("api/GetALLCustomAppAdditionalData")]
        public IActionResult GetALLCustomAppAdditionalData()
        {
            try
            {
                var messages = customAppAdditionalDataRepositary.GetALLCustomAppAdditionalData();
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
        [Route("api/GetALLCustomAppAdditionalDataById")]
        public IActionResult GetALLCustomAppAdditionalDataById(int custom_app_id)
        {
            try
            {
                var messages = customAppAdditionalDataRepositary.GetALLCustomAppAdditionalDataById(custom_app_id);
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
