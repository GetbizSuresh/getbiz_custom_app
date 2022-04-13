

using getbiz_custom_app.Getbiz_DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_custom_app.Models
{
    public class CommanCode
    {
        public readonly CustomApp_DbContext _DbContext;
        public CommanCode(CustomApp_DbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public Response CommanUpdateStatus(int customAppId, bool developmentStatus, string methodName)
        {
            Response response = new Response();
            try
            {
                custom_apps_update_timestamp _Custom_apps_update_time_stamp = new custom_apps_update_timestamp();
                //custom_apps_audit_trail _user_apps_audit_trail = new custom_apps_audit_trail();
                custom_app_master _custom_app_master = new custom_app_master();


                #region Update Field Custom_app_development_status in  custom_app_master Table
                //0 means Publish and 1 means Unpublish

                if (methodName == "Single_Update_Status")
                {
                    var getData = _DbContext.custom_app_master.Where(z => z.custom_app_id == customAppId).FirstOrDefault();
                    getData.custom_app_id = customAppId;
                    //getData.user_app_development_status = developmentStatus;
                    //_DbContext.custom_app_master.Attach(getData).Property(x => x.user_app_development_status).IsModified = true;
                    _DbContext.Entry(getData).State = EntityState.Modified;
                    _DbContext.SaveChanges();
                }
                #endregion


                //#region user_App_Audit_Trail Update Section
                //var getAuditTrial = _DbContext.user_apps_audit_trail.Where(z => z.custom_app_id == customAppId).FirstOrDefault();

                //if (getAuditTrial != null)
                //{
                //    // 0 = true = Publish // 1= false = unUblish
                //    // 0 being false and 1 being true
                //    getAuditTrial.user_app_activity = (developmentStatus == true ? "Publish Key" : "Un-Publish Key");
                //    getAuditTrial.user_app_activity_by_user_id = 1; //Current UserId
                //    getAuditTrial.user_app_activity_time_stamp = Convert.ToString(DateTime.Now);
                //    getAuditTrial.custom_app_id = customAppId;

                //    _DbContext.user_apps_audit_trail.Attach(getAuditTrial).Property(x => x.user_app_activity).IsModified = true;
                //    _DbContext.user_apps_audit_trail.Attach(getAuditTrial).Property(x => x.user_app_activity_by_user_id).IsModified = true;
                //    _DbContext.user_apps_audit_trail.Attach(getAuditTrial).Property(x => x.user_app_activity_time_stamp).IsModified = true;
                //    _DbContext.user_apps_audit_trail.Attach(getAuditTrial).Property(x => x.custom_app_id).IsModified = true;
                //    _DbContext.Entry(getAuditTrial).State = EntityState.Modified;
                //    _DbContext.SaveChanges();
                //}

                //else  //entry New
                //{
                //    _user_apps_audit_trail.user_app_activity = (developmentStatus == true ? "Publish Key" : "Un-Publish Key");
                //    _user_apps_audit_trail.user_app_activity_by_user_id = 1; //Current UserId
                //    _user_apps_audit_trail.user_app_activity_time_stamp = Convert.ToString(DateTime.Now);
                //    _user_apps_audit_trail.custom_app_id = customAppId;
                //    var obj = _DbContext.user_apps_audit_trail.Add(_user_apps_audit_trail);
                //    _DbContext.SaveChanges();
                //}


                

                #region Update custom_app_update_status
                var getStatusData = _DbContext.custom_apps_update_timestamp.Where(z => z.custom_app_id == customAppId).FirstOrDefault();
                if (getStatusData != null) //entry updated
                {
                    getStatusData.custom_app_id = customAppId;
                    getStatusData.custom_app_update_timestamp = DateTime.UtcNow;
                    _DbContext.custom_apps_update_timestamp.Attach(getStatusData).Property(x => x.custom_app_update_timestamp).IsModified = true;
                    _DbContext.Entry(getStatusData).State = EntityState.Modified;
                    _DbContext.SaveChanges();
                }
                else  //entry New
                {
                    _Custom_apps_update_time_stamp.custom_app_update_timestamp = DateTime.UtcNow;
                    _Custom_apps_update_time_stamp.custom_app_id = customAppId;
                    var obj = _DbContext.custom_apps_update_timestamp.Add(_Custom_apps_update_time_stamp);
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
    }
}
