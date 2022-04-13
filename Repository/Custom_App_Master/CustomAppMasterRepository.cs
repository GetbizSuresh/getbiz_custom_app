
using getbiz_custom_app.Getbiz_DbContext;
using getbiz_custom_app.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using static getbiz_custom_app.Getbiz_DbContext.GetSetDatabase;

namespace getbiz_custom_app.Repository.Custom_App_Master
{

    public class CustomAppMasterRepository : ICustomAppMasterRepository
    {
        public readonly CustomApp_DbContext _DbContext;
        GetSetDatabase getSetDatabase = new GetSetDatabase();
        CommanCode _commanCode = null;
        private IConfiguration _configuration;

        public CustomAppMasterRepository(CustomApp_DbContext DbContext, IConfiguration configuration)
        {
            _DbContext = DbContext;
            _commanCode = new CommanCode(DbContext);
            _configuration = configuration;

        }


        public Response AddCustomAppData(custom_app_master_Fetchdata _custom_app_master)
        {
            Response response = new Response();
            try
            {
                if (_custom_app_master.custom_app_id == 0)
                {
                    custom_app_master obj_Fetchdata = new custom_app_master();
                    obj_Fetchdata.custom_app_id = _custom_app_master.custom_app_id;
                    obj_Fetchdata.custom_app_icon_name = _custom_app_master.custom_app_icon_name;
                    obj_Fetchdata.custom_app_title_bar_name = _custom_app_master.custom_app_title_bar_name;
                    obj_Fetchdata.custom_app_icon_image = _custom_app_master.custom_app_icon_image;
                    obj_Fetchdata.custom_app_full_name = _custom_app_master.custom_app_full_name;
                    obj_Fetchdata.custom_app_development_status = _custom_app_master.custom_app_development_status;

                    var AppMaster = _DbContext.custom_app_master.Add(obj_Fetchdata);
                    _DbContext.SaveChanges();
                    int getuserid = _DbContext.custom_app_master.Max(u => u.custom_app_id);
                    saveImage(convertImage(_custom_app_master.customapp_upload_image), _custom_app_master.custom_app_icon_image, getuserid);


                    custom_apps_update_timestamp _custom_apps_update_timestamp = new custom_apps_update_timestamp();


                    _custom_apps_update_timestamp.custom_app_id = obj_Fetchdata.custom_app_id;
                    _custom_apps_update_timestamp.custom_app_update_timestamp = DateTime.UtcNow;
                    var obj = _DbContext.custom_apps_update_timestamp.Add(_custom_apps_update_timestamp);
                    _DbContext.SaveChanges();


                    custom_apps_audit_trail _custom_apps_audit_trail = new custom_apps_audit_trail();
                    _custom_apps_audit_trail.custom_app_id = obj_Fetchdata.custom_app_id;
                    _custom_apps_audit_trail.user_app_activity = "Added";
                    _custom_apps_audit_trail.custom_app_activity_by_user_id = _custom_apps_audit_trail.custom_app_activity_by_user_id;
                    _custom_apps_audit_trail.custom_app_activity_timestamp = DateTime.UtcNow;

                    _DbContext.custom_apps_audit_trail.Add(_custom_apps_audit_trail);
                    _DbContext.SaveChanges();


                    ///
                    //int customer_App_Id = _custom_app_master.custom_app_id;

                    //getSetDatabase.UpdateCustomId_CategoryLocation(customer_App_Id,"Update","",0);



                    response.Message = "Data Saved successfully !!";
                    response.Data = obj_Fetchdata;
                    response.Status = true;

                }

            }
            catch (Exception ex)
            {
                response.Message = "Data Saved to failed !!";
                response.Status = false;
            }
            return response;
        }

