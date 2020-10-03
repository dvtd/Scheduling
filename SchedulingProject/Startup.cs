using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Scheduling.Bussiness.Service.ExamCourseService;
using Scheduling.Bussiness.Service.ExamGroupService;
using Scheduling.Bussiness.Service.ExamService;
using Scheduling.Bussiness.Service.SemesterService;
using Scheduling.Data.Models;
using Scheduling.Data.UnitOfWork;

namespace SchedulingProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get;}

        public void ConfigureServices(IServiceCollection services)
        {
            // configure controller
            services.AddControllers().AddNewtonsoftJson(option => option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
           
            // add config connection string to database
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
            // add config auto mapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // connect unit of work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //DI for all service
            ServiceAddScoped(services);

            // add config swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FPTU - Scheduling API", Version = "v1" });
            });

        }
        public void ServiceAddScoped(IServiceCollection services)
        {
            services.AddScoped<ISemesterService, SemesterService>();
            services.AddScoped<IExamService, ExamService>();
            services.AddScoped<IExamCourseService, ExamCourseService>();
            services.AddScoped<IExamGroupService, ExamGroupService>();

        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            // add swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FPTU - Scheduling API");
            });


            app.UseRouting();
            // add authorization
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
