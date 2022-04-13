
using getbiz_custom_app.Getbiz_DbContext;
using getbiz_custom_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_custom_app.Repository.Custom_App_Communication
{
    public class CustomAppCommunicationRepository: ICustomAppCommunicationRepository
    {
        public readonly CustomApp_DbContext _DbContext;
        public CustomAppCommunicationRepository(CustomApp_DbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public Response DeleteCommunicationData(int custom_AppId)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase getSetDatabase = new GetSetDatabase();
                getSetDatabase.CreateCustomAppCommunicationTableDyanmically(custom_AppId, 0,"", "", "Delete");
                response.Status = true;
                response.Message = "Data Deleted Successfully !!";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Error Occured ! while  deleting the data !!";
            }
            return response;
        }

        public Response DeleteCommunicationDataById(int communication_ID, int custom_AppId)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase getSetDatabase = new GetSetDatabase();
                getSetDatabase.CreateCustomAppCommunicationTableDyanmically(communication_ID,custom_AppId,"", "", "DeleteById");
                response.Status = true;
                response.Message = "Data Deleted Successfully !!";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Error Occured ! while  deleting the data !!";
            }
            return response;
        }



        public Response GetAllCommunicationData(int custom_AppId)
        {
            Response response = new Response();
            try
            {
                try
                {
                    GetSetDatabase getSetDatabase = new GetSetDatabase();
                    var result = getSetDatabase.CreateCustomAppCommunicationTableDyanmically(custom_AppId, 0,"", "", "GetAll");
                    response = result;
                }
                catch (Exception ex)
                {
                    response.Status = false;
                    response.Message = "Error occured fetching the data !!";
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

        public Response GetAllCommunicationDataById(int communication_ID, int custom_AppId)
        {
            Response response = new Response();
            try
            {
                try
                {
                    GetSetDatabase getSetDatabase = new GetSetDatabase();
                    var result = getSetDatabase.CreateCustomAppCommunicationTableDyanmically(custom_AppId, communication_ID,"", "", "GetByID");
                    response = result;
                }
                catch (Exception ex)
                {
                    response.Status = false;
                    response.Message = "Error occured ! white fething the data";
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

        public Response SaveCommunicationData(custom_app_communication custom_app_communication)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase getSetDatabase = new GetSetDatabase();
                var result = getSetDatabase.CreateCustomAppCommunicationTableDyanmically(
                    custom_app_communication.custom_AppId,
                    0,
                    custom_app_communication.communication_timestamp,
                    custom_app_communication.communication_text,
                    "Insert");
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Error occured ! white saving the data";
            }
            return response;
        }

        public Response UpdateCommunicationData(custom_app_communication custom_app_communication)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase getSetDatabase = new GetSetDatabase();
                var result = getSetDatabase.CreateCustomAppCommunicationTableDyanmically(custom_app_communication.custom_AppId,
                    custom_app_communication.communication_id,
                    custom_app_communication.communication_timestamp,
                    custom_app_communication.communication_text,
                    "EditCommunication");
                response.Status = result.Status;
                response.Message = result.Message;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Error, while updating the data !!";
            }
            return response;
        }
    }
}