        public Response EditCustomAppData(custom_app_master_Fetchdata custom_app_master)
        {
            Response response = new Response();
            try
            {
                custom_app_master _Custom_App_Master_Edit = new custom_app_master();

                _Custom_App_Master_Edit.custom_app_icon_name = custom_app_master.custom_app_icon_name;
                _Custom_App_Master_Edit.custom_app_title_bar_name = custom_app_master.custom_app_title_bar_name;
                _Custom_App_Master_Edit.custom_app_icon_image = custom_app_master.custom_app_icon_image;
                _Custom_App_Master_Edit.custom_app_full_name = custom_app_master.custom_app_full_name;
                _Custom_App_Master_Edit.custom_app_development_status = custom_app_master.custom_app_development_status;
                _Custom_App_Master_Edit.custom_app_id = custom_app_master.custom_app_id;


                _DbContext.Attach(_Custom_App_Master_Edit);
                _DbContext.Entry(_Custom_App_Master_Edit).Property(p => p.custom_app_icon_name).IsModified = true;
                _DbContext.Entry(_Custom_App_Master_Edit).Property(p => p.custom_app_title_bar_name).IsModified = true;
                _DbContext.Entry(_Custom_App_Master_Edit).Property(p => p.custom_app_icon_image).IsModified = true;
                _DbContext.Entry(_Custom_App_Master_Edit).Property(p => p.custom_app_full_name).IsModified = true;
                _DbContext.Entry(_Custom_App_Master_Edit).Property(p => p.custom_app_development_status).IsModified = true;

                saveImage(convertImage(custom_app_master.customapp_upload_image), custom_app_master.custom_app_icon_image, custom_app_master.custom_app_id);

                custom_apps_audit_trail _custom_apps_audit_trail = new custom_apps_audit_trail();
                _custom_apps_audit_trail.custom_app_id = _Custom_App_Master_Edit.custom_app_id;
                _custom_apps_audit_trail.user_app_activity = "Edited";
                _custom_apps_audit_trail.custom_app_activity_by_user_id = _custom_apps_audit_trail.custom_app_activity_by_user_id;
                _custom_apps_audit_trail.custom_app_activity_timestamp = DateTime.UtcNow;

                _DbContext.custom_apps_audit_trail.Add(_custom_apps_audit_trail);

                _DbContext.SaveChanges();

                response.Message = "Data updated successfully !!";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Message = "Data updation failed !!";
                response.Status = false;
            }
            return response;
        }

        public Response2 GetCustomAppData()
        {
            var getData = getSetDatabase.UpdateCustomId_CategoryLocation(0, "Select", "", 0);

            Response2 response = new Response2();
            List<ParentData> lstParnet = new List<ParentData>();
            ParentData objParent = new ParentData();
            Get_Custom_App_Master_Detail get_Custom_App_Master_Detail = new Get_Custom_App_Master_Detail();
            List<Get_Custom_App_Master_Detail> lstData = new List<Get_Custom_App_Master_Detail>();
            List<Custom_App_Master_Detail> custom_App_Master_Details = (List<Custom_App_Master_Detail>)getData.FilterData;

            foreach (var item in _DbContext.custom_app_master)
            {
                var dtlist = custom_App_Master_Details.Where(z => z.custom_app_id == item.custom_app_id);
                if(dtlist.Any())
                {
                    foreach (var master in dtlist)
                    {
                        get_Custom_App_Master_Detail = new Get_Custom_App_Master_Detail();
                        get_Custom_App_Master_Detail.Path = master.user_app_category_path;
                        get_Custom_App_Master_Detail.custom_app_id = master.custom_app_id;
                        get_Custom_App_Master_Detail.custom_app_icon_name = item.custom_app_icon_name;
                        get_Custom_App_Master_Detail.custom_app_title_bar_name = item.custom_app_title_bar_name;
                        get_Custom_App_Master_Detail.custom_app_icon_image = item.custom_app_icon_image;
                        get_Custom_App_Master_Detail.custom_app_full_name = item.custom_app_full_name;
                        get_Custom_App_Master_Detail.custom_app_development_status = item.custom_app_development_status;
                        //get_Custom_App_Master_Detail.user_app_category_name = master.user_app_category_name;
                        get_Custom_App_Master_Detail.user_app_category_id = master.user_app_category_id;
                        lstData.Add(get_Custom_App_Master_Detail);
                    }
                }
            }

            List<FilterData> lstFilterData = new List<FilterData>();
            FilterData fDataobj = new FilterData();

            for (int i = 0; i < custom_App_Master_Details.Count; i++)
            {
                objParent = new ParentData();
                var list = lstData.Where(z => z.custom_app_id == custom_App_Master_Details[i].custom_app_id).ToList();

                if (list.Count > 0)
                {
                    objParent.Category_Name = Convert.ToString(custom_App_Master_Details[i].user_app_category_name);
                    objParent.filterData = list;
                    lstParnet.Add(objParent);
                }
            }

            try
            {
                response.FilterData = lstParnet;
                response.Message = "Data Fetch successfully !!";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Message = "Error, while fetching the data !!";
                response.Status = false;
            }
            return response;
        }

