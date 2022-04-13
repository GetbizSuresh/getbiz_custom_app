using getbiz_custom_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_custom_app.Repository.Custom_App_Communication
{
    public interface ICustomAppCommunicationRepository
    {
        Response GetAllCommunicationData(int custom_app_id);
        Response GetAllCommunicationDataById(int communication_ID, int custom_app_id);
        Response SaveCommunicationData(custom_app_communication custom_app_communication);
        Response DeleteCommunicationData(int custom_app_id);
        Response UpdateCommunicationData(custom_app_communication custom_app_communication);
        Response DeleteCommunicationDataById(int communication_ID, int custom_AppId);


    }
}
