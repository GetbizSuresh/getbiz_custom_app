using getbiz_custom_app.Models;
using getbiz_custom_app.Repository.Custom_App_Names;
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
    public class CustomAppNamesController : ControllerBase
    {
        private ICustomAppNamesRepository customAppNamesRepository;
        public CustomAppNamesController(ICustomAppNamesRepository _customAppNamesRepository)
        {
            customAppNamesRepository = _customAppNamesRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/AddCustomAppNames")]
        public IActionResult AddCustomAppNames(custom_app_names custom_app_names_Model)
        {
            try
            {
                var messages = customAppNamesRepository.AddCustomAppNames(custom_app_names_Model);
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
        [Route("api/EditCustomAppNames")]
        public IActionResult EditCustomAppNames(custom_app_names custom_app_names_Model)
        {
            try
            {
                var messages = customAppNamesRepository.EditCustomAppNames(custom_app_names_Model);
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
        [Route("api/GetALLCustomAppNames")]
        public IActionResult GetALLCustomAppNames()
        {
            try
            {
                var messages = customAppNamesRepository.GetALLCustomAppNames();
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
 
