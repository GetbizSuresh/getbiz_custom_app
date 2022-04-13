using getbiz_custom_app.Models;
using getbiz_custom_app.Repository.Custom_App_About_Demo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace getbiz_custom_app.Controllers
{
    [ApiController]
    public class CustomAppAboutDemoController : ControllerBase
    {
        private ICustomAppAboutDemoRepository customAppAboutDemoRepository;
        public CustomAppAboutDemoController(ICustomAppAboutDemoRepository _customAppAboutDemoRepository)
        {
            customAppAboutDemoRepository = _customAppAboutDemoRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/AddCustomAppAboutDemo")]
        public IActionResult AddCustomAppAboutDemo(custom_app_about_demo custom_app_about_demo)
        {
            try
            {
                var messages = customAppAboutDemoRepository.AddCustomAppAboutDemo(custom_app_about_demo);
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
        [Route("api/EditCustomAppAboutDemo")]
        public IActionResult EditCustomAppAboutDemo(custom_app_about_demo custom_app_about_demo)
        {
            try
            {
                var messages = customAppAboutDemoRepository.EditCustomAppAboutDemo(custom_app_about_demo);
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
        [Route("api/GetALLCustomAppAboutDemo")]
        public IActionResult GetALLCustomAppAboutDemo()
        {
            try
            {
                var messages = customAppAboutDemoRepository.GetALLCustomAppAboutDemo();
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
        [Route("api/GetCustomAppAboutDemoById")]
        public IActionResult GetCustomAppAboutDemoById(int custom_app_id)
        {
            try
            {
                var messages = customAppAboutDemoRepository.GetCustomAppAboutDemoById(custom_app_id);
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
        [Route("api/CustomAppAboutDemoDeleteById")]
        public IActionResult CustomAppAboutDemoDeleteById(int custom_app_id)
        {
            try
            {
                var messages = customAppAboutDemoRepository.CustomAppAboutDemoDeleteById(custom_app_id);
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
