using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SundayTech_Assignment_StudentAPI.Services;
using System.IO;
using SundayTech_Assignment_StudentAPI.Filters;
using SundayTech_Assignment_StudentAPI.BussinessLogic.Concreate;
using SundayTech_Assignment_StudentAPI.BussinessLogic.Abstract;

namespace SundayTech_Assignment_StudentAPI
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
            services.AddControllers();
            services.AddDbContext<DataContext.AppContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
            //Register dapper in scope    
            services.AddScoped<IDapper, Dapperr>();

            services.AddCors(option => option.AddPolicy("APIPolicy", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            }));

            //Added Global filter
            services.AddControllers(config =>
            {
                config.Filters.Add(new ValidationFilterAttribute());
            });

            //Added Scoped Filter - Action or Controller level
            services.AddScoped<LoggerFilterAttribute>();

            services.AddScoped<IStudentManager, StudentManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            var path = Directory.GetCurrentDirectory();
            loggerFactory.AddFile($"{path}\\Logs\\Log.txt");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
