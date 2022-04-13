using getbiz_custom_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_custom_app.Repository.Custom_App_About_Demo
{
    public interface ICustomAppAboutDemoRepository
    {
        Response GetALLCustomAppAboutDemo();
        Response AddCustomAppAboutDemo(custom_app_about_demo custom_app_about_demo);
        Response EditCustomAppAboutDemo(custom_app_about_demo custom_app_about_demo);
        Response CustomAppAboutDemoDeleteById(int custom_app_id);
        Response GetCustomAppAboutDemoById(int custom_app_id);
    }
}
