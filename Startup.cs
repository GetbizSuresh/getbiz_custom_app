using getbiz_custom_app.Getbiz_DbContext;
using getbiz_custom_app.Repository.Custom_App_About_Demo;
using getbiz_custom_app.Repository.Custom_App_Additional_Data;
using getbiz_custom_app.Repository.Custom_App_Assign_Category;
using getbiz_custom_app.Repository.Custom_App_Cloud_File_Storage_Permissions;
using getbiz_custom_app.Repository.Custom_App_Comment;
using getbiz_custom_app.Repository.Custom_App_Communication;
using getbiz_custom_app.Repository.Custom_App_Master;
using getbiz_custom_app.Repository.Custom_App_Names;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Net;

namespace getbiz_custom_app
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           
            string mySqlConnectionStr = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContextPool<CustomApp_DbContext>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));


            services.AddControllers().AddNewtonsoftJson();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "getbiz_custom_app", Version = "v1" });
            });

            services.AddScoped<ICustomAppAboutDemoRepository, CustomAppAboutDemoRepository>();
            services.AddScoped<ICustomAppCloudFileStoragePermissionsRepository, CustomAppCloudFileStoragePermissionsRepository>();
            services.AddScoped<ICustomAppCommentsSectionRepository, CustomAppCommentsSectionRepository>();
            services.AddScoped<ICustomAppCommunicationRepository, CustomAppCommunicationRepository>();
            services.AddScoped<ICustomAppMasterRepository, CustomAppMasterRepository>();
            services.AddScoped<ICustomAppNamesRepository, CustomAppNamesRepository>();
            services.AddScoped<ICustomAppAdditionalDataRepositary, CustomAppAdditionalDataRepositary>();
            services.AddScoped<ICustomAppAssignCategoryRepository, CustomAppAssignCategoryRepository >();

            services.AddCors(option => option.AddPolicy("getbiz_custom_app", builder => {
                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "getbiz_custom_app v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();


            app.UseCors(x => x
             .AllowAnyMethod()
             .AllowAnyHeader()
             .SetIsOriginAllowed(origin => true)
             .AllowCredentials());

            if (ServicePointManager.SecurityProtocol.HasFlag(SecurityProtocolType.Tls12) == false)
            {
                ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol | SecurityProtocolType.Tls12;
            }

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
