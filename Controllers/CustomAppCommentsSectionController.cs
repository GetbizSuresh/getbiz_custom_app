using getbiz_custom_app.Models;
using getbiz_custom_app.Repository.Custom_App_Comment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace getbiz_custom_app.Controllers
{
    [ApiController]
    public class CustomAppCommentsSectionController : ControllerBase
    {
        private ICustomAppCommentsSectionRepository customAppCommentsSectionRepository;

        public CustomAppCommentsSectionController(ICustomAppCommentsSectionRepository _customAppCommentsSectionRepository)
        {
            customAppCommentsSectionRepository = _customAppCommentsSectionRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/SaveComments")]
        public IActionResult SaveComments(custom_app_comment custom_app_comment)
        {
            try
            {
                var messages = customAppCommentsSectionRepository.SaveComments(custom_app_comment);
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
        //[HttpDelete]

        [HttpPost]     //This is Delete Methode
        [Route("api/DeleteComment")]
        public IActionResult DeleteComment(int customAppID)
        {
            try
            {
                var messages = customAppCommentsSectionRepository.DeleteComment(customAppID);
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
        [Route("api/DeleteCommentById")]
        public IActionResult DeleteCommentById(int comment_id, int custom_AppId)
        {
            try
            {
                var messages = customAppCommentsSectionRepository.DeleteCommentById(comment_id, custom_AppId);
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
        [Route("api/SavePublicPrivateComment")]
        public IActionResult SavePublicPrivateComment(int customAppID, int comment_Type)
        {
            try
            {
                var messages = customAppCommentsSectionRepository.SavePublicPrivateComment(customAppID, comment_Type);
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
        [Route("api/UpdateComments")]
        public IActionResult UpdateComments(custom_app_comment custom_app_comment)
        {
            try
            {
                var messages = customAppCommentsSectionRepository.UpdateComments(custom_app_comment);
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
        [Route("api/GetAllComments")]
        public IActionResult GetAllComments(int customAppID)
        {
            try
            {
                var messages = customAppCommentsSectionRepository.GetAllComments(customAppID);
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
        [Route("api/GetAllCommentsById")]
        public IActionResult GetAllCommentsById(int comment_id, int custom_AppId)
        {
            try
            {
                var messages = customAppCommentsSectionRepository.GetAllCommentsById(comment_id, custom_AppId);
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
