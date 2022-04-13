using getbiz_custom_app.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace getbiz_custom_app.Getbiz_DbContext
{
    public class GetSetDatabase
    {
        string connection = "Server=185.252.235.20;User ID=root;Password=GetBizMysqlDatabasePwd2021@;Database=customappdb; Allow User Variables=true";
        string connection2 = "Server=185.252.235.20;User ID=root;Password=GetBizMysqlDatabasePwd2021@;Database=userappdb; Allow User Variables=true";


        public Response CreateCommentTableDyanmically(Int32 comment_id, Int32 custom_AppId, string comment_timestamp,
              string comment_text, Int32 is_the_comment_private, string comment_reply, Int32 comment_reply_by_user_id, string Counter)
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            MySqlParameter[] param = new MySqlParameter[8];
            using MySqlConnection con = new MySqlConnection(connection);
            try
            {
                param[0] = new MySqlParameter("p_custom_AppId", MySqlDbType.Int32);
                param[0].Value = custom_AppId;

                param[1] = new MySqlParameter("p_commentText", MySqlDbType.VarChar);
                param[1].Value = comment_text;

                param[2] = new MySqlParameter("p_is_the_comment_private", MySqlDbType.Int32);
                param[2].Value = is_the_comment_private;

                param[3] = new MySqlParameter("p_commentReply", MySqlDbType.VarChar);
                param[3].Value = comment_reply;

                param[4] = new MySqlParameter("p_comment_reply_by_user_id", MySqlDbType.Int32);
                param[4].Value = comment_reply_by_user_id;

                param[5] = new MySqlParameter("p_comment_timestamp", MySqlDbType.Int32);
                param[5].Value = comment_timestamp;

                param[6] = new MySqlParameter("p_Counter", MySqlDbType.VarChar);
                param[6].Value = Counter;

                param[7] = new MySqlParameter("p_commentId", MySqlDbType.VarChar);
                param[7].Value = comment_id;

                

                ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_CreateCommentTableDyanmically", param);
            }
            catch (Exception ex)
            {

            }

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //GetAll
                    if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "GetAll")
                    {
                        List<custom_app_comment> lst_comment_For_User = new List<custom_app_comment>();
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            custom_app_comment custom_app_comment = new custom_app_comment();
                            custom_app_comment.comment_id = Convert.ToInt32(ds.Tables[0].Rows[i]["comment_id"]);
                            custom_app_comment.custom_AppId = Convert.ToInt32(ds.Tables[0].Rows[i]["custom_AppId"]);
                            custom_app_comment.comment_timestamp = Convert.ToString(ds.Tables[0].Rows[i]["comment_timestamp"]);
                            custom_app_comment.comment_text = Convert.ToString(ds.Tables[0].Rows[i]["comment_text"]);
                            custom_app_comment.is_the_comment_private = Convert.ToInt32(ds.Tables[0].Rows[i]["is_the_comment_private"]);
                            custom_app_comment.comment_reply = Convert.ToString(ds.Tables[0].Rows[i]["comment_reply"]);
                            custom_app_comment.comment_reply_by_user_id = Convert.ToInt32(ds.Tables[0].Rows[i]["comment_reply_by_user_id"]);
                            lst_comment_For_User.Add(custom_app_comment);
                        }
                        response.Data = lst_comment_For_User;

                        response.Message = "Comments data fetched successfully";
                        response.Status = true;
                    }
                    else
                    {
                        response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                        response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                    }
                }
            }
            return response;
        }
        



        //Coummication Section

        public Response CreateCustomAppCommunicationTableDyanmically(int custom_AppId, int p_communication_id, string p_communication_timestamp,
            string p_communication_text, string Counter)
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            MySqlParameter[] param = new MySqlParameter[5];
            using MySqlConnection con = new MySqlConnection(connection);
            try
            {
                param[0] = new MySqlParameter("p_custom_AppId", MySqlDbType.Int32);
                param[0].Value = custom_AppId;

                param[1] = new MySqlParameter("p_communication_id", MySqlDbType.Int32);
                param[1].Value = p_communication_id;

                param[2] = new MySqlParameter("p_communication_timestamp", MySqlDbType.VarChar);
                param[2].Value = p_communication_timestamp;

                param[3] = new MySqlParameter("p_communication_text", MySqlDbType.VarChar);
                param[3].Value = p_communication_text;

                param[4] = new MySqlParameter("p_Counter", MySqlDbType.VarChar);
                param[4].Value = Counter;

                ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_CreateCustomAppCommunicationTableDyanmically", param);
            }
            catch (Exception ex)
            {

            }

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //GetAll
                    if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "GetAll")
                    {
                        List<custom_app_communication> lst_custom_app_communication = new List<custom_app_communication>();
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            custom_app_communication _custom_app_communication = new custom_app_communication();
                            _custom_app_communication.communication_id = Convert.ToInt32(ds.Tables[0].Rows[i]["communication_id"]);
                            _custom_app_communication.custom_AppId = Convert.ToInt32(ds.Tables[0].Rows[i]["custom_AppId"]);
                            _custom_app_communication.communication_timestamp = Convert.ToString(ds.Tables[0].Rows[i]["communication_timestamp"]);
                            _custom_app_communication.communication_text = Convert.ToString(ds.Tables[0].Rows[i]["communication_text"]);
                            lst_custom_app_communication.Add(_custom_app_communication);
                        }
                        response.Data = lst_custom_app_communication;
                        response.Message = "Communication data fetched successfully";
                        response.Status = true;
                    }
                    else
                    {
                        response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                        response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                    }
                }
            }
            return response;
        }

        public Response2 UpdateCustomId_CategoryLocation(int custom_AppId,string Counter,string user_app_category_id,int user_app_category_location)
        {
            Response2 response = new Response2();
            DataSet ds = new DataSet();
            MySqlParameter[] param = new MySqlParameter[4];
            using MySqlConnection con = new MySqlConnection(connection2);
            try
            {
                param[0] = new MySqlParameter("custom_AppId", MySqlDbType.Int32);
                param[0].Value = custom_AppId;

                param[1] = new MySqlParameter("user_App_CateogryId", MySqlDbType.String);
                param[1].Value = user_app_category_id;

                param[2] = new MySqlParameter("user_App_CateogryLocation", MySqlDbType.Int32);
                param[2].Value = user_app_category_location;

                param[3] = new MySqlParameter("Counter", MySqlDbType.String);
                param[3].Value = Counter;

                ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_UpdateCustomId_CategoryLocation", param);

                if(Counter == "Select")
                {
                    response.FilterData = ConvertDataTable<Custom_App_Master_Detail>(ds.Tables[0]);
                    response.Message = "Data Fetched successfully..";
                    response.Status = true;
                }
               else if (Counter == "Add_Cateogry") 
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["result"]) > 0)
                    {
                        response.FilterData = ds.Tables[0].Rows[0]["result"];
                        response.Message = "Data added successfully..";
                        response.Status = true;
                    }
                    else
                    {
                        response.Message = "No Data Added ..";
                        response.Status = true;
                    }
                }
               else if (Counter == "GetCustomAppCategory")
                {
                    response.FilterData = ds.Tables[0];
                    response.Message = "Data Fetched successfully..";
                    response.Status = true;
                }
                else
                {
                    response.Message = "Data Updated successfully..";
                    response.Status = true;
                }
            }
            catch (Exception ex)
            {

            }

            return response;
        }

        public class Custom_App_Master_Detail
        {
            public int custom_app_id { get; set; }
            public string user_app_category_id { get; set; }
            public string user_app_category_path { get; set; }
            public string user_app_category_name { get; set; }

           
        }

        public class Get_Custom_App_Master_Detail
        {
            public string Path { get; set; }
            public int custom_app_id { get; set; }
            public string custom_app_icon_name { get; set; }
            public string custom_app_title_bar_name { get; set; }
            public string custom_app_icon_image { get; set; }
            public string custom_app_full_name { get; set; }
            public bool custom_app_development_status { get; set; }
            //public string user_app_category_name { get; set; }
            public string user_app_category_id { get; set; }
        }




         public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        public static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }



        public Response AddCustomapps_Customerslist(custom_apps_customers_list Objcustomlist)
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            MySqlParameter[] param = new MySqlParameter[5];
            using MySqlConnection con = new MySqlConnection(connection);
            try
            {
                param[0] = new MySqlParameter("p_custom_app_id", MySqlDbType.Int32);
                param[0].Value = Objcustomlist.custom_app_id;

                param[1] = new MySqlParameter("p_custom_apps_cus_id", MySqlDbType.Int32);
                param[1].Value = Objcustomlist.custom_apps_customers_list_id;

                param[2] = new MySqlParameter("p_customer_id", MySqlDbType.VarChar);
                param[2].Value = Objcustomlist.customer_id;

                param[3] = new MySqlParameter("p_user_apps_to_be_hidden", MySqlDbType.VarChar);
                param[3].Value = Objcustomlist.user_apps_to_be_hidden;

                param[4] = new MySqlParameter("p_custom_app_update_utc_timestamp", MySqlDbType.VarChar);
                param[4].Value = Objcustomlist.custom_app_update_utc_timestamp;

                ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_InsertCustomapps_Customerslist", param);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        if (Convert.ToString(ds.Tables[0].Rows[0]["Status"]) == "200")
                        {

                            response.Data = "";
                            response.Message = "Add Customapps_Customerslist Successfull...! ";
                            response.Status = true;
                        }
                        else
                        {
                            response.Message = "Oops Something Went wrong...!";
                            response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                        }
                    }
                    else
                    {
                        response.Message = "Data not Found....!";
                        response.Status = false;
                    }
                }
                else
                {
                    response.Message = "Oops Something Went wrong...!";
                    response.Status = false;
                }

            }
             

            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
            }
            return response;
        }




        public Response GetCustomapps_Customerslist()
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            MySqlParameter[] param = new MySqlParameter[1];
            using MySqlConnection con = new MySqlConnection(connection);
            try
            {
                 ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_GetCustomapps_Customerslist", param);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                            response.Data = ds;
                            response.Message = "Get all Successfull...! ";
                            response.Status = true;
                      
                    }
                    else
                    {
                        response.Message = "Data not Found....!";
                        response.Status = false;
                    }
                }
                else
                {
                    response.Message = "Oops Something Went wrong...!";
                    response.Status = false;
                }

            }


            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
            }
            return response;
        }




        public Response DeleteCustomapps_Customerslist(string customer_id)
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            MySqlParameter[] param = new MySqlParameter[1];
            using MySqlConnection con = new MySqlConnection(connection);
            try
            {
                param[0] = new MySqlParameter("p_customer_id", MySqlDbType.Int32);
                param[0].Value = customer_id;

                ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_DeleteCustomapps_Customerslist", param);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        response.Message = "Deleted Successfull...! ";
                        response.Status = true;
                    }
                    else
                    {
                        response.Message = "Data not Found....!";
                        response.Status = false;
                    }
                }
                else
                {
                    response.Message = "Oops Something Went wrong...!";
                    response.Status = false;
                }

            }


            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
            }
            return response;
        }







    }
}