        private static object GetCatoryName(int custom_app_id, List<GetSetDatabase.Custom_App_Master_Detail> custom_App_Master_Details, string fieldValue)
        {
            string CatName = string.Empty;
            var dt = custom_App_Master_Details.Where(z => z.custom_app_id == custom_app_id).FirstOrDefault();

            if (fieldValue == "Category")
            {
                CatName = dt == null ? "" : dt.user_app_category_name;
            }
            else if (fieldValue == "Path")
            {
                CatName = dt == null ? "" : dt.user_app_category_path;
            }
            return CatName ?? "";
        }




        public Response UpdateCustomAppDevelopmentStatus(int CustomId, bool publishKey)
        {
            return CommanUpdateStatus(CustomId, publishKey, "Single_Update_Status");
        }

        public Response CommanUpdateStatus(int UserId, bool publishKey, string methodName)
        {
            Response response = new Response();
            try
            {
                custom_apps_update_timestamp custom_apps_update_timestamp = new custom_apps_update_timestamp();
                custom_apps_audit_trail custom_apps_audit_trail = new custom_apps_audit_trail();
                custom_app_master custom_app_master = new custom_app_master();


                #region Update Field custom_app_development_status in  custom_app_master Table
                //0 means Publish and 1 means Unpublish

                if (methodName == "Single_Update_Status")
                {
                    var getData = _DbContext.custom_app_master.Where(z => z.custom_app_id == UserId).FirstOrDefault();
                    getData.custom_app_id = UserId;
                    getData.custom_app_development_status = publishKey;
                    _DbContext.custom_app_master.Attach(getData).Property(x => x.custom_app_development_status).IsModified = true;
                    _DbContext.Entry(getData).State = EntityState.Modified;
                    _DbContext.SaveChanges();
                }
                #endregion


                #region custom_apps_audit_trail Update Section
                var getAuditTrial = _DbContext.custom_apps_audit_trail.Where(z => z.custom_app_id == UserId).FirstOrDefault();

                if (UserId == 0)
                {
                    // 0 = true = Publish // 1= false = unUblish
                    // 0 being false and 1 being true
                    getAuditTrial.user_app_activity = (publishKey == true ? "Publish Key" : "Un-Publish Key");
                    getAuditTrial.custom_app_activity_by_user_id = UserId; //Current UserId
                    getAuditTrial.custom_app_activity_timestamp = DateTime.UtcNow;
                    getAuditTrial.custom_app_id = UserId;

                    _DbContext.custom_apps_audit_trail.Attach(getAuditTrial).Property(x => x.user_app_activity).IsModified = true;
                    _DbContext.custom_apps_audit_trail.Attach(getAuditTrial).Property(x => x.custom_app_activity_by_user_id).IsModified = true;
                    //_DbContext.custom_apps_audit_trail.Attach(getAuditTrial).Property(x => x.custom_app_id).IsModified = true;
                    _DbContext.Entry(getAuditTrial).State = EntityState.Modified;
                    _DbContext.SaveChanges();
                }

                else  //entry New
                {
                    custom_apps_audit_trail.user_app_activity = (publishKey == true ? "Publish Key" : "Un-Publish Key");
                    custom_apps_audit_trail.custom_app_activity_by_user_id = UserId; //Current UserId
                    custom_apps_audit_trail.custom_app_activity_timestamp = DateTime.UtcNow;
                    custom_apps_audit_trail.custom_app_id = UserId;
                    var obj = _DbContext.custom_apps_audit_trail.Add(custom_apps_audit_trail);
                    _DbContext.SaveChanges();
                }


                #endregion

                #region Update custom_apps_update_timestamp
                var getStatusData = _DbContext.custom_apps_update_timestamp.Where(z => z.custom_app_id == UserId).FirstOrDefault();
                if (getStatusData != null) //entry updated
                {
                    getStatusData.custom_app_id = UserId;
                    getStatusData.custom_app_update_timestamp = DateTime.UtcNow;
                    _DbContext.custom_apps_update_timestamp.Attach(getStatusData).Property(x => x.custom_app_update_timestamp).IsModified = true;
                    _DbContext.Entry(getStatusData).State = EntityState.Modified;
                    _DbContext.SaveChanges();
                }
                else  //entry New
                {
                    custom_apps_update_timestamp.custom_app_update_timestamp = DateTime.UtcNow;
                    custom_apps_update_timestamp.custom_app_id = UserId;
                    var obj = _DbContext.custom_apps_update_timestamp.Add(custom_apps_update_timestamp);
                    _DbContext.SaveChanges();
                }


                #endregion

                response.Status = true;
                response.Message = "Data updated Successfully";
            }
            catch (Exception ex)
            {

                response.Status = false;
                response.Message = "Data updated failed..";
            }
            return response;
        }

