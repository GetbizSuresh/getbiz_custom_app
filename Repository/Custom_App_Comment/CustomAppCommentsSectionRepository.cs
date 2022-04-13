
using getbiz_custom_app.Getbiz_DbContext;
using getbiz_custom_app.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_custom_app.Repository.Custom_App_Comment
{
    public class CustomAppCommentsSectionRepository : ICustomAppCommentsSectionRepository
    {
        public readonly CustomApp_DbContext _DbContext;
        public CustomAppCommentsSectionRepository(CustomApp_DbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public Response DeleteComment(int custom_app_id)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase getSetDatabase = new GetSetDatabase();
                getSetDatabase.CreateCommentTableDyanmically(0, custom_app_id, "", "", 0, "",0, "Delete");
                response.Status = true;
                response.Message = "Comment Deleted Successfully";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Failed to Deleted comment!!";
            }
            return response;
        }

        public Response DeleteCommentById(int comment_id, int custom_AppId)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase getSetDatabase = new GetSetDatabase();
                getSetDatabase.CreateCommentTableDyanmically(comment_id, custom_AppId, "", "", 0, "", 0, "DeleteById");
                response.Status = true;
                response.Message = "Comment Deleted Successfully";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Failed to Deleted comment!!";
            }
            return response;
        }

        public Response GetAllComments(int custom_app_id)
        {
            Response response = new Response();
            try
            {
                try
                {
                    GetSetDatabase getSetDatabase = new GetSetDatabase();
                    var result = getSetDatabase.CreateCommentTableDyanmically(0, custom_app_id,
                    "", "", 0, "",0, "GetAll");
                    response = result;
                }
                catch (Exception ex)
                {
                    response.Status = false;
                    response.Message = "Failed to fetchd data!!";
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error, while fetching the data !!";
                response.Status = false;
            }
            return response;
        }

        public Response GetAllCommentsById(int comment_id, int custom_AppId)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase getSetDatabase = new GetSetDatabase();
                var result = getSetDatabase.CreateCommentTableDyanmically(comment_id, custom_AppId,
                   "", "", 0, "", 0, "GetById");
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Failed to Fetch comment!!";
            }
            return response;
        }

        public Response SaveComments(custom_app_comment custom_app_comment)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase getSetDatabase = new GetSetDatabase();
                var result = getSetDatabase.CreateCommentTableDyanmically(0, custom_app_comment.custom_AppId,
                custom_app_comment.comment_timestamp, custom_app_comment.comment_text, custom_app_comment.is_the_comment_private,
                custom_app_comment.comment_reply, custom_app_comment.comment_reply_by_user_id, "Insert");
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Error! While saving data";
            }
            return response;
        }

        public Response SavePublicPrivateComment(int custom_app_id, int comment_Type)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase getSetDatabase = new GetSetDatabase();
                getSetDatabase.CreateCommentTableDyanmically(0, custom_app_id, "", "", comment_Type, "",0, "PublicPrivateCommentUpdate");
                response.Status = true;
                response.Message = "Data updated successfully";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Data updated failed!!";
            }
            return response;
        }

        public Response UpdateComments(custom_app_comment custom_app_comment)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase getSetDatabase = new GetSetDatabase();
                var result = getSetDatabase.CreateCommentTableDyanmically(custom_app_comment.comment_id,custom_app_comment.custom_AppId,
                custom_app_comment.comment_timestamp, custom_app_comment.comment_text, custom_app_comment.is_the_comment_private,
                custom_app_comment.comment_reply, custom_app_comment.comment_reply_by_user_id, "EditComment");
                response.Status = result.Status;
                response.Message = result.Message;


            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Failed to updated the data";
            }
            return response;
        }
    }
}
