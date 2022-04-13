using getbiz_custom_app.Models;
using getbiz_custom_app.Repository.Custom_App_Communication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace getbiz_custom_app.Controllers
{
    [ApiController]
    public class CustomAppCommunicationController : ControllerBase
    {
        private ICustomAppCommunicationRepository customAppCommunicationRepository;

        public CustomAppCommunicationController(ICustomAppCommunicationRepository _customAppCommunicationRepository)
        {
            customAppCommunicationRepository = _customAppCommunicationRepository;
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("api/SaveCommunicationData")]
        public IActionResult SaveCommunicationData(custom_app_communication custom_app_communication)
        {
            try
            {
                var messages = customAppCommunicationRepository.SaveCommunicationData(custom_app_communication);
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
        [Route("api/DeleteCommunicationData")]
        public IActionResult DeleteCommunicationData(int custom_app_id)
        {
            try
            {
                var messages = customAppCommunicationRepository.DeleteCommunicationData(custom_app_id);
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
        [Route("api/DeleteCommunicationDataById")]
        public IActionResult DeleteCommunicationDataById(int communication_ID, int custom_AppId)
        {
            try
            {
                var messages = customAppCommunicationRepository.DeleteCommunicationDataById(communication_ID, custom_AppId);
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
        [Route("api/UpdateCommunicationData")]
        public IActionResult UpdateCommunicationData(custom_app_communication custom_app_communication)
        {
            try
            {
                var messages = customAppCommunicationRepository.UpdateCommunicationData(custom_app_communication);
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
        [Route("api/GetAllCommunicationDataById")]
        public IActionResult GetAllCommunicationDataById(int CommunicationId, int custom_app_id)
        {
            try
            {
                var messages = customAppCommunicationRepository.GetAllCommunicationDataById(CommunicationId, custom_app_id);
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
        [Route("api/GetAllCommunicationData")]
        public IActionResult GetAllCommunicationData(int custom_app_id)
        {
            try
            {
                var messages = customAppCommunicationRepository.GetAllCommunicationData(custom_app_id);
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