        public Response GetCustomAppDataById(int customAppId)
        {
            Response response = new Response();
            try
            {
                List<custom_app_master> myList = new List<custom_app_master>();
                myList = _DbContext.custom_app_master.Where(c => c.custom_app_id == customAppId).ToList();
                if(myList.Count != 0)
                {
                    string imagepath = customAppId+"//"+ myList[0].custom_app_icon_image;
                    myList[0].custom_app_icon_image = imagepath;
                    response.Data = myList;
                    response.Message = "Data Fetch Successfully !!";
                    response.Status = true;
                }
                else
                {
                    response.Data = myList;
                    response.Message = "Data not found Kindly Check..!!";
                    response.Status = true;
                }
              
            }
            catch (Exception ex)
            {
                response.Message = "Data updation failed !!";
                response.Status = false;
            }
            return response;
        }


        public Response GetAllCustomAppsAuditTrail()
        {
            Response response = new Response();
            try
            {
                response.Data = (from master in _DbContext.custom_apps_audit_trail
                                 join assign in _DbContext.custom_app_master on master.custom_app_id
                                   equals assign.custom_app_id
                                 select new
                                 {
                                     // User_App_Audit_Trail_Id = master.user_app_audit_trail_Id,
                                     custom_app_id = master.custom_app_id,
                                     custom_app_activity = master.user_app_activity,
                                     custom_app_activity_by_user_id = master.custom_app_activity_by_user_id,
                                     custom_app_activity_timestamp = master.custom_app_activity_timestamp,
                                     custom_app_full_name = assign.custom_app_full_name,


                                 }).ToList();
                response.Message = "Data Fetch successfully !!";
                response.Status = true;

            }
            catch (Exception ex)
            {
                response.Message = "Error, while fetching the data !!";
                response.Status = false;
            }
            return response;
        }

        protected string saveImage(byte[] image, string name, int userid)
        {
            string uniqueFileName = name;
            string LiveServerpath = _configuration.GetSection("LiveCustomapp").Value;
            string pathname = LiveServerpath + userid;
            bool exists = System.IO.Directory.Exists(pathname);
            if (!exists)
            {
                System.IO.Directory.CreateDirectory(pathname);
            }

            using (MemoryStream mem = new MemoryStream(image))
            {
                using (var yourImage = Image.FromStream(mem))
                {
                    var filepath = pathname + "\\" + uniqueFileName;
                    yourImage.Save(filepath, ImageFormat.Png);
                }
            }
            return uniqueFileName;
        }

        protected static byte[] convertImage(IFormFile imgToResize)
        {
            using (var ms = new MemoryStream())
            {
                imgToResize.CopyTo(ms);
                var fileBytes = ms.ToArray();
                ms.Dispose();
                return (byte[])fileBytes;
            }
        }


        public Response AddCustomapps_Customerslist(custom_apps_customers_list Objcustomlist)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                var result = Obj_getsetdb.AddCustomapps_Customerslist(Objcustomlist);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }



        public Response GetCustomapps_Customerslist()
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                var result = Obj_getsetdb.GetCustomapps_Customerslist();
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response DeleteCustomapps_Customerslist(string customer_id)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                var result = Obj_getsetdb.DeleteCustomapps_Customerslist(customer_id);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }











    }
}
