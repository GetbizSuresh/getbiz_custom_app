using getbiz_custom_app.Repository.Custom_App_Assign_Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_custom_app.Controllers
{
    [ApiController]
    public class CustomAppAssignCategoryController : ControllerBase
    {
        private ICustomAppAssignCategoryRepository customAppAssignCategoryRepository;
        public CustomAppAssignCategoryController(ICustomAppAssignCategoryRepository _customAppAssignCategoryRepository)
        {
            customAppAssignCategoryRepository = _customAppAssignCategoryRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/CustomAppAssignCategory")]
        public IActionResult CustomAppAssignCategory(string user_app_category_id,int custom_app_id,int user_app_category_location)
        {
            try
            {
                var messages = customAppAssignCategoryRepository.CustomAppAssignCategory(user_app_category_id, custom_app_id, user_app_category_location);
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
        [Route("api/GetCustomAppCategory")]
        public IActionResult GetCustomAppCategory()
        {
            try
            {
                var messages = customAppAssignCategoryRepository.GetCustomAppCategory();
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
