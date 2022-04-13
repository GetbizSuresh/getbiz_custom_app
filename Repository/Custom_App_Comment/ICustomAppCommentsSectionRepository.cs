using getbiz_custom_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_custom_app.Repository.Custom_App_Comment
{
    public interface ICustomAppCommentsSectionRepository
    {
        Response GetAllComments(int custom_app_id);
        Response SaveComments(custom_app_comment custom_app_comment);
        Response DeleteComment(int custom_app_id);
        Response SavePublicPrivateComment(int custom_app_id, int comment_Type);
        Response UpdateComments(custom_app_comment custom_app_comment);
        Response DeleteCommentById(int comment_id, int custom_AppId);
        Response GetAllCommentsById(int comment_id, int custom_AppId);
    }
}
